namespace Sungero.ClassModul.Structures.TrainingReportConnectedDepartmentOnEDM
{
  [global::System.Serializable]
  public partial class Department : global::Sungero.Domain.Shared.ISimpleAppliedStructure
  {

    public static Department Create()
    {
      return new Department();
    }

    public static Department Create(global::System.String reportSessionId, global::System.String businessUnit, global::System.String aeraType, global::System.String division, global::System.String region, global::System.String cluster, global::System.String cod, global::System.Int32 countEmployeeOnDepartment, global::System.Int32 countEmployeeAgreedToEDM, global::System.Int32 percentEmployeeAgreedToEDM, global::System.Int32 countEmployeeToValidSignature, global::System.Int32 percentEmployeeToValidSignature)
    {
      return new Department
      {
        ReportSessionId = reportSessionId,
        BusinessUnit = businessUnit,
        AeraType = aeraType,
        Division = division,
        Region = region,
        Cluster = cluster,
        Cod = cod,
        CountEmployeeOnDepartment = countEmployeeOnDepartment,
        CountEmployeeAgreedToEDM = countEmployeeAgreedToEDM,
        PercentEmployeeAgreedToEDM = percentEmployeeAgreedToEDM,
        CountEmployeeToValidSignature = countEmployeeToValidSignature,
        PercentEmployeeToValidSignature = percentEmployeeToValidSignature
      };
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((this.ReportSessionId != null ? this.ReportSessionId.GetHashCode() : 0) * 199) ^ ((this.BusinessUnit != null ? this.BusinessUnit.GetHashCode() : 0) * 199) ^ ((this.AeraType != null ? this.AeraType.GetHashCode() : 0) * 199) ^ ((this.Division != null ? this.Division.GetHashCode() : 0) * 199) ^ ((this.Region != null ? this.Region.GetHashCode() : 0) * 199) ^ ((this.Cluster != null ? this.Cluster.GetHashCode() : 0) * 199) ^ ((this.Cod != null ? this.Cod.GetHashCode() : 0) * 199) ^ (this.CountEmployeeOnDepartment.GetHashCode() * 199) ^ (this.CountEmployeeAgreedToEDM.GetHashCode() * 199) ^ (this.PercentEmployeeAgreedToEDM.GetHashCode() * 199) ^ (this.CountEmployeeToValidSignature.GetHashCode() * 199) ^ (this.PercentEmployeeToValidSignature.GetHashCode() * 199);
      }
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Department)obj);
    }

    public static bool operator ==(Department left, Department right)
    {
      if (ReferenceEquals(left, right))
        return true;

      if (((object)left) == null || ((object)right) == null)
        return false;

      return left.Equals(right);
    }

    public static bool operator !=(Department left, Department right)
    {
      return !(left == right);
    }

    protected bool Equals(Department other)
    {
      return object.Equals(this.ReportSessionId, other.ReportSessionId) 
             && object.Equals(this.BusinessUnit, other.BusinessUnit) 
             && object.Equals(this.AeraType, other.AeraType) 
             && object.Equals(this.Division, other.Division) 
             && object.Equals(this.Region, other.Region) 
             && object.Equals(this.Cluster, other.Cluster) 
             && object.Equals(this.Cod, other.Cod) 
             && this.CountEmployeeOnDepartment == other.CountEmployeeOnDepartment
             && this.CountEmployeeAgreedToEDM == other.CountEmployeeAgreedToEDM
             && this.PercentEmployeeAgreedToEDM == other.PercentEmployeeAgreedToEDM
             && this.CountEmployeeToValidSignature == other.CountEmployeeToValidSignature
             && this.PercentEmployeeToValidSignature == other.PercentEmployeeToValidSignature;
    }

  }
}