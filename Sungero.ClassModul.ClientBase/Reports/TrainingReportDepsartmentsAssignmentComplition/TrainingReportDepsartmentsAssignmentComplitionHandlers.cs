using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TrainingReportDepsartmentsAssignmentComplitionClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      var dialog = Dialogs.CreateInputDialog("Исполнительская дисциплина по подразделениям");
      dialog.HelpCode = Constants.TrainingReportDepsartmentsAssignmentComplition.HelpCode;
      dialog.Buttons.AddOkCancel();
      
      //период
      var today = Calendar.UserToday;
      var periodBegin = dialog.AddDate("Начало периуда", false, today.AddDays(-30));
      var periodEnd = dialog.AddDate("Конец периуда", false, today);
      
      //НОР
      var businessUnit = dialog.AddSelect("Выберите компанию", false, DirRX.CustomHRSolution.BusinessUnits.Null);
      var department = dialog.AddSelect("Выберите департамент", false, DirRX.CustomHRSolution.Departments.Null);
      var visibleDepartments = new List<DirRX.CustomHRSolution.IDepartment>();

      var isAdministratorOrAdvisor = Sungero.Docflow.PublicFunctions.Module.Remote.IsAdministratorOrAdvisor();
      
      if (TrainingReportDepsartmentsAssignmentComplition.BusinessUnit == null)
        if (!isAdministratorOrAdvisor)
          businessUnit.From(GetVisibleBusinessUnits());
      
      // Подразделение.
      if (!TrainingReportDepsartmentsAssignmentComplition.DepartmentId.Any())
        if (!isAdministratorOrAdvisor)
      {
        visibleDepartments = GetVisibleDepartments();
        department.From(visibleDepartments);
      }
      else
        visibleDepartments = DirRX.CustomHRSolution.Departments.GetAll().ToList();
      
      
      //
      businessUnit.SetOnValueChanged((arg) =>
                                     {
                                       if (Equals(arg.NewValue, arg.OldValue))
                                         return;
                                       
                                       if (department.Value != null && !Equals(arg.NewValue, department.Value.BusinessUnit))
                                         department.Value = DirRX.CustomHRSolution.Departments.Null;
                                       if (arg.NewValue != null)
                                         department.From(visibleDepartments.Where(d => Equals(d.BusinessUnit, arg.NewValue)));
                                       else
                                         department.From(visibleDepartments);
                                     });
      
      
      dialog.SetOnButtonClick((args) =>
                              {
                                Sungero.Docflow.PublicFunctions.Module.CheckReportDialogPeriod(args, periodBegin, periodEnd);
                              });
      if (dialog.Show() != DialogButtons.Ok)
      {
        e.Cancel = true;
        return;
      }
      
    }
    
    public virtual List<DirRX.CustomHRSolution.IDepartment> GetVisibleDepartments()
    {
      var currentRecipientsIds = Sungero.Docflow.PublicFunctions.Module.GetCurrentRecipients(true);
      var subordinateBusinessUnitsIds = this.GetSubordinateBusinessUnits(currentRecipientsIds, new List<int>());
      var subordinateDepartmentsIds = this.GetSubordinateDepartments(currentRecipientsIds, subordinateBusinessUnitsIds, new List<int>());
      return DirRX.CustomHRSolution.Departments.GetAll().Where(b => subordinateDepartmentsIds.Contains(b.Id)).ToList();
    }
    
    public virtual List<DirRX.CustomHRSolution.IBusinessUnit> GetVisibleBusinessUnits()
    {
      var currentRecipientsIds = Sungero.Docflow.PublicFunctions.Module.GetCurrentRecipients(true);
      var subordinateBusinessUnitsIds = this.GetSubordinateBusinessUnits(currentRecipientsIds, new List<int>());
      return DirRX.CustomHRSolution.BusinessUnits.GetAll().Where(b => subordinateBusinessUnitsIds.Contains(b.Id)).ToList();
    }
    
     /// <summary>
    /// Получить список подчиненных подразделений.
    /// </summary>
    /// <param name="currentRecipientsIds">Список сотрудников, от лица которых текущий сотрудник может получать данные по исполнительской дисциплине.</param>
    /// <param name="businessUnitsIds">Список наших организаций.</param>
    /// <param name="selectedDepartmentIds">Список подразделений для фильтрации.</param>
    /// <returns>Список подчиненных подразделений.</returns>
    public virtual List<int> GetSubordinateDepartments(List<int> currentRecipientsIds, List<int> businessUnitsIds, List<int> selectedDepartmentIds)
    {
      var departmentsIds = new List<int>();
      var departments = Company.Departments.GetAll();
      if (selectedDepartmentIds != null && selectedDepartmentIds.Any())
      {
        departmentsIds.AddRange(selectedDepartmentIds);
      }
      else
      {
        departmentsIds.AddRange(departments.Where(d => d.BusinessUnit != null && businessUnitsIds.Contains(d.BusinessUnit.Id)).Select(d => d.Id));
        if (currentRecipientsIds != null)
          departmentsIds.AddRange(departments.Where(d => d.Manager != null && currentRecipientsIds.Contains(d.Manager.Id) && !departmentsIds.Contains(d.Id)).Select(d => d.Id));
      }
      
      return this.UnwrapSubordinateDepartments(departmentsIds);
    }
    
     /// <summary>
    /// Получить список подчиненных наших организаций.
    /// </summary>
    /// <param name="currentRecipientsIds">Список сотрудников, от лица которых текущий сотрудник может получать данные по исполнительской дисциплине.</param>
    /// <param name="selectedBusinessUnitIds">Список наших организаций для фильтрации.</param>
    /// <returns>Список подчиненных наших организаций.</returns>
    public virtual List<int> GetSubordinateBusinessUnits(List<int> currentRecipientsIds, List<int> selectedBusinessUnitIds)
    {
      var businessUnitsIds = new List<int>();
      var businessUnits = Company.BusinessUnits.GetAll();
      
      if (selectedBusinessUnitIds.Any())
        businessUnitsIds.AddRange(selectedBusinessUnitIds);
      else
        businessUnitsIds.AddRange(businessUnits.Where(b => b.CEO != null && currentRecipientsIds.Contains(b.CEO.Id)).Select(b => b.Id));

      return this.UnwrapSubordinateBusinessUnits(businessUnitsIds);
    }
    
     /// <summary>
    /// Получить список подразделений с дочерними по иерархии оргструктуры.
    /// </summary>
    /// <param name="departmentsIds">Список головных подразделений.</param>
    /// <returns>Список подразделений с дочерними.</returns>
    public virtual List<int> UnwrapSubordinateDepartments(List<int> departmentsIds)
    {
      var departmentCount = 0;
      var departments = Company.Departments.GetAll();
      
      while (departmentCount != departmentsIds.Count())
      {
        departmentCount = departmentsIds.Count();
        departmentsIds.AddRange(departments.Where(d => d.HeadOffice != null && departmentsIds.Contains(d.HeadOffice.Id) && !departmentsIds.Contains(d.Id)).Select(d => d.Id));
      }
      return departmentsIds;
    }
    
    /// <summary>
    /// Получить список подразделений с подчиненными по иерархии.
    /// </summary>
    /// <param name="businessUnitsIds">Список головных наших организаций.</param>
    /// <returns>Список наших организаций с подчиненными.</returns>
    public virtual List<int> UnwrapSubordinateBusinessUnits(List<int> businessUnitsIds)
    {
      var businessUnits = Company.BusinessUnits.GetAll();
      var unitCount = 0;
      while (unitCount != businessUnitsIds.Count())
      {
        unitCount = businessUnitsIds.Count();
        businessUnitsIds.AddRange(businessUnits.Where(b => b.HeadCompany != null && businessUnitsIds.Contains(b.HeadCompany.Id) && !businessUnitsIds.Contains(b.Id))
                                  .Select(b => b.Id));
      }
      
      return businessUnitsIds;
    }
    
  }
}

