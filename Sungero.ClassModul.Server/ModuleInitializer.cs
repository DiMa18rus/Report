using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace Sungero.ClassModul.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      CreateReportsTables();
    }
    
    public virtual void CreateReportsTables()
    {
      var trainingReportConnectedDepartmentOnEDMTable = Constants.TrainingReportConnectedDepartmentOnEDM.ConnectedDepartmentOnEDMTable;
      Sungero.Docflow.PublicFunctions.Module.DropReportTempTable(trainingReportConnectedDepartmentOnEDMTable);
      Sungero.Docflow.PublicFunctions.Module.ExecuteSQLCommandFormat(Queries.TrainingReportConnectedDepartmentOnEDM.CreateTableConnectedDepartmentOnEDM, new[] { trainingReportConnectedDepartmentOnEDMTable });
    }
    
  }
}
