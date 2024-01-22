using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TrainingReportConnectedDepartmentOnEDMServerHandlers
  {

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.TrainingReportConnectedDepartmentOnEDM.ConnectedDepartmentOnEDMTable, TrainingReportConnectedDepartmentOnEDM.ReportSessionId);
    }

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var startReportTime = Calendar.Now;
      var reportSessionId = System.Guid.NewGuid().ToString();
      TrainingReportConnectedDepartmentOnEDM.ReportSessionId = reportSessionId;
      
      var dataTable = new List<Structures.TrainingReportConnectedDepartmentOnEDM.Department>();
      var departments = DirRX.CustomHRSolution.Departments.GetAll().Where(d => d.Status == DirRX.CustomHRSolution.Department.Status.Active);
      
      foreach (var department in departments)
      {
        if (department != null)
        {
          var dataTableRow = Structures.TrainingReportConnectedDepartmentOnEDM.Department.Create();
          dataTableRow.ReportSessionId = TrainingReportConnectedDepartmentOnEDM.ReportSessionId;
          
          if (department.BusinessUnit != null)
            dataTableRow.BusinessUnit = department.BusinessUnit.Name;
          //if (department.AreaTypeDirRX != null)
          //dataTableRow.AeraType = department.AreaTypeDirRX.Name;
          dataTableRow.AeraType = department.Name;
          if (department.SapDivisionDirRX != null)
            dataTableRow.Division = department.SapDivisionDirRX.Name;
          if (department.SapRegionDirRX != null)
            dataTableRow.Region = department.SapRegionDirRX.Name;
          if (department.SapClusterDirRX!= null)
            dataTableRow.Cluster = department.SapClusterDirRX.Name;
          dataTableRow.Cod = department.Code;
          dataTableRow.CountEmployeeOnDepartment = DirRX.CustomHRSolution.Employees.GetAll().Where(em => em.Department.Equals(department)).Count();
          dataTableRow.CountEmployeeAgreedToEDM = DirRX.CustomHRSolution.Employees.GetAll().Where(em => em.Department.Equals(department)
                                                                                                  && em.ConsentDirRX == DirRX.CustomHRSolution.Employee.ConsentDirRX.Signed).Count();
          
          dataTableRow.PercentEmployeeAgreedToEDM = dataTableRow.CountEmployeeAgreedToEDM;
          var ownerCount = Sungero.CoreEntities.Certificates.GetAll().Select(s => s.Owner).ToList();
          dataTableRow.CountEmployeeToValidSignature = DirRX.CustomHRSolution.Employees.GetAll().Where(em => ownerCount.Contains(em)).Count();
          dataTableRow.PercentEmployeeToValidSignature = dataTableRow.CountEmployeeToValidSignature;
          dataTable.Add(dataTableRow);
        }
      }
      
      var groups = dataTable.GroupBy(d => d.BusinessUnit);
      dataTable = groups.SelectMany(g => g).ToList();
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.TrainingReportConnectedDepartmentOnEDM.ConnectedDepartmentOnEDMTable, dataTable);

      var endReportTime = Calendar.Now;
      TrainingReportConnectedDepartmentOnEDM.DateReport = Calendar.Today;
      Logger.DebugFormat("TrainingReportAcquaintanceAssignedParticipantsList. Finish execute report. Total time: {0} sec.", (endReportTime - startReportTime).TotalSeconds.ToString());
    }
  }
}


