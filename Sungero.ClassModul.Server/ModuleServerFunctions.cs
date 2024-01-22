using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using System.IO;
using PdfConverter;

namespace Sungero.ClassModul.Server
{
  public class ModuleFunctions
  {
    
    /// <summary>
    //Конвертирование документа в Pdf
    [Remote(IsPure = true), Public]
    public string ConvertDocToPdf(Sungero.Docflow.IInternalDocumentBase document)
    {
      var infoResult = DirRX.HRLite.Structures.Module.СonversionToPdfAResult.Create();
      
      if (!document.HasVersions)
      {
        infoResult.HasErrors = true;
        infoResult.ErrorMessage = Sungero.Docflow.OfficialDocuments.Resources.NoVersionError;
        return infoResult.ErrorMessage;
      }
      
      var version = document.LastVersion;
      using (var pdfaDocumentStream = new System.IO.MemoryStream())
      {
        using (var inputStream = new System.IO.MemoryStream())
        {
          version.Body.Read().CopyTo(inputStream);
          inputStream.Seek((Int64)0, SeekOrigin.Begin);
          try
          {
            // Заполнить параметры конвертации: расширение исходного файла и формат pdf/a.
            var paramsConvert = new PdfConverter.Models.ConvertParameters();
            paramsConvert.FileExtension = version.AssociatedApplication.Extension;
            paramsConvert.TargetFormat = PdfConverter.Models.PdfFormat.PDF_A_1A;
            var converter = new PdfConverter.Converter();
            var logger = new PdfConvertLogger.Wrapper(Sungero.Core.Logger.Error, Sungero.Core.Logger.Debug);
            converter.ConvertToPdfA(inputStream, pdfaDocumentStream, paramsConvert, logger);
            infoResult.IsConverted = true;
          }
          catch (Exception e)
          {
            var errorMesssage = string.Empty;
            if (e is PdfConverter.Exceptions.UnexpectedConverterException)
              errorMesssage = DirRX.HRLite.Resources.UnexpectedConverterException;
            else if (e is PdfConverter.Exceptions.PdfFormatNotSupportedException || e is PdfConverter.Exceptions.DataTypeNotSupportedException)
              errorMesssage = DirRX.HRLite.Resources.FormatNotSupportedException;
            else if (e is PdfConverter.Exceptions.FontNotFoundException)
              errorMesssage = DirRX.HRLite.Resources.FontNotFoundException;
            else
              errorMesssage = e.Message;
            
            infoResult.HasErrors = true;
            infoResult.ErrorMessage = errorMesssage;
          }
        }
        
        // Записать сконвертированный документ в новую версию документа, если не было ошибок при конвертации.
        if (!infoResult.HasErrors && infoResult.IsConverted)
        {
          document.CreateVersionFrom(pdfaDocumentStream, "pdf");
          
          try
          {
            document.Save();
          }
          catch (Exception e)
          {
            Logger.Error(e.Message);
            infoResult.HasErrors = true;
            infoResult.ErrorMessage = e.Message;
          }
        }
        
        pdfaDocumentStream.Close();
      }

      return infoResult.HasErrors || !infoResult.IsConverted ?
        infoResult.ErrorMessage == null ? "Конвертация не удалась" : infoResult.ErrorMessage  : "Конвертация прошла успешно";
    }
    
    //Проверка документа на формат Pdf
    [Remote(IsPure = true), Public]
    public bool ChecktDocForFormatPdf(Sungero.Docflow.IInternalDocumentBase document)
    {
      using (var inputStream = new System.IO.MemoryStream())
      {
        var version = document.LastVersion;
        version.Body.Read().CopyTo(inputStream);
        inputStream.Seek((Int64)0, SeekOrigin.Begin);
        
        return DirRX.HRLite.PublicFunctions.Module.ValidatePdfAFormat(inputStream, version.AssociatedApplication.Extension);
      }
    }
  }
}