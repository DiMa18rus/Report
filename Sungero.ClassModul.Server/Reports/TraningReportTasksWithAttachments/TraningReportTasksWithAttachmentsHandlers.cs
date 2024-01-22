using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul
{
  partial class TraningReportTasksWithAttachmentsServerHandlers
  {

    public virtual IQueryable<DirRX.HRSolution.IOfficialDocument> GetDocuments()
    {
      return DirRX.HRSolution.OfficialDocuments.GetAll();
    }

  }
}