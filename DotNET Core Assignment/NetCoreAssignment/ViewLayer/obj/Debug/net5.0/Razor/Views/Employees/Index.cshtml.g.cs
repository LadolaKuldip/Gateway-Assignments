#pragma checksum "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "deb182e36eae47c2834fc00da432155e12260e39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_Index), @"mvc.1.0.view", @"/Views/Employees/Index.cshtml")]
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
#line 1 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\_ViewImports.cshtml"
using ViewLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\_ViewImports.cshtml"
using ViewLayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"deb182e36eae47c2834fc00da432155e12260e39", @"/Views/Employees/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4f4896c3f50b3c39339526fca817eac5a394cc9", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/popup-form.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "deb182e36eae47c2834fc00da432155e12260e394081", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h1>Index</h1>\r\n<p>\r\n    <button id=\"myBtn\" type=\"Submit\" class=\"btn btn-danger\"><i class=\"fas fa-plus\"></i> New</button>    \r\n</p>\r\n<table class=\"table table-hover\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsManager));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Manager));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Department));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsManager));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Manager));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Department.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button type=\"Submit\"");
            BeginWriteAttribute("value", " value=\"", 1989, "\"", 2005, 1);
#nullable restore
#line 64 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
WriteAttributeValue("", 1997, item.Id, 1997, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"Editform btn btn-sm btn-primary\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit Info !\">\r\n                        <i class=\"far fa-edit\"></i>\r\n                    </button>\r\n                    <button type=\"Submit\"");
            BeginWriteAttribute("value", " value=\"", 2237, "\"", 2253, 1);
#nullable restore
#line 67 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
WriteAttributeValue("", 2245, item.Id, 2245, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"Detailsform btn btn-sm btn-success\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View Info !\">\r\n                        <i class=\"fa fa-info\"></i>\r\n                    </button>\r\n                    <button type=\"Submit\"");
            BeginWriteAttribute("value", " value=\"", 2487, "\"", 2503, 1);
#nullable restore
#line 70 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
WriteAttributeValue("", 2495, item.Id, 2495, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"Deleteform btn btn-sm btn-danger\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete Info !\">\r\n                        <i class=\"fa fa-trash\"></i>\r\n                    </button>\r\n");
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 78 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div id=\"myModal\" class=\"modal\" style=\"width:80%;\">\r\n\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\"#myBtn\").click(function (evt) {\r\n                $.get( \'");
#nullable restore
#line 91 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
                   Write(Url.Action("Create", "Employees", new {} ));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', function(data) {
                    $('#myModal').html(data);
                    $('#myModal').css(""display"", ""block"");
                });
            });
            $("".Editform"").click(function (evt) {
                var CatID = $(this).val();
                $.get('");
#nullable restore
#line 98 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
                  Write(Url.Action("Edit", "Employees"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + CatID, function(data) {
                    $('#myModal').html(data);
                    $('#myModal').css(""display"",""block"");
                });
            });
            $("".Deleteform"").click(function (evt) {
                var CatID = $(this).val();
                $.get('");
#nullable restore
#line 105 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
                  Write(Url.Action("Delete", "Employees"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + CatID, function(data) {
                    $('#myModal').html(data);
                    $('#myModal').css(""display"",""block"");
                });
            });
            $("".Detailsform"").click(function (evt) {
                var CatID = $(this).val();
                $.get('");
#nullable restore
#line 112 "C:\Users\kuldip.ladola\source\repos\NetCoreAssignment\ViewLayer\Views\Employees\Index.cshtml"
                  Write(Url.Action("Details", "Employees"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=' + CatID, function(data) {
                    $('#myModal').html(data);
                    $('#myModal').css(""display"",""block"");
                });
            });
        });
    </script>

    <script type=""text/javascript"">
        var modal = document.getElementById(""myModal"");
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = ""none"";
                modal.innerHTML = """";
            }
        }
    </script>
   
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
