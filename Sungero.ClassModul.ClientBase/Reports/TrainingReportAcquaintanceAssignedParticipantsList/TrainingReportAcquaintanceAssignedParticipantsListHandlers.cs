using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TrainingReportAcquaintanceAssignedParticipantsListClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      {
        var dialog = Dialogs.CreateInputDialog("Выбирете документ ЛНА или список ЛНА");
        var document = dialog.AddSelect("Документы ЛНА", false, DirRX.HRLite.LocalRegulationDocuments.Null);
        var listLNA = dialog.AddSelect("Списки ЛНА", false, DirRX.CustomHRSolution.ListsLNAForRecruitmentAndTransfers.Null);
        
        listLNA.SetOnValueChanged((arg) =>
                                  {
                                    if (document.Value != null && arg.NewValue != null)
                                      document.Value = DirRX.HRLite.LocalRegulationDocuments.Null;
                                    else
                                      return;
                                  });
        
        document.SetOnValueChanged((arg) =>
                                   {
                                     if (listLNA.Value != null && arg.NewValue != null)
                                       listLNA.Value = DirRX.CustomHRSolution.ListsLNAForRecruitmentAndTransfers.Null;
                                     else
                                       return;
                                   });
        
        if (dialog.Show() == DialogButtons.Ok)
        {
          if (listLNA != null)
            TrainingReportAcquaintanceAssignedParticipantsList.ListLNA = listLNA.Value;
          
          if (document != null)
            TrainingReportAcquaintanceAssignedParticipantsList.Document = DirRX.LRD.LocalRegulationDocuments.As(document.Value);
        }
        else
          e.Cancel = true;
      }
    }
  }
}