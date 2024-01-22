using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace Sungero.ClassModul.Structures.TrainingReportAcquaintanceAssignedParticipantsList
{

  /// <summary>
  /// Структура для одной строки из отчета для отображения ссылок на списки ЛНА в отчете.
  /// </summary>
  partial class LRDListTableLine
  {
    /// <summary>
    /// ИД сессии отчета.
    /// </summary>
    public string ReportSessionId { get; set; }
    
    /// <summary>
    /// Имя списка ЛНА.
    /// </summary>
    public string LRDListName { get; set; }
    
    /// <summary>
    /// Ссылка на список ЛНА.
    /// </summary>
    public string LRDListHyperLink { get; set; }
  }

  /// <summary>
  /// Структура для одной строки из отчета для временной таблицы в БД.
  /// </summary>
  partial class TableLine
  {
    /// <summary>
    /// ИД сессии отчета.
    /// </summary>
    public string ReportSessionId { get; set; }
    
    /// <summary>
    /// ФИО сотрудника.
    /// </summary>
    public string FullName { get; set; }
    
    /// <summary>
    /// Табельный номер.
    /// </summary>
    public string PersonnelNumber { get; set; }
    
    /// <summary>
    /// Согласие на КЭДО.
    /// </summary>
    public string Consent { get; set; }
    
    /// <summary>
    /// Штатная должность.
    /// </summary>
    public string JobTitle { get; set; }
    
    /// <summary>
    /// ИД штатной должности.
    /// </summary>
    public string JobTitleId { get; set; }
    
    /// <summary>
    /// Семейство должностей.
    /// </summary>
    public string TypicalPosition { get; set; }
    
    /// <summary>
    /// ИД семейства должностей.
    /// </summary>
    public string TypicalPositionId { get; set; }
    
    /// <summary>
    /// Подразделение.
    /// </summary>
    public string Department { get; set; }
    
    /// <summary>
    /// Имена списков ЛНА.
    /// </summary>
    public string LRDListNames { get; set; }
  }

}