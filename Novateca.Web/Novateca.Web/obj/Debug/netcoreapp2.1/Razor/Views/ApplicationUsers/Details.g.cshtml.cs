#pragma checksum "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ec0aca05fd130d5fa41533d0e9e02cccfcf21fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ApplicationUsers_Details), @"mvc.1.0.view", @"/Views/ApplicationUsers/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ApplicationUsers/Details.cshtml", typeof(AspNetCore.Views_ApplicationUsers_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ec0aca05fd130d5fa41533d0e9e02cccfcf21fe", @"/Views/ApplicationUsers/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54e134d16ee1eff6868b6c84b1f6af932186d464", @"/Views/_ViewImports.cshtml")]
    public class Views_ApplicationUsers_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Novateca.Web.Models.ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_UserPagesLayout.cshtml";

#line default
#line hidden
            BeginContext(145, 395, true);
            WriteLiteral(@"<div class=""row"">
    <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center"" style=""background-color:white;"">
        <div class=""col-xs-6 col-sm-6 col-md-6 col-lg-6 text-center"">
            <h2>Dados de cadastro</h2>
            <hr />
            <div>
                <dl class=""dl-horizontal"">
                    <dt>
                    </dt>
                    <dd>
");
            EndContext();
#line 17 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
                          
                            var imgSrc = "/images/users/sem foto.jpg";
                            if (Model.AvatarImage != null)
                            {
                                var base64 = Convert.ToBase64String(Model.AvatarImage);
                                imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                            }
                        

#line default
#line hidden
            BeginContext(972, 28, true);
            WriteLiteral("                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1000, "\"", 1013, 1);
#line 25 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
WriteAttributeValue("", 1006, imgSrc, 1006, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1014, 239, true);
            WriteLiteral(" style=\"width: 200px; height: 200px\" />\r\n                    </dd>\r\n                    <br />\r\n                    <dt>\r\n                        Primeiro nome:\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1254, 41, false);
#line 32 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
                   Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1295, 168, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        Sobrenome:\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1464, 40, false);
#line 38 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
                   Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1504, 29, true);
            WriteLiteral("\r\n                    </dd>\r\n");
            EndContext();
            BeginContext(1952, 135, true);
            WriteLiteral("                    <dt>\r\n                        Email:\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(2088, 37, false);
#line 56 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(2125, 167, true);
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        Telefone:\r\n                    </dt>\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(2293, 43, false);
#line 62 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
                   Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
            EndContext();
            BeginContext(2336, 109, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                </dl>\r\n            </div>\r\n            <div>\r\n                ");
            EndContext();
            BeginContext(2445, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f84dd2400aaa4585a6c4593888c0e8ec", async() => {
                BeginContext(2491, 15, true);
                WriteLiteral("Editar cadastro");
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
#line 68 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
                                       WriteLiteral(Model.Id);

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
            BeginContext(2510, 213, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-xs-6 col-sm-6 col-md-6 col-lg-6 text-center\">\r\n            <h2>Minhas obras favoritas</h2>\r\n            <hr />\r\n            <h3>Livros favoritos</h3>\r\n");
            EndContext();
#line 75 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
             foreach (var favoriteBooks in ViewBag.favoriteBooks)
            {


#line default
#line hidden
            BeginContext(2807, 19, true);
            WriteLiteral("                <p>");
            EndContext();
            BeginContext(2827, 13, false);
#line 78 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
              Write(favoriteBooks);

#line default
#line hidden
            EndContext();
            BeginContext(2840, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 79 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"

            }

#line default
#line hidden
            BeginContext(2863, 44, true);
            WriteLiteral("            <h3>Multimídias favoritas</h3>\r\n");
            EndContext();
#line 82 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
             foreach (var favoriteMultimedias in ViewBag.favoriteMultimedias)
            {


#line default
#line hidden
            BeginContext(3003, 19, true);
            WriteLiteral("                <p>");
            EndContext();
            BeginContext(3023, 19, false);
#line 85 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
              Write(favoriteMultimedias);

#line default
#line hidden
            EndContext();
            BeginContext(3042, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 86 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"

            }

#line default
#line hidden
            BeginContext(3065, 33, true);
            WriteLiteral("            <h3>Periódicos</h3>\r\n");
            EndContext();
#line 89 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
             foreach (var favoriteNewspapers in ViewBag.favoriteNewspaper)
            {


#line default
#line hidden
            BeginContext(3191, 19, true);
            WriteLiteral("                <p>");
            EndContext();
            BeginContext(3211, 18, false);
#line 92 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"
              Write(favoriteNewspapers);

#line default
#line hidden
            EndContext();
            BeginContext(3229, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 93 "C:\Users\cesar\Documents\GitHub\Novateca\Novateca.Web\Novateca.Web\Views\ApplicationUsers\Details.cshtml"

            }

#line default
#line hidden
            BeginContext(3252, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Novateca.Web.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
