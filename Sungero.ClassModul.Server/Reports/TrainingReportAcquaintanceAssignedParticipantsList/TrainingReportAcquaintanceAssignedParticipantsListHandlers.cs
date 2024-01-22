using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TrainingReportAcquaintanceAssignedParticipantsListServerHandlers
  {

    public override void AfterExecute(Sungero.Reporting.Server.AfterExecuteEventArgs e)
    {
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.TrainingReportAcquaintanceAssignedParticipantsList.SourceTableName, TrainingReportAcquaintanceAssignedParticipantsList.ReportSessionId);
      Sungero.Docflow.PublicFunctions.Module.DeleteReportData(Constants.TrainingReportAcquaintanceAssignedParticipantsList.LRDListsHyperLinksTableName, TrainingReportAcquaintanceAssignedParticipantsList.ReportSessionId);
    }

    public override void BeforeExecute(Sungero.Reporting.Server.BeforeExecuteEventArgs e)
    {
      var startReportTime = Calendar.Now;
      Logger.Debug("TrainingReportAcquaintanceAssignedParticipantsList. Start execute report.");
      var reportSessionId = System.Guid.NewGuid().ToString();
      TrainingReportAcquaintanceAssignedParticipantsList.ReportSessionId = reportSessionId;
      TrainingReportAcquaintanceAssignedParticipantsList.ReportDate = Sungero.Docflow.PublicFunctions.Module.ToShortDateShortTime(Calendar.Now);
      
      var dataTable = new List<Structures.TrainingReportAcquaintanceAssignedParticipantsList.TableLine>();
      var lrdListTable = new List<Structures.TrainingReportAcquaintanceAssignedParticipantsList.LRDListTableLine>();
      
      if (TrainingReportAcquaintanceAssignedParticipantsList.IsList == null)
        TrainingReportAcquaintanceAssignedParticipantsList.IsList = false;
      
      if (TrainingReportAcquaintanceAssignedParticipantsList.Document != null || TrainingReportAcquaintanceAssignedParticipantsList.ListLNA != null)
      {
        var employeeLrdLists = new Dictionary<int, System.Collections.Generic.List<string>>();
        var participants = new List<Sungero.CoreEntities.IRecipient>();
        
        #region Отчет для документа
        if (TrainingReportAcquaintanceAssignedParticipantsList.Document != null)
        {
          var document = TrainingReportAcquaintanceAssignedParticipantsList.Document;
          SetParameters(document.Name, document.BusinessUnit.Name);
          
          var employees = DirRX.HRSolution.Employees.GetAll(p => Equals(p.BusinessUnitDirRX, document.BusinessUnit) && p.Status == DirRX.HRSolution.Employee.Status.Active);
          var lrdLists = DirRX.LRDManagement.PublicFunctions.Module.Remote.GetLRDListsByDocumentId(document.Id);
          
          foreach (var lrdList in lrdLists)
          {
            var lrdListTableLine = GetLRDListTableLine(lrdList.Name, Hyperlinks.Get(lrdList));
            lrdListTable.Add(lrdListTableLine);
            
            var participantsFromLrdList = DirRX.CustomHRSolution.Module.LRDManagement.PublicFunctions.Module.GetParticipantsFromLRDList(lrdList, employees).ToList();
            employeeLrdLists = GetEmployeeLRDLists(employeeLrdLists, participantsFromLrdList, lrdList.Name);
            participants.AddRange(participantsFromLrdList);
          }
        }
        #endregion
        
        #region Отчет для Списка ЛНА
        else if (TrainingReportAcquaintanceAssignedParticipantsList.ListLNA != null)
        {
          var listLNA = TrainingReportAcquaintanceAssignedParticipantsList.ListLNA;
          SetParameters(listLNA.Name, listLNA.BusinessUnit.Name);
          
          //Заполнение данных первой страницы
          var docs = TrainingReportAcquaintanceAssignedParticipantsList.ListLNA.DocumentsLNA;
          foreach (var doc in docs)
          {
            var lrdListTableLine = GetLRDListTableLine(doc.DocumentLNA.Name, Hyperlinks.Get(doc.DocumentLNA));
            lrdListTable.Add(lrdListTableLine);
          }
          
          var employees = DirRX.HRSolution.Employees.GetAll(em => Equals(em.BusinessUnitDirRX, listLNA.BusinessUnit) && em.Status == DirRX.HRSolution.Employee.Status.Active);
          
          var participantsFromLrdList = DirRX.LRDManagement.PublicFunctions.Module.GetParticipantsFromLRDList(listLNA, employees).ToList();
          employeeLrdLists = GetEmployeeLRDLists(employeeLrdLists, participantsFromLrdList, listLNA.Name);
          participants.AddRange(participantsFromLrdList);
        }
        #endregion
        
        participants = participants.Distinct().ToList();
        
        foreach (var participant in participants)
        {
          var employee = DirRX.CustomHRSolution.Employees.As(participant);
          if (employee != null)
          {
            var dataTableRow = Structures.TrainingReportAcquaintanceAssignedParticipantsList.TableLine.Create();
            dataTableRow.ReportSessionId = TrainingReportAcquaintanceAssignedParticipantsList.ReportSessionId;
            dataTableRow.FullName = employee.Name;
            dataTableRow.PersonnelNumber = employee.PersonnelNumber;
            dataTableRow.Consent = DirRX.HRSolution.Employees.Info.Properties.ConsentDirRX.GetLocalizedValue(employee.ConsentDirRX);
            dataTableRow.JobTitle = employee.SapStaffPositionDirRX == null ? "" : employee.SapStaffPositionDirRX.Name;
            dataTableRow.JobTitleId = employee.SapStaffPositionDirRX == null ? "" : employee.SapStaffPositionDirRX.Id.ToString();
            dataTableRow.TypicalPosition = employee.SapStaffPositionDirRX != null && employee.SapStaffPositionDirRX.TypicalPosition != null ?
              employee.SapStaffPositionDirRX.TypicalPosition.Name : "";
            dataTableRow.TypicalPositionId = employee.SapStaffPositionDirRX != null && employee.SapStaffPositionDirRX.TypicalPosition != null ?
              employee.SapStaffPositionDirRX.TypicalPosition.Id.ToString() : "";
            dataTableRow.Department = employee.Department.Name;
            dataTableRow.LRDListNames = string.Join(", ", employeeLrdLists[employee.Id]);
            dataTable.Add(dataTableRow);
          }
        }
        
        var groups = dataTable.GroupBy(r => r.FullName);
        dataTable = groups.SelectMany(g => g).ToList();
      }
      
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.TrainingReportAcquaintanceAssignedParticipantsList.SourceTableName, dataTable);
      Sungero.Docflow.PublicFunctions.Module.WriteStructuresToTable(Constants.TrainingReportAcquaintanceAssignedParticipantsList.LRDListsHyperLinksTableName, lrdListTable);
      var endReportTime = Calendar.Now;
      Logger.DebugFormat("TrainingReportAcquaintanceAssignedParticipantsList. Finish execute report. Total time: {0} sec.", (endReportTime - startReportTime).TotalSeconds.ToString());
    }
    
    /// <summary>
    /// Определить параметры, если они не заполнены
    /// </summary>
    /// <param name="documentName">Название документа.</param>
    /// <param name="businessUnit">Наша организация.</param>
    public void SetParameters(string documentName, string businessUnit)
    {
      if (TrainingReportAcquaintanceAssignedParticipantsList.DocumentName == null)
      {
        TrainingReportAcquaintanceAssignedParticipantsList.DocumentName = documentName;
      }
      if (TrainingReportAcquaintanceAssignedParticipantsList.BusinessUnit == null)
      {
        TrainingReportAcquaintanceAssignedParticipantsList.BusinessUnit = businessUnit;
      }
    }
    
    /// <summary>
    /// Создание строки на вкладке LRDListLinks
    /// </summary>
    /// <param name="name">Отображаемое имя строки.</param>
    /// <param name="hyperlink">Ссылка.</param>
    /// <returns>Строка на вкладке LRDListLinks.</returns>
    public Structures.TrainingReportAcquaintanceAssignedParticipantsList.LRDListTableLine GetLRDListTableLine(string name, string hyperlink)
    {
      var lrdListTableLine = Structures.TrainingReportAcquaintanceAssignedParticipantsList.LRDListTableLine.Create();
      lrdListTableLine.ReportSessionId = TrainingReportAcquaintanceAssignedParticipantsList.ReportSessionId;
      lrdListTableLine.LRDListName = name;
      lrdListTableLine.LRDListHyperLink = hyperlink;
      return lrdListTableLine;
    }
    
    /// <summary>
    /// Связывание сотрудника и списка ЛНА
    /// </summary>
    /// <param name="employeeLrdLists">Изначальный список.</param>
    /// <param name="participantsFromLrdList">Список участников ознакомления.</param>
    /// <param name="listLNAName">Список ЛНА.</param>
    /// <returns>Связанный список участников ознакомления и списка ЛНА.</returns>
    public Dictionary<int, System.Collections.Generic.List<string>> GetEmployeeLRDLists(Dictionary<int, System.Collections.Generic.List<string>> employeeLrdLists, List<Sungero.CoreEntities.IRecipient> participantsFromLrdList, string listLNAName)
    {
      foreach (var participant in participantsFromLrdList)
      {
        if (employeeLrdLists.Keys.Contains(participant.Id))
          employeeLrdLists[participant.Id].Add(listLNAName);
        else
          employeeLrdLists.Add(participant.Id, new List<string>() { listLNAName });
      }
      return employeeLrdLists;
    }

  }
}