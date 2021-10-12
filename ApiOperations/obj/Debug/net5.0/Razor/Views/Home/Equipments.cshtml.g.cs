#pragma checksum "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72641911332b2282ef6765238f9901b4ee2aaa23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Equipments), @"mvc.1.0.view", @"/Views/Home/Equipments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72641911332b2282ef6765238f9901b4ee2aaa23", @"/Views/Home/Equipments.cshtml")]
    public class Views_Home_Equipments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72641911332b2282ef6765238f9901b4ee2aaa232740", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"" crossorigin=""anonymous"">
    <title>Equipments</title>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72641911332b2282ef6765238f9901b4ee2aaa234068", async() => {
                WriteLiteral(@"
    <div class=""container-fluid padding-bottom"">
        <div class=""card shadow"">
            <div class=""card-header py-3"">
                <p class=""text-secondary m-0 font-weight-bold"">
                    <h4>
                        <i class=""fas fa-mountain mr-2""></i> Equipments
                    </h4>
                </p>
            </div>
            <div class=""card-body"">
                <table class=""table table-striped table-bordered table-hover"" id=""myTable"">
                    <thead>
                        <tr>
                            <th class=""text-center"" scope=""col"">Model</th>
                            <th class=""text-center"" scope=""col"">Name</th>
                            <th class=""text-center"" scope=""col"">Action</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 29 "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml"
                         foreach (var item in ViewBag.Equipments)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 32 "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml"
                                               Write(item.Model);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"text-center\">");
#nullable restore
#line 33 "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml"
                                               Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td class=\"col-3 text-center\">\r\n                                <a class=\"btn btn-info btn-sm\"");
                BeginWriteAttribute("href", " href=\"", 1663, "\"", 1699, 2);
                WriteAttributeValue("", 1670, "Home/ViewPositions/", 1670, 19, true);
#nullable restore
#line 35 "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml"
WriteAttributeValue("", 1689, item.Name, 1689, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><i class=\"fas fa-map-marked-alt mr-2\"></i> Positions</a>\r\n                                <a class=\"btn btn-info btn-sm\"");
                BeginWriteAttribute("href", " href=\"", 1821, "\"", 1854, 2);
                WriteAttributeValue("", 1828, "Home/ViewStates/", 1828, 16, true);
#nullable restore
#line 36 "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml"
WriteAttributeValue("", 1844, item.Name, 1844, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><i class=\"fas fa-satellite-dish mr-2\"></i> States</a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 39 "C:\Users\Marcelo\Git\teste-backend-v2\ApiOperations\Views\Home\Equipments.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <script src=""https://kit.fontawesome.com/e2b4562c40.js"" crossorigin=""anonymous""></script>
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"" crossorigin=""anonymous""></script>

    <script src=""//code.jquery.com/jquery-3.5.1.js""></script>
    <script src=""//cdn.datatables.net/1.11.1/js/jquery.dataTables.min.js""></script>
    <script src=""//cdn.datatables.net/1.11.1/js/dataTables.bootstrap4.min.js""></script>
    <script src=""//cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""//cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""//cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src=""//cdn.datatables.net/buttons/2.0.0/js/dataTables.buttons.min.js""></script>
    <scr");
                WriteLiteral(@"ipt src=""//cdn.datatables.net/buttons/2.0.0/js/buttons.bootstrap4.min.js""></script>
    <script src=""//cdn.datatables.net/buttons/2.0.0/js/buttons.html5.min.js""></script>
    <script src=""//cdn.datatables.net/buttons/2.0.0/js/buttons.print.min.js""></script>
    <script src=""//cdn.datatables.net/buttons/2.0.0/js/buttons.colVis.min.js""></script>
    <script src=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>
    <script src=""//cdn.datatables.net/responsive/2.2.9/js/dataTables.responsive.min.js""></script>
    <script src=""//cdn.datatables.net/responsive/2.2.9/js/responsive.bootstrap.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#myTable').DataTable({
                ""order"": [[1, ""asc""]],
                ""language"": {
                    ""lengthMenu"": ""Mostrando _MENU_ registros por página"",
                    ""zeroRecords"": ""Nada encontrado"",
                    ""info"": ""Mostrando página _PAGE_ de _PAGES_"",
                    ""in");
                WriteLiteral(@"foEmpty"": ""Nenhum registro disponível"",
                    ""infoFiltered"": ""(filtrado de _MAX_ registros no total)""
                },
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });</script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n");
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
