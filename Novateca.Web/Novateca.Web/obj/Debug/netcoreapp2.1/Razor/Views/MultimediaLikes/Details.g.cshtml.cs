#pragma checksum "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50985daa28f33f3998375181c06ab7ce247ca073"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MultimediaLikes_Details), @"mvc.1.0.view", @"/Views/MultimediaLikes/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MultimediaLikes/Details.cshtml", typeof(AspNetCore.Views_MultimediaLikes_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50985daa28f33f3998375181c06ab7ce247ca073", @"/Views/MultimediaLikes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54e134d16ee1eff6868b6c84b1f6af932186d464", @"/Views/_ViewImports.cshtml")]
    public class Views_MultimediaLikes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Novateca.Web.Models.MultimediaLike>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_UserPagesLayout.cshtml";

#line default
#line hidden
            BeginContext(144, 128, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>MultimediaLike</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(273, 51, false);
#line 15 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ApplicationUser));

#line default
#line hidden
            EndContext();
            BeginContext(324, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(368, 57, false);
#line 18 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayFor(model => model.ApplicationUser.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(425, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(469, 46, false);
#line 21 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Multimedia));

#line default
#line hidden
            EndContext();
            BeginContext(515, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(559, 46, false);
#line 24 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Multimedia.DGM));

#line default
#line hidden
            EndContext();
            BeginContext(605, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(649, 44, false);
#line 27 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LikeDate));

#line default
#line hidden
            EndContext();
            BeginContext(693, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(737, 40, false);
#line 30 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayFor(model => model.LikeDate));

#line default
#line hidden
            EndContext();
            BeginContext(777, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(821, 47, false);
#line 33 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LikeEnabled));

#line default
#line hidden
            EndContext();
            BeginContext(868, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(912, 43, false);
#line 36 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
       Write(Html.DisplayFor(model => model.LikeEnabled));

#line default
#line hidden
            EndContext();
            BeginContext(955, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1002, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fbddb106c944423b9f7ba62f9dd1fa5", async() => {
                BeginContext(1062, 4, true);
                WriteLiteral("Edit");
                EndContext();
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
#line 41 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\MultimediaLikes\Details.cshtml"
                           WriteLiteral(Model.MultimediaLikeID);

#line default
#line hidden
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
            EndContext();
            BeginContext(1070, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1078, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d12847a38e7a4c039d64d33d2ff58f1a", async() => {
                BeginContext(1100, 12, true);
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
            BeginContext(1116, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Novateca.Web.Models.MultimediaLike> Html { get; private set; }
    }
}
#pragma warning restore 1591