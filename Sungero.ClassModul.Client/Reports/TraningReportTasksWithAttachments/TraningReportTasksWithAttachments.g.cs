
// ==================================================================
// TraningReportTasksWithAttachments.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Client
{
  public class TraningReportTasksWithAttachments : global::Sungero.Reporting.Client.Report, global::Sungero.ClassModul.ITraningReportTasksWithAttachments
  {
    public static readonly new global::System.Guid ClassTypeGuid = new global::System.Guid("842ccc2e-1129-495e-afa0-59171d4d37ae");

    protected override global::System.Guid ReportTypeId
    {
      get { return ClassTypeGuid; }
    }



    public global::System.Nullable<global::System.DateTime> StartDate
    {
      get
      {
          return this.GetParameterValue("StartDate") as global::System.Nullable<global::System.DateTime>;
      }

      set
      {
        this.SetParameterValue("StartDate", value);
      }
    }

    public global::System.Nullable<global::System.DateTime> EndDate
    {
      get
      {
          return this.GetParameterValue("EndDate") as global::System.Nullable<global::System.DateTime>;
      }

      set
      {
        this.SetParameterValue("EndDate", value);
      }
    }


    public TraningReportTasksWithAttachments()
    {
      var type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve("Sungero.ClassModul.TraningReportTasksWithAttachmentsClientHandlers");
      this.Handlers = type != null
        ? global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(type, new object[] { this })
        : new global::Sungero.ClassModul.TraningReportTasksWithAttachmentsClientHandlers(this);
    }
  }
}

// ==================================================================
// TraningReportTasksWithAttachmentsRepositoryImplementer.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Client
{ 
  public class TraningReportTasksWithAttachmentsRepositoryImplementer<T> : 
      global::Sungero.Reporting.Client.ReportRepositoryImplementer<T>,
      global::Sungero.ClassModul.ITraningReportTasksWithAttachmentsRepositoryImplementer<T>
      where T : global::Sungero.ClassModul.ITraningReportTasksWithAttachments
    {
    }
}