#pragma checksum "D:\Meus Documentos\Seletivo Aiko\teste-backend-v2\teste-backend-v2\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "654fb82d5ccdd5df8e85e4d3c30597a9179b407f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Meus Documentos\Seletivo Aiko\teste-backend-v2\teste-backend-v2\Views\_ViewImports.cshtml"
using teste_backend_v2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Meus Documentos\Seletivo Aiko\teste-backend-v2\teste-backend-v2\Views\_ViewImports.cshtml"
using teste_backend_v2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"654fb82d5ccdd5df8e85e4d3c30597a9179b407f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7ef0b9658ed18b59156a0cb566c92d83ee404a8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/aiko.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Meus Documentos\Seletivo Aiko\teste-backend-v2\teste-backend-v2\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div className=\"infoSecao\" style=\"text-align: -webkit-center;\">\r\n                \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "654fb82d5ccdd5df8e85e4d3c30597a9179b407f3798", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    
    <table className=""table"" style=""margin-top: 100px;"">
        <tbody>
            <tr className=""itemLista"" style=""display: flex; justify-content: space-between; padding-left: 25%; padding-right: 25%;"">
                <td className=""blocoLista"" style=""display: block; width: 460px; border: 0px !important;"">
                    <p style=""font-size: 100px; text-align: center; display: flex; justify-content: center;"">
                        <i class=""fas fa-tractor""></i>
                    </p>
                    <p style=""display: flex; justify-content: center; text-align: center;"">
                        This application allows the user to list, include, edit and delete some entities, such as Equipment, Equipment Model and Equipment State.
                    </p>
                </td>
                <td className=""blocoLista"" style=""display: block; width: 460px; border: 0px !important;"">
                    <p style=""font-size: 100px; text-align: center; display: flex; justify-cont");
            WriteLiteral(@"ent: center;"">
                        <i class=""fas fa-map-marked-alt""></i>
                    </p>
                    <p style=""display: flex; justify-content: center; text-align: center;"">
                        You can check the last position per equipment through an interactive map.
                    </p>
                </td>
            </tr>
            <tr className=""itemLista"" style=""display: flex; justify-content: space-between; padding-left: 25%; padding-right: 25%;"">
                <td className=""blocoLista"" style=""display: block; width: 460px; border: 0px !important;"">
                    <p style=""font-size: 100px; text-align: center; display: flex; justify-content: center;"">
                         <i class=""fas fa-history""></i>     
                    </p>
                    <p style=""display: flex; justify-content: center; text-align: center;"">                                
                        You can check the history containing the state of a specific equipment");
            WriteLiteral(@" or check the latest state of each equipment.
                    </p>
                </td>
                <td className=""blocoLista"" style=""display: block; width: 460px; border: 0px !important;"">
                    <p style=""font-size: 100px; text-align: center; display: flex; justify-content: center;"">
                        <i class=""fas fa-user""></i>
                    </p>
                    <p style=""display: flex; justify-content: center; text-align: center;"">
                        This application is part of Aiko's selection process and was developed by candidate Bruno Rocha Gomes.
                    </p>
                </td>
            </tr>
        </tbody>
    </table>                
</div>

<style>
  body{ background-color: azure;}
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
