#pragma checksum "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4a5b349d987cf035ddc54cdd0572aabfefb14cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReadAllaInstruktorer), @"mvc.1.0.view", @"/Views/Home/ReadAllaInstruktorer.cshtml")]
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
#line 1 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\_ViewImports.cshtml"
using InstruktorerPassMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\_ViewImports.cshtml"
using InstruktorerPassMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4a5b349d987cf035ddc54cdd0572aabfefb14cc", @"/Views/Home/ReadAllaInstruktorer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6acba82bed5f898a1ffeb647cc4e9ec00576328c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ReadAllaInstruktorer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<InstruktorerPassMVC.Models.Instruktorer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
  
    ViewData["Title"] = "Alla Instruktorer";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Alla Instruktörer</h2>\r\n\r\n<br />\r\n\r\n<input type=\"button\" class=\"btn btn-dark\" value=\"Lägg till ny instruktör\"");
            BeginWriteAttribute("onclick", " onclick=\"", 231, "\"", 317, 2);
#nullable restore
#line 11 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
WriteAttributeValue("", 241, "window.location.href='" + @Url.Action("CreateInstruktor", "Home") + "'", 241, 75, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 316, ";", 316, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" />

<br />
<br />
<table class=""table"">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                Förnamn
            </th>
            <th>
                Efternamn
            </th>
            <th>
                Adress
            </th>
            <th>
                Postnummer
            </th>
            <th>
                Ort
            </th>
            <th>
                Epost
            </th>
            <th>
                Mobilnummer
            </th>
            <th>
                Personnummer
            </th>
            <th>Övrigt</th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 50 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Fornamn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Efternamn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Adress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Postnummer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Ort));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 72 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Epost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Mobil));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 78 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.DisplayFor(modelItem => item.In_Personnummer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 81 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Ändra Adress", "UpdateAdress", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 82 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Ändra Efternamn", "UpdateEfternamn", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 83 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Ändra Epost", "UpdateEpost", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 84 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Ändra Mobilnummer", "UpdateMobil", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 85 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Visa Instruktör", "ReadInstruktor", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 86 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Visa Alla Instruktörens Pass", "ReadInstruktorensPass", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 87 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
               Write(Html.ActionLink("Radera Instruktör", "DeleteInstruktor", new { id = item.In_Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 90 "C:\Users\amand\source\repos\InstruktorerPassAPI\InstruktorerPassMVC\Views\Home\ReadAllaInstruktorer.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<InstruktorerPassMVC.Models.Instruktorer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
