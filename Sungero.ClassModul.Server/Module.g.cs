
// ==================================================================
// Module.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
  public partial class ClassModulModule : global::Sungero.Domain.Shared.ModuleBase
  {
    public override global::System.Guid Id
    {
      get { return global::System.Guid.Parse("b8491e9e-084d-4fcb-b33c-1e421f4383d6"); }
    }

    public override string Name
    {
      get { return "Sungero.ClassModul"; }
    }

    public override void RegisterTypes()
    {
      global::Sungero.Domain.Shared.ModuleManager.Instance.Container.RegisterType<global::Sungero.ClassModul.Server.IModuleServerInitializationFunctions, global::Sungero.ClassModul.Server.ModuleServerInitializationFunctions>();



      global::Sungero.Domain.Shared.ModuleManager.Instance.Container.RegisterType<global::Sungero.ClassModul.Server.IModuleServerPublicFunctions, global::Sungero.ClassModul.Server.ModuleServerPublicFunctions>();
      global::Sungero.Domain.Shared.ModuleManager.Instance.Container.RegisterType<global::Sungero.ClassModul.Shared.IModuleSharedPublicFunctions, global::Sungero.ClassModul.Shared.ModuleSharedPublicFunctions>();
    }
  }
}

// ==================================================================
// ModuleHandlers.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
}

// ==================================================================
// ModuleFunctions.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Functions
{
  internal static partial class Module
  {
    /// <redirect project="Sungero.ClassModul.Server" type="Sungero.ClassModul.Server.ModuleFunctions" />
    [global::Sungero.Core.RemoteAttribute(IsPure = true)]
    internal static global::System.String ConvertDocToPdf(global::Sungero.Docflow.IInternalDocumentBase document)
    {
      var __moduleId = new global::System.Guid("b8491e9e-084d-4fcb-b33c-1e421f4383d6");
      var __finalModuleMetadatda = global::Sungero.Metadata.MetadataExtension.GetFinal(global::Sungero.Metadata.Services.MetadataSearcher.FindModuleMetadata(__moduleId) ?? global::Sungero.Metadata.Services.MetadataSearcher.FindLayerModuleMetadata(__moduleId));
      var __funcNamespace = "Server" == "ClientBase" ? __finalModuleMetadatda.ClientNamespace : __finalModuleMetadatda.ServerNamespace;
      var __typeName = __funcNamespace + ".ModuleFunctions, Sungero.ClassModul.Server";
      var __type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve(__typeName);
      if (__type != null)
      {
        var __instance = global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(__type);
        var __methodInfo = __type.GetMethod("ConvertDocToPdf", new global::System.Type[]{typeof(global::Sungero.Docflow.IInternalDocumentBase)});
        return (global::System.String)global::CommonLibrary.ReflectionExtensions.ReflectionInvoke(__methodInfo, __instance, new object[]{document});
      }
      else
      {
        return ((global::Sungero.ClassModul.Server.ModuleFunctions)GetFinalFunctionsContainer(global::Sungero.Metadata.ModuleProjectType.Server, __finalModuleMetadatda)).ConvertDocToPdf(document);
      }
    }
    /// <redirect project="Sungero.ClassModul.Server" type="Sungero.ClassModul.Server.ModuleFunctions" />
    [global::Sungero.Core.RemoteAttribute(IsPure = true)]
    internal static global::System.Boolean ChecktDocForFormatPdf(global::Sungero.Docflow.IInternalDocumentBase document)
    {
      var __moduleId = new global::System.Guid("b8491e9e-084d-4fcb-b33c-1e421f4383d6");
      var __finalModuleMetadatda = global::Sungero.Metadata.MetadataExtension.GetFinal(global::Sungero.Metadata.Services.MetadataSearcher.FindModuleMetadata(__moduleId) ?? global::Sungero.Metadata.Services.MetadataSearcher.FindLayerModuleMetadata(__moduleId));
      var __funcNamespace = "Server" == "ClientBase" ? __finalModuleMetadatda.ClientNamespace : __finalModuleMetadatda.ServerNamespace;
      var __typeName = __funcNamespace + ".ModuleFunctions, Sungero.ClassModul.Server";
      var __type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve(__typeName);
      if (__type != null)
      {
        var __instance = global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(__type);
        var __methodInfo = __type.GetMethod("ChecktDocForFormatPdf", new global::System.Type[]{typeof(global::Sungero.Docflow.IInternalDocumentBase)});
        return (global::System.Boolean)global::CommonLibrary.ReflectionExtensions.ReflectionInvoke(__methodInfo, __instance, new object[]{document});
      }
      else
      {
        return ((global::Sungero.ClassModul.Server.ModuleFunctions)GetFinalFunctionsContainer(global::Sungero.Metadata.ModuleProjectType.Server, __finalModuleMetadatda)).ChecktDocForFormatPdf(document);
      }
    }

    private static object GetFunctionsContainer()
    {
      return new global::Sungero.ClassModul.Server.ModuleFunctions();
    }

    private static object GetFinalFunctionsContainer(global::Sungero.Metadata.ModuleProjectType projectType, global::Sungero.Metadata.ModuleMetadata finalModuleMetadatda)
    {
      var assemblyName = finalModuleMetadatda.GetAssemblyName(projectType);
      var moduleFunctionsType = global::System.Type.GetType(global::System.String.Format("{0}.{1}, {2}", finalModuleMetadatda.FunctionNamespace, "Module", assemblyName));
      var methodInfo = moduleFunctionsType.GetMethod("GetFunctionsContainer", global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Static);
      return global::CommonLibrary.ReflectionExtensions.ReflectionInvoke(methodInfo, null, null);
    }
  }
}

