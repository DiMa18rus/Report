using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class EmployeeReportServerHandlers
  {
    //Логика до старта отчета
    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      EmployeeReport.CountCompany = DirRX.CustomHRSolution.BusinessUnits.GetAll().Count();
      EmployeeReport.CountDepartment = DirRX.CustomHRSolution.Departments.GetAll().Count();
      var allEmployees = DirRX.CustomHRSolution.Employees.GetAll().ToList();
      var allDepartment = Sungero.Company.Departments.GetAll().ToList();
      var maxEmployee = 0;
      string departmentName = null;
      
      foreach (var department in allDepartment)
      {
        if (maxEmployee < allEmployees.Where(em => em.Department.Equals(department)).Count())
        {
          maxEmployee = allEmployees.Where(em => em.Department.Equals(department)).Count();
          departmentName = department.Name;
        }
      }
      
      //Получение коллекции департ. с одинаковым макс. числом сотрудников
      //UsersConnectLC.DepartmentName.AddRange(allDepartment.Where(d => allEmployees.Where(em => em.Department.Equals(d))
      //.Count() == maxEmployee).Select(d => d.Name.ToString()).ToList());
      
      EmployeeReport.DepartmentName = departmentName;
      EmployeeReport.MaxCountEmployee = maxEmployee;
      EmployeeReport.ReportDate = Calendar.Today;
    }

    //Получение и фильтрация результата отчета
    public virtual IQueryable<DirRX.CustomHRSolution.IEmployee> GetEmployees()
    {
      var resultListEmployees = DirRX.CustomHRSolution.Employees.GetAll().Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent);
      
      if (!EmployeeReport.NoConnect.Value && EmployeeReport.Department != null && EmployeeReport.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent
                                                        && Equals(e.Department, EmployeeReport.Department)
                                                        && Equals(e.BusinessUnitDirRX, EmployeeReport.BusinessUnit));
      if (!EmployeeReport.NoConnect.Value && EmployeeReport.Department == null && EmployeeReport.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent
                                                        && Equals(e.BusinessUnitDirRX, EmployeeReport.BusinessUnit));
      if (!EmployeeReport.NoConnect.Value && EmployeeReport.Department != null && EmployeeReport.BusinessUnit == null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent
                                                        && Equals(e.Department, EmployeeReport.Department));

      
      if (EmployeeReport.NoConnect.Value && EmployeeReport.Department != null && EmployeeReport.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted
                                                        && Equals(e.BusinessUnitDirRX, EmployeeReport.BusinessUnit)
                                                        && Equals(e.Department, EmployeeReport.Department));
      if (EmployeeReport.NoConnect.Value && EmployeeReport.Department == null && EmployeeReport.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted
                                                        && Equals(e.BusinessUnitDirRX, EmployeeReport.BusinessUnit));
      if (EmployeeReport.NoConnect.Value && EmployeeReport.Department != null && EmployeeReport.BusinessUnit == null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted
                                                        && Equals(e.Department, EmployeeReport.Department));
      if (EmployeeReport.NoConnect.Value && EmployeeReport.Department == null && EmployeeReport.BusinessUnit == null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted);
      
      var resultGroupByEmployee = ReturnGroupEmployee(resultListEmployees);
      
      if (resultGroupByEmployee.Any())
        return resultGroupByEmployee.AsQueryable();
      else
        return resultListEmployees;
    }
    
    //Группировка списка
    private List<DirRX.CustomHRSolution.IEmployee> ReturnGroupEmployee(IQueryable<DirRX.CustomHRSolution.IEmployee> resultListEmployees)
    {
      var resultEmployee = new List<DirRX.CustomHRSolution.IEmployee>();
      if (EmployeeReport.FilterinEmployeeForDepartment.Value && EmployeeReport.FilterEmployeesForBusinessUniit.Value)
      {
        #region Варианты группирови
        //var result = resultListEmployees.GroupBy(e => new { e.BusinessUnitDirRX, e.Department }, (key, group) => new
        //                                         {
        //                                           Key1 = key.BusinessUnitDirRX,
        //                                           Key2 = key.Department,
        //                                           resultEmployee = group.ToList()
        //                                         });

        //var result = resultListEmployees.GroupBy(e => e.BusinessUnitDirRX).Select(group => group.GroupBy(e => e.Department));
        #endregion
        var result = resultListEmployees.GroupBy(e => e.BusinessUnitDirRX, e => e.Department);
        foreach (var businessUnit in result)
          foreach (var department in businessUnit)
            foreach (var employee in resultListEmployees.ToList())
              if (employee.Department.Equals(department) && employee.BusinessUnitDirRX.Equals(businessUnit.Key) && !resultEmployee.Contains(employee))
                resultEmployee.Add(employee);
      }
      else if (EmployeeReport.FilterEmployeesForBusinessUniit.Value)
      {
        var result = resultListEmployees.GroupBy(e => e.BusinessUnitDirRX);
        foreach (var businessUnit in result)
          foreach (var employee in businessUnit)
            resultEmployee.Add(employee);
      }
      else if (EmployeeReport.FilterinEmployeeForDepartment.Value)
      {
        var result = resultListEmployees.GroupBy(e => e.Department);
        foreach (var department in result)
          foreach (var employee in department)
            resultEmployee.Add(employee);
      }
      
      return resultEmployee;
    }
  }
}