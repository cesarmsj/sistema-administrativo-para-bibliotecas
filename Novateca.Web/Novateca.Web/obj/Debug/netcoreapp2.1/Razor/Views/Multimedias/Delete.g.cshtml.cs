#pragma checksum "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ccbd37e5c0ab3e4f7467f0028ddd36dec4bd839"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Multimedias_Delete), @"mvc.1.0.view", @"/Views/Multimedias/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Multimedias/Delete.cshtml", typeof(AspNetCore.Views_Multimedias_Delete))]
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
#line 1 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\_ViewImports.cshtml"
using Novateca.Web;

#line default
#line hidden
#line 3 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\_ViewImports.cshtml"
using Novateca.Web.Models;

#line default
#line hidden
#line 4 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\_ViewImports.cshtml"
using Novateca.Web.Models.AccountViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ccbd37e5c0ab3e4f7467f0028ddd36dec4bd839", @"/Views/Multimedias/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54e134d16ee1eff6868b6c84b1f6af932186d464", @"/Views/_ViewImports.cshtml")]
    public class Views_Multimedias_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Novateca.Web.Models.Multimedia>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_UserPagesLayout.cshtml";

#line default
#line hidden
            BeginContext(139, 171, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Multimedia</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(311, 45, false);
#line 16 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TitleMain));

#line default
#line hidden
            EndContext();
            BeginContext(356, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(400, 41, false);
#line 19 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TitleMain));

#line default
#line hidden
            EndContext();
            BeginContext(441, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(485, 39, false);
#line 22 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DGM));

#line default
#line hidden
            EndContext();
            BeginContext(524, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(568, 35, false);
#line 25 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DGM));

#line default
#line hidden
            EndContext();
            BeginContext(603, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(647, 44, false);
#line 28 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SubTitle));

#line default
#line hidden
            EndContext();
            BeginContext(691, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(735, 40, false);
#line 31 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SubTitle));

#line default
#line hidden
            EndContext();
            BeginContext(775, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(819, 44, false);
#line 34 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Director));

#line default
#line hidden
            EndContext();
            BeginContext(863, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(907, 40, false);
#line 37 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Director));

#line default
#line hidden
            EndContext();
            BeginContext(947, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(991, 54, false);
#line 40 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PlaceOfPublication));

#line default
#line hidden
            EndContext();
            BeginContext(1045, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1089, 50, false);
#line 43 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PlaceOfPublication));

#line default
#line hidden
            EndContext();
            BeginContext(1139, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1183, 53, false);
#line 46 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PublishingCompany));

#line default
#line hidden
            EndContext();
            BeginContext(1236, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1280, 49, false);
#line 49 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PublishingCompany));

#line default
#line hidden
            EndContext();
            BeginContext(1329, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1373, 53, false);
#line 52 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.YearOfPublication));

#line default
#line hidden
            EndContext();
            BeginContext(1426, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1470, 49, false);
#line 55 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.YearOfPublication));

#line default
#line hidden
            EndContext();
            BeginContext(1519, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1563, 55, false);
#line 58 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PhysicalDescription));

#line default
#line hidden
            EndContext();
            BeginContext(1618, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1662, 51, false);
#line 61 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PhysicalDescription));

#line default
#line hidden
            EndContext();
            BeginContext(1713, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1757, 53, false);
#line 64 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MultimediaSubject));

#line default
#line hidden
            EndContext();
            BeginContext(1810, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1854, 49, false);
#line 67 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MultimediaSubject));

#line default
#line hidden
            EndContext();
            BeginContext(1903, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1947, 44, false);
#line 70 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Abstract));

#line default
#line hidden
            EndContext();
            BeginContext(1991, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2035, 40, false);
#line 73 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Abstract));

#line default
#line hidden
            EndContext();
            BeginContext(2075, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2119, 54, false);
#line 76 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.NoteOfParticipants));

#line default
#line hidden
            EndContext();
            BeginContext(2173, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2217, 50, false);
#line 79 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.NoteOfParticipants));

#line default
#line hidden
            EndContext();
            BeginContext(2267, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2311, 50, false);
#line 82 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TargetAudience));

#line default
#line hidden
            EndContext();
            BeginContext(2361, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2405, 46, false);
#line 85 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TargetAudience));

#line default
#line hidden
            EndContext();
            BeginContext(2451, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2495, 44, false);
#line 88 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Language));

#line default
#line hidden
            EndContext();
            BeginContext(2539, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2583, 40, false);
#line 91 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Language));

#line default
#line hidden
            EndContext();
            BeginContext(2623, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2667, 44, false);
#line 94 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.URLImage));

#line default
#line hidden
            EndContext();
            BeginContext(2711, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2755, 40, false);
#line 97 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
       Write(Html.DisplayFor(model => model.URLImage));

#line default
#line hidden
            EndContext();
            BeginContext(2795, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2833, 217, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "10fb23a824eb420091b3087cae1fd95c", async() => {
                BeginContext(2859, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2869, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a8aab2ae9c7c46be9fabe14303a9fe44", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 102 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\Multimedias\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.MultimediaID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2915, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(2999, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ba5413fb71140869af0dcb48a1dc709", async() => {
                    BeginContext(3021, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
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
                EndContext();
                BeginContext(3037, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3050, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Novateca.Web.Models.Multimedia> Html { get; private set; }
    }
}
#pragma warning restore 1591
