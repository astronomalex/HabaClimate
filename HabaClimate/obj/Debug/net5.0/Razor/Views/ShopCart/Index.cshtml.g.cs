#pragma checksum "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\ShopCart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f422af54140877a9dc7436afb69b852e01abb59"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShopCart_Index), @"mvc.1.0.view", @"/Views/ShopCart/Index.cshtml")]
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
#line 1 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\_ViewImports.cshtml"
using HabaClimate.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\_ViewImports.cshtml"
using HabaClimate.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f422af54140877a9dc7436afb69b852e01abb59", @"/Views/ShopCart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d0ea5ae15671e84102b3551d05fe7191b4c9821", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ShopCart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopCartViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n");
#nullable restore
#line 3 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\ShopCart\Index.cshtml"
     foreach (var el in @Model.ShopCart.CartItems)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning mt-3\">\r\n            <b>");
#nullable restore
#line 6 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\ShopCart\Index.cshtml"
          Write(el.Good.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(": </b> ");
#nullable restore
#line 6 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\ShopCart\Index.cshtml"
                                               Write(el.Good.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br/>\r\n            <b>Цена: </b>");
#nullable restore
#line 7 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\ShopCart\Index.cshtml"
                    Write(el.Good.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 9 "C:\Users\green\source\repos\HabaClimate\HabaClimate\Views\ShopCart\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr/>\r\n    <div class=\"btn btn-danger\" asp-controller=\"Order\">Оплатить</div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopCartViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591