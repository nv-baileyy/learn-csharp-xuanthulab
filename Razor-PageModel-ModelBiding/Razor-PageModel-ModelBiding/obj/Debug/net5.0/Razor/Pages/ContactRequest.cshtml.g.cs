#pragma checksum "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8db63e115fb0e87e6f7af8ffdf51133b6cabc19e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Razor_PageModel_ModelBiding.Pages.Pages_ContactRequest), @"mvc.1.0.razor-page", @"/Pages/ContactRequest.cshtml")]
namespace Razor_PageModel_ModelBiding.Pages
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
#line 1 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\_ViewImports.cshtml"
using Razor_PageModel_ModelBiding;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/Contact/{id:int?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8db63e115fb0e87e6f7af8ffdf51133b6cabc19e", @"/Pages/ContactRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"132c8e0c3fd2b995335662c0c5c97dcb010e561c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ContactRequest : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "ContactRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "-1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
  
    ViewData["title"] = "Trang lien he";
    var contact = Model.contact;
    var contacts = Model.contacts;


#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"display-4\">Lien he</h1>\r\n<p class=\"lead\"> Dien cac thong tin lien he</p>\r\n\r\n");
#nullable restore
#line 12 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1> ");
#nullable restore
#line 14 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
Write(ViewData["TT"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1>\r\n\r\n");
#nullable restore
#line 16 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
 if (contact != null)
{
    foreach (var item in contact.GetType().GetProperties().ToList())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"lead\">  ");
#nullable restore
#line 20 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 20 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
                                  Write(item.GetValue(contact));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 21 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8db63e115fb0e87e6f7af8ffdf51133b6cabc19e5798", async() => {
                WriteLiteral(" Quy lai danh sach ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 23 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul>\r\n");
#nullable restore
#line 27 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
         foreach (var item in Model._contacts.ListContacts())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8db63e115fb0e87e6f7af8ffdf51133b6cabc19e8031", async() => {
                WriteLiteral(" ");
#nullable restore
#line 29 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
                                                WriteLiteral(item.Id);

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
            WriteLiteral(" </li>\r\n");
#nullable restore
#line 30 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
#nullable restore
#line 32 "D:\CSharpLearningProcess\Razor-PageModel-ModelBiding\Razor-PageModel-ModelBiding\Pages\ContactRequest.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactRequestModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactRequestModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactRequestModel>)PageContext?.ViewData;
        public ContactRequestModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
