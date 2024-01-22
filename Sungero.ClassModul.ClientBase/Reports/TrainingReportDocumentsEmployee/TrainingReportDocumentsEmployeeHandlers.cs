using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TrainingReportDocumentsEmployeeClientHandlers
  {
    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      var dialog = Dialogs.CreateInputDialog("Выберите сотрудника");
      
      var businessUnit = dialog.AddSelect("Выберите организацию", false, DirRX.CustomHRSolution.BusinessUnits.Null);
      var department = dialog.AddSelect("Выбире подразделение", false, DirRX.CustomHRSolution.Departments.Null);
      var dateStart = dialog.AddDate("Дата начала", true, Calendar.Today.AddDays(-180));
      var dateEnd = dialog.AddDate("Дата конца", true, Calendar.Today);
      var employee = dialog.AddSelect("Выбире сотрудника", true, DirRX.CustomHRSolution.Employees.Null);
      
      businessUnit.SetOnValueChanged((arg) =>
                                     {
                                       if (Equals(arg.NewValue, arg.OldValue))
                                         return;
                                       
                                       if (department.Value != null && !Equals(arg.NewValue, department.Value.BusinessUnit))
                                         department.Value = DirRX.CustomHRSolution.Departments.Null;
                                       
                                       if (employee.Value != null && arg.NewValue != null)
                                         if (!arg.NewValue.Equals(employee.Value.BusinessUnitDirRX))
                                           employee.Value = DirRX.CustomHRSolution.Employees.Null;
                                       
                                       department.From(GetFilteringDepartments(arg.NewValue));
                                       employee.From(GetFilteringEmployees(businessUnit.Value, department.Value));
                                     });
      
      department.SetOnValueChanged((arg) =>
                                   {
                                     if (!Equals(arg.NewValue, arg.OldValue) && arg.NewValue != null)
                                       businessUnit.Value = DirRX.CustomHRSolution.BusinessUnits.As(arg.NewValue.BusinessUnit);
                                     
                                     if (employee.Value != null && arg.NewValue != null)
                                       if (!arg.NewValue.Equals(employee.Value.Department))
                                         employee.Value = DirRX.CustomHRSolution.Employees.Null;
                                     
                                     employee.From(GetFilteringEmployees(businessUnit.Value, department.Value));
                                   });
      
      employee.SetOnValueChanged((arg) =>
                                 {
                                   if (arg.NewValue == null)
                                     return;
                                   
                                   if (!Equals(arg.NewValue, arg.OldValue) && arg.NewValue != null)
                                   {
                                     businessUnit.Value = DirRX.CustomHRSolution.BusinessUnits.As(employee.Value.BusinessUnitDirRX);
                                     department.Value = DirRX.CustomHRSolution.Departments.As(employee.Value.Department);
                                   }
                                 });
      
      if (dialog.Show() == DialogButtons.Ok)
      {
        TrainingReportDocumentsEmployee.EmployeeId = employee.Value.Id;
        TrainingReportDocumentsEmployee.DateStart = dateStart.Value;
        TrainingReportDocumentsEmployee.DateEnd = dateEnd.Value;
      }
      else
        e.Cancel = true;
    }
    
    
    private List<DirRX.CustomHRSolution.IDepartment> GetFilteringDepartments(DirRX.CustomHRSolution.IBusinessUnit businessUnit)
    {
      var departments = DirRX.CustomHRSolution.Departments.GetAll().Where(d => d.Status == Sungero.CoreEntities.DatabookEntry.Status.Active);
      
      if (businessUnit != null)
        return departments.Where(d => Equals(d.BusinessUnit, businessUnit)).ToList();
      
      return departments.ToList();
    }
    
    private List<DirRX.CustomHRSolution.IEmployee> GetFilteringEmployees(DirRX.CustomHRSolution.IBusinessUnit businessUnit, DirRX.CustomHRSolution.IDepartment department)
    {
      var employees = DirRX.CustomHRSolution.Employees.GetAll();
      
      if (businessUnit != null && department != null)
        return employees.Where(em => em.BusinessUnitDirRX.Equals(businessUnit) && em.Department.Equals(department)).ToList();
      else if (businessUnit != null && department == null)
        return employees.Where(em => em.BusinessUnitDirRX.Equals(businessUnit)).ToList();
      else if (businessUnit == null && department != null)
        return employees.Where(em => em.Department.Equals(department)).ToList();
      
      return employees.ToList();
    }

  }
}