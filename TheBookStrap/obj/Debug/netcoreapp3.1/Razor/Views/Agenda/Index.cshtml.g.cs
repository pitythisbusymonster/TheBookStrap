#pragma checksum "C:\Users\turne\source\repos\TheBookStrap\TheBookStrap\Views\Agenda\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee17ee02f5e444deedbb3852da756edab64fa147"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agenda_Index), @"mvc.1.0.view", @"/Views/Agenda/Index.cshtml")]
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
#line 1 "C:\Users\turne\source\repos\TheBookStrap\TheBookStrap\Views\_ViewImports.cshtml"
using TheBookStrap;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\turne\source\repos\TheBookStrap\TheBookStrap\Views\_ViewImports.cshtml"
using TheBookStrap.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee17ee02f5e444deedbb3852da756edab64fa147", @"/Views/Agenda/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d14b18e5edcb07b27378f97bd2abd3eb4df7f40f", @"/Views/_ViewImports.cshtml")]
    public class Views_Agenda_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Journal>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\turne\source\repos\TheBookStrap\TheBookStrap\Views\Agenda\Index.cshtml"
  
    ViewData["Title"] = "Agenda Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Agenda Home Page</h1>\r\n\r\n    <div><a href=\"/Agenda/Agenda\"> View All Scheduled Days</a></div>\r\n\r\n\r\n    <div><a href=\"/Agenda/DayEntry\"> Single Day Entry </a></div>\r\n\r\n\r\n\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Journal> Html { get; private set; }
    }
}
#pragma warning restore 1591