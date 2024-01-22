using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class UsersConnectLCClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      // Создание диалога
      var dialog = Dialogs.CreateInputDialog("Сотрудники подключенные к ЛК");
      
      var businessUnit = dialog.AddSelect("Компания", false, DirRX.CustomHRSolution.BusinessUnits.Null)
        .From(DirRX.CustomHRSolution.BusinessUnits.GetAll().Where(b => b.Status == Sungero.CoreEntities.DatabookEntry.Status.Active).ToArray());
      var department = dialog.AddSelect("Подразделение", false, DirRX.CustomHRSolution.Departments.Null)
        .From(GetFilteringDepartments(null, false).ToArray());
      dialog.Buttons.AddOkCancel();

      var isConnect = dialog.AddBoolean("Подключенны к ЛК", false);
      var isFilterForBusinessUnit = dialog.AddBoolean("Группировать сотрудников по орг.", true);
      var isFilterForDepartment = dialog.AddBoolean("Группировать сотрудников по подразделению", true);
      var filterDepartmentsForBusinessUnits = dialog.AddBoolean("Фильтровать подразделения по нашим орг.", true);
      
      // События.
      businessUnit.SetOnValueChanged((arg) =>
                                     {
                                       if (Equals(arg.NewValue, arg.OldValue))
                                         return;
                                       
                                       if (department.Value != null && !Equals(arg.NewValue, department.Value.BusinessUnit))
                                         department.Value = DirRX.CustomHRSolution.Departments.Null;
                                       
                                       department.From(GetFilteringDepartments(arg.NewValue, filterDepartmentsForBusinessUnits.Value));
                                     });
      
      department.SetOnValueChanged((arg) =>
                                   {
                                     if (!Equals(arg.NewValue, arg.OldValue) && arg.NewValue != null)
                                       businessUnit.Value = DirRX.CustomHRSolution.BusinessUnits.As(arg.NewValue.BusinessUnit);
                                   });
      
      filterDepartmentsForBusinessUnits.SetOnValueChanged((arg) =>
                                                          {
                                                            department.From(GetFilteringDepartments(businessUnit.Value, arg.NewValue));
                                                          });
      
      // Показ диалога.
      if (dialog.Show() == DialogButtons.Ok)
      {
        if (businessUnit != null)
          UsersConnectLC.BusinessUnit = businessUnit.Value;
        if (department != null)
          UsersConnectLC.Department = department.Value;
        if (isConnect != null)
          UsersConnectLC.NoConnect = isConnect.Value.Value;
        if (filterDepartmentsForBusinessUnits != null)
          UsersConnectLC.FilterDepartmentsForBusinessUnits = filterDepartmentsForBusinessUnits.Value.Value;
        if (isFilterForBusinessUnit != null)
          UsersConnectLC.FilterEmployeesForBusinessUniit = isFilterForBusinessUnit.Value.Value;
        if (isFilterForDepartment != null)
          UsersConnectLC.FilterinEmployeeForDepartment = isFilterForDepartment.Value.Value;
      }
      else
      {
        e.Cancel = true;
        return;
      }
    }
    
    private List<DirRX.CustomHRSolution.IDepartment> GetFilteringDepartments(DirRX.CustomHRSolution.IBusinessUnit businessUnit, bool? filterDepartmentsForBusinessUnits)
    {
      var departments = DirRX.CustomHRSolution.Departments.GetAll().Where(d => d.Status == Sungero.CoreEntities.DatabookEntry.Status.Active);
      
      // Подразделения фильтруются по НОР.
      if (filterDepartmentsForBusinessUnits == true && businessUnit != null)
        return departments.Where(d => Equals(d.BusinessUnit, businessUnit)).ToList();
      
      // Подразделения не фильтруются по НОР.
      return departments.ToList();
    }

  }
}