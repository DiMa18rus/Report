
// ==================================================================
// EmployeeReport.g.cs
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
  public class EmployeeReport : global::Sungero.Reporting.Client.Report, global::Sungero.ClassModul.IEmployeeReport
  {
    public static readonly new global::System.Guid ClassTypeGuid = new global::System.Guid("8daef6e5-f61e-429a-b058-a2d81ace873d");

    protected override global::System.Guid ReportTypeId
    {
      get { return ClassTypeGuid; }
    }



    public global::System.Nullable<global::System.DateTime> ReportDate
    {
      get
      {
          return this.GetParameterValue("ReportDate") as global::System.Nullable<global::System.DateTime>;
      }

      set
      {
        this.SetParameterValue("ReportDate", value);
      }
    }

    public global::System.Nullable<global::System.Boolean> NoConnect
    {
      get
      {
          return this.GetParameterValue("NoConnect") as global::System.Nullable<global::System.Boolean>;
      }

      set
      {
        this.SetParameterValue("NoConnect", value);
      }
    }

    public global::System.Nullable<global::System.Int32> CountCompany
    {
      get
      {
          return this.GetParameterValue("CountCompany") as global::System.Nullable<global::System.Int32>;
      }

      set
      {
        this.SetParameterValue("CountCompany", value);
      }
    }

    public global::System.Nullable<global::System.Int32> CountDepartment
    {
      get
      {
          return this.GetParameterValue("CountDepartment") as global::System.Nullable<global::System.Int32>;
      }

      set
      {
        this.SetParameterValue("CountDepartment", value);
      }
    }

    public global::System.String DepartmentName
    {
      get
      {
          return this.GetParameterValue("DepartmentName") as global::System.String;
      }

      set
      {
        this.SetParameterValue("DepartmentName", value);
      }
    }

    public global::System.Nullable<global::System.Int32> MaxCountEmployee
    {
      get
      {
          return this.GetParameterValue("MaxCountEmployee") as global::System.Nullable<global::System.Int32>;
      }

      set
      {
        this.SetParameterValue("MaxCountEmployee", value);
      }
    }

    public global::DirRX.CustomHRSolution.IBusinessUnit BusinessUnit
    {
      get
      {
          return this.GetParameterValue("BusinessUnit") as global::DirRX.CustomHRSolution.IBusinessUnit;
      }

      set
      {
        this.SetParameterValue("BusinessUnit", value);
      }
    }

    public global::DirRX.CustomHRSolution.IDepartment Department
    {
      get
      {
          return this.GetParameterValue("Department") as global::DirRX.CustomHRSolution.IDepartment;
      }

      set
      {
        this.SetParameterValue("Department", value);
      }
    }

    public global::System.Nullable<global::System.Boolean> FilterDepartmentsForBusinessUnits
    {
      get
      {
          return this.GetParameterValue("FilterDepartmentsForBusinessUnits") as global::System.Nullable<global::System.Boolean>;
      }

      set
      {
        this.SetParameterValue("FilterDepartmentsForBusinessUnits", value);
      }
    }

    public global::System.Nullable<global::System.Boolean> FilterEmployeesForBusinessUniit
    {
      get
      {
          return this.GetParameterValue("FilterEmployeesForBusinessUniit") as global::System.Nullable<global::System.Boolean>;
      }

      set
      {
        this.SetParameterValue("FilterEmployeesForBusinessUniit", value);
      }
    }

    public global::System.Nullable<global::System.Boolean> FilterinEmployeeForDepartment
    {
      get
      {
          return this.GetParameterValue("FilterinEmployeeForDepartment") as global::System.Nullable<global::System.Boolean>;
      }

      set
      {
        this.SetParameterValue("FilterinEmployeeForDepartment", value);
      }
    }


    public EmployeeReport()
    {
      var type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve("Sungero.ClassModul.EmployeeReportClientHandlers");
      this.Handlers = type != null
        ? global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(type, new object[] { this })
        : new global::Sungero.ClassModul.EmployeeReportClientHandlers(this);
    }
  }
}

// ==================================================================
// EmployeeReportRepositoryImplementer.g.cs
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
  public class EmployeeReportRepositoryImplementer<T> : 
      global::Sungero.Reporting.Client.ReportRepositoryImplementer<T>,
      global::Sungero.ClassModul.IEmployeeReportRepositoryImplementer<T>
      where T : global::Sungero.ClassModul.IEmployeeReport
    {
    }
}
