using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class UsersConnectLCServerHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      UsersConnectLC.CountCompany = DirRX.CustomHRSolution.BusinessUnits.GetAll().Count();
      UsersConnectLC.CountDepartment = DirRX.CustomHRSolution.Departments.GetAll().Count();
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
      
      //UsersConnectLC.DepartmentName.AddRange(allDepartment.Where(d => allEmployees.Where(em => em.Department.Equals(d))
                                                                 //.Count() == maxEmployee).Select(d => d.Name.ToString()).ToList());
      UsersConnectLC.DepartmentName = departmentName;
      UsersConnectLC.MaxCountEmployee = maxEmployee;
      UsersConnectLC.ReportDate = Calendar.Today;
    }

    public virtual IQueryable<DirRX.CustomHRSolution.IEmployee> GetEmployees()
    { 
      var resultListEmployees = DirRX.CustomHRSolution.Employees.GetAll().Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent);
      
      if (!UsersConnectLC.NoConnect.Value && UsersConnectLC.Department != null && UsersConnectLC.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent
                                                        && Equals(e.Department, UsersConnectLC.Department)
                                                        && Equals(e.BusinessUnitDirRX, UsersConnectLC.BusinessUnit));
      if (!UsersConnectLC.NoConnect.Value && UsersConnectLC.Department == null && UsersConnectLC.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent
                                                        && Equals(e.BusinessUnitDirRX, UsersConnectLC.BusinessUnit));
      if (!UsersConnectLC.NoConnect.Value && UsersConnectLC.Department != null && UsersConnectLC.BusinessUnit == null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteIsNotSent
                                                        && Equals(e.Department, UsersConnectLC.Department));

      
      if (UsersConnectLC.NoConnect.Value && UsersConnectLC.Department != null && UsersConnectLC.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted
                                                        && Equals(e.BusinessUnitDirRX, UsersConnectLC.BusinessUnit)
                                                        && Equals(e.Department, UsersConnectLC.Department));
      if (UsersConnectLC.NoConnect.Value && UsersConnectLC.Department == null && UsersConnectLC.BusinessUnit != null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted
                                                        && Equals(e.BusinessUnitDirRX, UsersConnectLC.BusinessUnit));
      if (UsersConnectLC.NoConnect.Value && UsersConnectLC.Department != null && UsersConnectLC.BusinessUnit == null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted
                                                        && Equals(e.Department, UsersConnectLC.Department));
      if (UsersConnectLC.NoConnect.Value && UsersConnectLC.Department == null && UsersConnectLC.BusinessUnit == null)
        resultListEmployees = resultListEmployees.Where(e => e.PersonalAccountStatusDirRX == DirRX.CustomHRSolution.Employee.PersonalAccountStatusDirRX.InviteAccepted);
      
      if (UsersConnectLC.FilterinEmployeeForDepartment.Value && UsersConnectLC.FilterEmployeesForBusinessUniit.Value)
        resultListEmployees.GroupBy(e => e.BusinessUnitDirRX.Id, e => e.Department.Id);
      else if  (UsersConnectLC.FilterEmployeesForBusinessUniit.Value)
        resultListEmployees.GroupBy(e => e.BusinessUnitDirRX.Id);
      else if  (UsersConnectLC.FilterinEmployeeForDepartment.Value)
        resultListEmployees.GroupBy(e => e.Department.Id);

      var result = resultListEmployees.ToList();
      return result.AsQueryable();
    }

  }
}