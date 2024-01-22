namespace Sungero.ClassModul.Structures.TrainingReportAcquaintanceAssignedParticipantsList
{
  [global::System.Serializable]
  public partial class LRDListTableLine : global::Sungero.Domain.Shared.ISimpleAppliedStructure
  {

    public static LRDListTableLine Create()
    {
      return new LRDListTableLine();
    }

    public static LRDListTableLine Create(global::System.String reportSessionId, global::System.String lRDListName, global::System.String lRDListHyperLink)
    {
      return new LRDListTableLine
      {
        ReportSessionId = reportSessionId,
        LRDListName = lRDListName,
        LRDListHyperLink = lRDListHyperLink
      };
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((this.ReportSessionId != null ? this.ReportSessionId.GetHashCode() : 0) * 199) ^ ((this.LRDListName != null ? this.LRDListName.GetHashCode() : 0) * 199) ^ ((this.LRDListHyperLink != null ? this.LRDListHyperLink.GetHashCode() : 0) * 199);
      }
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((LRDListTableLine)obj);
    }

    public static bool operator ==(LRDListTableLine left, LRDListTableLine right)
    {
      if (ReferenceEquals(left, right))
        return true;

      if (((object)left) == null || ((object)right) == null)
        return false;

      return left.Equals(right);
    }

    public static bool operator !=(LRDListTableLine left, LRDListTableLine right)
    {
      return !(left == right);
    }

    protected bool Equals(LRDListTableLine other)
    {
      return object.Equals(this.ReportSessionId, other.ReportSessionId) 
             && object.Equals(this.LRDListName, other.LRDListName) 
             && object.Equals(this.LRDListHyperLink, other.LRDListHyperLink) ;
    }

  }

  [global::System.Serializable]
  public partial class TableLine : global::Sungero.Domain.Shared.ISimpleAppliedStructure
  {

    public static TableLine Create()
    {
      return new TableLine();
    }

    public static TableLine Create(global::System.String reportSessionId, global::System.String fullName, global::System.String personnelNumber, global::System.String consent, global::System.String jobTitle, global::System.String jobTitleId, global::System.String typicalPosition, global::System.String typicalPositionId, global::System.String department, global::System.String lRDListNames)
    {
      return new TableLine
      {
        ReportSessionId = reportSessionId,
        FullName = fullName,
        PersonnelNumber = personnelNumber,
        Consent = consent,
        JobTitle = jobTitle,
        JobTitleId = jobTitleId,
        TypicalPosition = typicalPosition,
        TypicalPositionId = typicalPositionId,
        Department = department,
        LRDListNames = lRDListNames
      };
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((this.ReportSessionId != null ? this.ReportSessionId.GetHashCode() : 0) * 199) ^ ((this.FullName != null ? this.FullName.GetHashCode() : 0) * 199) ^ ((this.PersonnelNumber != null ? this.PersonnelNumber.GetHashCode() : 0) * 199) ^ ((this.Consent != null ? this.Consent.GetHashCode() : 0) * 199) ^ ((this.JobTitle != null ? this.JobTitle.GetHashCode() : 0) * 199) ^ ((this.JobTitleId != null ? this.JobTitleId.GetHashCode() : 0) * 199) ^ ((this.TypicalPosition != null ? this.TypicalPosition.GetHashCode() : 0) * 199) ^ ((this.TypicalPositionId != null ? this.TypicalPositionId.GetHashCode() : 0) * 199) ^ ((this.Department != null ? this.Department.GetHashCode() : 0) * 199) ^ ((this.LRDListNames != null ? this.LRDListNames.GetHashCode() : 0) * 199);
      }
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((TableLine)obj);
    }

    public static bool operator ==(TableLine left, TableLine right)
    {
      if (ReferenceEquals(left, right))
        return true;

      if (((object)left) == null || ((object)right) == null)
        return false;

      return left.Equals(right);
    }

    public static bool operator !=(TableLine left, TableLine right)
    {
      return !(left == right);
    }

    protected bool Equals(TableLine other)
    {
      return object.Equals(this.ReportSessionId, other.ReportSessionId) 
             && object.Equals(this.FullName, other.FullName) 
             && object.Equals(this.PersonnelNumber, other.PersonnelNumber) 
             && object.Equals(this.Consent, other.Consent) 
             && object.Equals(this.JobTitle, other.JobTitle) 
             && object.Equals(this.JobTitleId, other.JobTitleId) 
             && object.Equals(this.TypicalPosition, other.TypicalPosition) 
             && object.Equals(this.TypicalPositionId, other.TypicalPositionId) 
             && object.Equals(this.Department, other.Department) 
             && object.Equals(this.LRDListNames, other.LRDListNames) ;
    }

  }
}