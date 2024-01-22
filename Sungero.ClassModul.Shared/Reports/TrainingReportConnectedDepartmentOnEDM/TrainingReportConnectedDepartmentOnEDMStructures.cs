using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul.Structures.TrainingReportConnectedDepartmentOnEDM
{
  partial class Department
  {
    public string ReportSessionId { get; set; }
    
    /// <summary>
    /// Наша организация.
    /// </summary>
    public string BusinessUnit { get; set; }
    
    /// <summary>
    /// Категория РП.
    /// </summary>
    public string AeraType { get; set; }
    
    /// <summary>
    /// Дивизион.
    /// </summary>
    public string Division { get; set; }
    
    /// <summary>
    /// Регион.
    /// </summary>
    public string Region { get; set; }
    
    /// <summary>
    /// Кластер.
    /// </summary>
    public string Cluster { get; set; }
    
    /// <summary>
    /// Код РП.
    /// </summary>
    public string Cod { get; set; }
    
    /// Численность подразделения.
    /// </summary>
    public int CountEmployeeOnDepartment { get; set; }
    
    /// Дали согласие на КЭДО количество.
    /// </summary>
    public int CountEmployeeAgreedToEDM { get; set; }
    
    /// Дали согласие на КЭДО проценты.
    /// </summary>
    public int PercentEmployeeAgreedToEDM { get; set; }
    
    /// Имеют действующий УНЭП количество.
    /// </summary>
    public int CountEmployeeToValidSignature { get; set; }
    
    /// Имеют действующий УНЭП проценты.
    /// </summary>
    public int PercentEmployeeToValidSignature { get; set; }
  }
}