#pragma checksum "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85c7c7e66284f4521c18d057144289bba5b4eef8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
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
#line 1 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\_ViewImports.cshtml"
using Razor_Syntax;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
using Razor_Syntax.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/trangchu")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85c7c7e66284f4521c18d057144289bba5b4eef8", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52acf8d9860af18fb0553aef1007813150fee021", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 19 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";
    var xinchao = "<div class='alert alert-danger'> xin chao all</div>";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"display-4 text-danger\">\r\n    Lession: Razor Syntax - ");
#nullable restore
#line 25 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
                       Write(this.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<ul>\r\n    <li> On model: ");
#nullable restore
#line 28 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
              Write(Model.AAA);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li> ");
#nullable restore
#line 29 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
     Write(5+6);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n    <li> ");
#nullable restore
#line 30 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
     Write(Math.PI);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n    <li> ");
#nullable restore
#line 31 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
     Write("<h1> hello my crush </h1>");

#line default
#line hidden
#nullable disable
            WriteLiteral("</li> ");
            WriteLiteral("\r\n    <li> ");
#nullable restore
#line 32 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
    Write(Html.Raw("<h1> hello my crush </h1>"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li> ");
            WriteLiteral("\r\n    <li> ");
#nullable restore
#line 33 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
    Write(Html.Raw(xinchao));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n</ul>\r\n<hr>\r\n");
#nullable restore
#line 36 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
  
    var greeting = "Hellu you, ";
    void Xinchao(string name)
    {
        var msg = greeting + name;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p> ");
#nullable restore
#line 41 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
       Write(msg);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 42 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 49 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
  
    Xinchao("Hai Nguyen");
    // Dont export to HTML - Using <text> tag / @: ...
    string[] abc = { "IPHONE", "SAMSUNG", "NOKIA" };
    foreach (var str in abc)
    {
        

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
          Write(str);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral("\r\n        ");
            WriteLiteral(" ");
#nullable restore
#line 56 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
      Write(str);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <hr>\r\n");
#nullable restore
#line 58 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "D:\CSharpLearningProcess\Razor-Syntax\Razor-Syntax\Pages\Index.cshtml"
           
    string title = "vang=hainguyen";

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
