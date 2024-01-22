
// ==================================================================
// TrainingReportDocumentsEmployee.g.cs
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
  public class TrainingReportDocumentsEmployee : global::Sungero.Reporting.Client.Report, global::Sungero.ClassModul.ITrainingReportDocumentsEmployee
  {
    public static readonly new global::System.Guid ClassTypeGuid = new global::System.Guid("05052fe5-9c6c-48fe-bad8-b4945c78a296");

    protected override global::System.Guid ReportTypeId
    {
      get { return ClassTypeGuid; }
    }



    public global::System.Nullable<global::System.Int32> EmployeeId
    {
      get
      {
          return this.GetParameterValue("EmployeeId") as global::System.Nullable<global::System.Int32>;
      }

      set
      {
        this.SetParameterValue("EmployeeId", value);
      }
    }

    public global::System.Nullable<global::System.DateTime> DateStart
    {
      get
      {
          return this.GetParameterValue("DateStart") as global::System.Nullable<global::System.DateTime>;
      }

      set
      {
        this.SetParameterValue("DateStart", value);
      }
    }

    public global::System.Nullable<global::System.DateTime> DateEnd
    {
      get
      {
          return this.GetParameterValue("DateEnd") as global::System.Nullable<global::System.DateTime>;
      }

      set
      {
        this.SetParameterValue("DateEnd", value);
      }
    }


    public TrainingReportDocumentsEmployee()
    {
      var type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve("Sungero.ClassModul.TrainingReportDocumentsEmployeeClientHandlers");
      this.Handlers = type != null
        ? global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(type, new object[] { this })
        : new global::Sungero.ClassModul.TrainingReportDocumentsEmployeeClientHandlers(this);
    }
  }
}

// ==================================================================
// TrainingReportDocumentsEmployeeRepositoryImplementer.g.cs
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
  public class TrainingReportDocumentsEmployeeRepositoryImplementer<T> : 
      global::Sungero.Reporting.Client.ReportRepositoryImplementer<T>,
      global::Sungero.ClassModul.ITrainingReportDocumentsEmployeeRepositoryImplementer<T>
      where T : global::Sungero.ClassModul.ITrainingReportDocumentsEmployee
    {
    }
}
