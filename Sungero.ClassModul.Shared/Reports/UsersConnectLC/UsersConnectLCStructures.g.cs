namespace Sungero.ClassModul.Structures.UsersConnectLC
{
  [global::System.Serializable]
  public partial class TableDepartment : global::Sungero.Domain.Shared.ISimpleAppliedStructure
  {

    public static TableDepartment Create()
    {
      return new TableDepartment();
    }

    public static TableDepartment Create(global::System.String name, global::System.Int32 countEmployee)
    {
      return new TableDepartment
      {
        Name = name,
        CountEmployee = countEmployee
      };
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((this.Name != null ? this.Name.GetHashCode() : 0) * 199) ^ (this.CountEmployee.GetHashCode() * 199);
      }
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((TableDepartment)obj);
    }

    public static bool operator ==(TableDepartment left, TableDepartment right)
    {
      if (ReferenceEquals(left, right))
        return true;

      if (((object)left) == null || ((object)right) == null)
        return false;

      return left.Equals(right);
    }

    public static bool operator !=(TableDepartment left, TableDepartment right)
    {
      return !(left == right);
    }

    protected bool Equals(TableDepartment other)
    {
      return object.Equals(this.Name, other.Name) 
             && this.CountEmployee == other.CountEmployee;
    }

  }
}