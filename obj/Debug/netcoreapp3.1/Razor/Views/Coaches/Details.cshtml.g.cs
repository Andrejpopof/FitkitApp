#pragma checksum "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40d52be9ab2252da0d761d8ef9d686fb1506d365"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Coaches_Details), @"mvc.1.0.view", @"/Views/Coaches/Details.cshtml")]
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
#line 1 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\_ViewImports.cshtml"
using FitKitApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\_ViewImports.cshtml"
using FitKitApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40d52be9ab2252da0d761d8ef9d686fb1506d365", @"/Views/Coaches/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba0db5010d50098b752670dc20a1435b0c4cdfb6", @"/Views/_ViewImports.cshtml")]
    public class Views_Coaches_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FitKitApp.Models.Coach>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h1>Детали за тренер:  ");
#nullable restore
#line 7 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
                      Write(Html.DisplayFor(model => model.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 7 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
                                                            Write(Html.DisplayFor(model => model.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Visina));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.Visina));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Tezina));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.Tezina));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Plata));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.Plata));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EducationLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
       Write(Html.DisplayFor(model => model.EducationLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Објекти\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 64 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
             foreach (var objekt in Model.Objekti1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p style=\"color:purple\"><b>");
#nullable restore
#line 66 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
                                      Write(objekt.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n");
#nullable restore
#line 67 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
             foreach (var objekt2 in Model.Objekti2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p style=\"color:purple\"><b>");
#nullable restore
#line 70 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
                                      Write(objekt2.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n");
#nullable restore
#line 71 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n      \r\n\r\n\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40d52be9ab2252da0d761d8ef9d686fb1506d36510799", async() => {
                WriteLiteral("Промени");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\Andrej\Desktop\poslednov2\FitkitApp\Views\Coaches\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40d52be9ab2252da0d761d8ef9d686fb1506d36512939", async() => {
                WriteLiteral("Назад");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FitKitApp.Models.Coach> Html { get; private set; }
    }
}
#pragma warning restore 1591
