using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TraningReportTasksWithAttachmentsClientHandlers
  {

    public override void BeforeExecute(Sungero.Reporting.Client.BeforeExecuteEventArgs e)
    {
      var dialog = Dialogs.CreateInputDialog("Параметры отчета");
      var startDate = dialog.AddDate("Начальная дата", true, Calendar.Today.AddDays(-180));
      var endDate = dialog.AddDate("Конечная дата", true, Calendar.Today);
      
      if (dialog.Show() != DialogButtons.Ok)
        e.Cancel = true;
      
      TraningReportTasksWithAttachments.StartDate = startDate.Value.Value;
      TraningReportTasksWithAttachments.EndDate = endDate.Value.Value;
    }

  }
}