#pragma checksum "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71eec140e4bf41367d867806aa0d3f4886cabd5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parametros_Index), @"mvc.1.0.view", @"/Views/Parametros/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\_ViewImports.cshtml"
using CMRmvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\_ViewImports.cshtml"
using CMRmvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71eec140e4bf41367d867806aa0d3f4886cabd5c", @"/Views/Parametros/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e936ccbbd9d9b3bfb663b9da42627a93cb087e41", @"/Views/_ViewImports.cshtml")]
    public class Views_Parametros_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CMRmvc.Models.Parametros>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-myaction", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Crud", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-isreadonly", "false", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Detalles"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-isreadonly", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-myaction", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-myaction", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
  var parType = ViewData["ParamType"];

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
  var menu = (List<MenuItemPadre>)ViewData["Menu"];

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
  
    ViewData["Title"] = "Parametros";
    Layout = "~/Views/Shared/AdminLTE/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"d-flex\">\r\n");
#nullable restore
#line 10 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
     if (menu != null)
    {
        foreach (var padre in menu)
        {
            foreach (var hijo in padre.MenuItemHijo)
            {
                if (hijo.Nombr == "Gestion de Parametros")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"mr-auto p-2\">\r\n");
            WriteLiteral("                        <h4><i");
            BeginWriteAttribute("class", " class=\"", 612, "\"", 631, 1);
#nullable restore
#line 20 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 620, hijo.Icono, 620, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>&nbsp;&nbsp;");
#nullable restore
#line 20 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                                              Write(hijo.Nombr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    </div>\r\n");
#nullable restore
#line 22 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                }
                var ac = hijo.MenuHijoAcciones.FirstOrDefault(x => x.MhaUrl == "Parametros/Create");
                if (ac != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"p-2\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71eec140e4bf41367d867806aa0d3f4886cabd5c8815", async() => {
                WriteLiteral("<i");
                BeginWriteAttribute("class", " class=\"", 995, "\"", 1015, 1);
#nullable restore
#line 27 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 1003, ac.MhaIcono, 1003, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></i>&nbsp;&nbsp;");
#nullable restore
#line 27 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                                                                                                                             Write(ac.MhaTexto);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-myaction", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["myaction"] = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isreadonly"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 29 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                }
            }
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <table id=\"listTable\" class=\"table table-bordered table-hover\">\r\n            <thead>\r\n                <tr>\r\n                    <th>");
#nullable restore
#line 41 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 42 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParClave));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 43 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParValor));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 44 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ParTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 45 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.IdParametroTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>Acciones</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 50 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr");
            BeginWriteAttribute("id", " id=\"", 1868, "\"", 1894, 2);
            WriteAttributeValue("", 1873, "row_", 1873, 4, true);
#nullable restore
#line 52 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 1877, item.IdParametro, 1877, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <td>\r\n                            ");
#nullable restore
#line 54 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParClave));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 60 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParValor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 63 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                             if (item.ParTipo == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a>DATE</a>\r\n");
#nullable restore
#line 66 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                            }
                            else  if(item.ParTipo == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a>INT</a>\r\n");
#nullable restore
#line 70 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                            }
                            else if(item.ParTipo == 3)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a>STRING</a>\r\n");
#nullable restore
#line 74 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 78 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.IdParametroTipoNavigation.TipDescripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <div class=\"btn-group\">\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71eec140e4bf41367d867806aa0d3f4886cabd5c16860", async() => {
                WriteLiteral("\r\n                                    <i class=\"nav-icon fas fa-search\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-isreadonly", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isreadonly"] = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                                                                                                                WriteLiteral(item.IdParametro);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["myaction"] = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 87 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                 if (menu != null)
                                {
                                    foreach (var padre in menu)
                                    {
                                        foreach (var hijo in padre.MenuItemHijo)
                                        {
                                            foreach (var acciones in hijo.MenuHijoAcciones)
                                            {
                                                if (acciones.MhaUrl == "Parametros/Edit")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71eec140e4bf41367d867806aa0d3f4886cabd5c20933", async() => {
                WriteLiteral("\r\n                                                        <i");
                BeginWriteAttribute("class", " class=\"", 4278, "\"", 4304, 1);
#nullable restore
#line 98 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 4286, acciones.MhaIcono, 4286, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></i>\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-isreadonly", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["isreadonly"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                                                                                                                                      WriteLiteral(item.IdParametro);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["myaction"] = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 100 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                                }
                                                if (acciones.MhaUrl == "Parametros/Delete")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <a href=\"#\" class=\"btn btn-danger btn-sm\" title=\"Eliminar\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4675, "\"", 4717, 3);
            WriteAttributeValue("", 4685, "ConfirmDelete(", 4685, 14, true);
#nullable restore
#line 103 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 4699, item.IdParametro, 4699, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4716, ")", 4716, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                        <i");
            BeginWriteAttribute("class", " class=\"", 4779, "\"", 4805, 1);
#nullable restore
#line 104 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
WriteAttributeValue("", 4787, acciones.MhaIcono, 4787, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                                    </a>\r\n");
#nullable restore
#line 106 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                                                }
                                            }
                                        }
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 114 "D:\Soft\CRM\CrmAssist\CMRmvc\Views\Parametros\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </table>
    </div>
</div>
<div class=""modal"" id=""mymodal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Confirmar</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <p>¿Está seguro que desea eliminar el parametro?</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" onclick=""DeleteUser()"" class=""btn btn-danger"">Eliminar</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cancelar</button>
            </div>
        </div>
    </div>
    <input type=""hidden"" id=""userID"" />
</div>

<script>

    var ConfirmDelete = function (userID) {
        ");
            WriteLiteral(@"debugger;
        $(""#userID"").val(userID);
        $(""#mymodal"").modal('show');
    }

    var DeleteUser = function () {
        var userID = $(""#userID"").val();
        debugger;
        $.ajax({
            type: ""POST"",
            url: ""/Parametros/DeleteConfirmed"",
            data: { id: userID },
            success: function () {
                $(""#mymodal"").modal('hide');
                $(""#row_"" + userID).remove();

            }
        });
    }


</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CMRmvc.Models.Parametros>> Html { get; private set; }
    }
}
#pragma warning restore 1591