// ==================================================================
// ModuleInitializationInstantiation.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.ModuleInitialization
{
  internal static partial class Module
  {
      /// <redirect project="Sungero.ClassModul.Server" type="Sungero.ClassModul.Server.ModuleInitializer" />
      internal static void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
      {
        var __moduleId = new global::System.Guid("b8491e9e-084d-4fcb-b33c-1e421f4383d6");
        var __finalModuleMetadatda = global::Sungero.Metadata.MetadataExtension.GetFinal(global::Sungero.Metadata.Services.MetadataSearcher.FindModuleMetadata(__moduleId) ?? global::Sungero.Metadata.Services.MetadataSearcher.FindLayerModuleMetadata(__moduleId));
        var __funcNamespace = "Server" == "ClientBase" ? __finalModuleMetadatda.ClientNamespace : __finalModuleMetadatda.ServerNamespace;
        var __typeName = __funcNamespace + ".ModuleFunctions, Sungero.ClassModul.Server";
        var __type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve(__typeName);
        if (__type != null)
        {
          var __instance = global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(__type);
          var __methodInfo = __type.GetMethod("Initializing", new global::System.Type[]{typeof(Sungero.Domain.ModuleInitializingEventArgs)});
      global::CommonLibrary.ReflectionExtensions.ReflectionInvoke(__methodInfo, __instance, new object[]{e});
        }
        else
        {
      ((global::Sungero.ClassModul.Server.ModuleInitializer)GetFinalFunctionsContainer(global::Sungero.Metadata.ModuleProjectType.Server, __finalModuleMetadatda)).Initializing(e);
        }
      }
      /// <redirect project="Sungero.ClassModul.Server" type="Sungero.ClassModul.Server.ModuleInitializer" />
      internal static void CreateReportsTables()
      {
        var __moduleId = new global::System.Guid("b8491e9e-084d-4fcb-b33c-1e421f4383d6");
        var __finalModuleMetadatda = global::Sungero.Metadata.MetadataExtension.GetFinal(global::Sungero.Metadata.Services.MetadataSearcher.FindModuleMetadata(__moduleId) ?? global::Sungero.Metadata.Services.MetadataSearcher.FindLayerModuleMetadata(__moduleId));
        var __funcNamespace = "Server" == "ClientBase" ? __finalModuleMetadatda.ClientNamespace : __finalModuleMetadatda.ServerNamespace;
        var __typeName = __funcNamespace + ".ModuleFunctions, Sungero.ClassModul.Server";
        var __type = global::Sungero.Metadata.Services.AppliedTypesManager.Instance.Resolve(__typeName);
        if (__type != null)
        {
          var __instance = global::Sungero.Metadata.Services.AppliedTypesManager.CreateTypeInstance(__type);
          var __methodInfo = __type.GetMethod("CreateReportsTables", global::System.Array.Empty<global::System.Type>());
      global::CommonLibrary.ReflectionExtensions.ReflectionInvoke(__methodInfo, __instance, null);
        }
        else
        {
      ((global::Sungero.ClassModul.Server.ModuleInitializer)GetFinalFunctionsContainer(global::Sungero.Metadata.ModuleProjectType.Server, __finalModuleMetadatda)).CreateReportsTables();
        }
      }


    private static object GetFunctionsContainer()
    {
      return new global::Sungero.ClassModul.Server.ModuleInitializer();
    }

    private static object GetFinalFunctionsContainer(global::Sungero.Metadata.ModuleProjectType projectType, global::Sungero.Metadata.ModuleMetadata finalModuleMetadatda)
    {
      var assemblyName = finalModuleMetadatda.GetAssemblyName(projectType);
      var moduleFunctionsType = global::System.Type.GetType(global::System.String.Format("{0}.{1}, {2}", finalModuleMetadatda.ModuleInitializationNamespace, "Module", assemblyName));
      var methodInfo = moduleFunctionsType.GetMethod("GetFunctionsContainer", global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Static);
      return global::CommonLibrary.ReflectionExtensions.ReflectionInvoke(methodInfo, null, null);
    }

  }
}


// ==================================================================
// ModuleEventArgs.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
}

// ==================================================================
// ModuleServerPublicFunctions.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
  public partial class ModuleServerPublicFunctions : global::Sungero.ClassModul.Server.IModuleServerPublicFunctions
  {
  }
}

namespace Sungero.ClassModul.Server
{
  public partial class ModuleServerPublicFunctions : global::Sungero.ClassModul.Server.IModuleServerPublicFunctions
  {

  }
}

// ==================================================================
// ModuleServerInitializationFunctions.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
  public partial class ModuleServerInitializationFunctions : global::Sungero.ClassModul.Server.IModuleServerInitializationFunctions
  {
  }
}


// ==================================================================
// ModuleWidgetHandlers.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
}

// ==================================================================
// ModuleBlockHandlers.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server.ClassModulBlocks
{
}

namespace Sungero.Workflow
{
}

// ==================================================================
// ModuleQueries.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Queries
{
  public class Module
  {
    private static global::Sungero.Domain.SqlQueryResolver resolver = new global::Sungero.Domain.SqlQueryResolver("Sungero.ClassModul.Server.ModuleQueries.xml", System.Reflection.Assembly.GetExecutingAssembly());
  }
}

// ==================================================================
// ModuleInitializer.g.cs
// ==================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sungero.ClassModul.Server
{
  public partial class ModuleInitializer : global::Sungero.Domain.AppliedModuleInitializer
  {
  }
}

