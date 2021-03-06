#pragma checksum "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21a34fb8f281f62a07e76e227ee94ea2fcc24554"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transacao_Dashboard), @"mvc.1.0.view", @"/Views/Transacao/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Transacao/Dashboard.cshtml", typeof(AspNetCore.Views_Transacao_Dashboard))]
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
#line 1 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance;

#line default
#line hidden
#line 2 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21a34fb8f281f62a07e76e227ee94ea2fcc24554", @"/Views/Transacao/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d05dd6abef5a8ff60f9a555c67ee727241a6c480", @"/Views/_ViewImports.cshtml")]
    public class Views_Transacao_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 579, true);
            WriteLiteral(@"
<h3>Meu DashBoard</h3>

<br />
<br />

<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js""></script>

<div class=""panel panel-default"" style=""width:50%"">
    <div class=""panel-body"">
        <div id=""canvas-holder"">
            <canvas id=""chart-area""></canvas>
        </div>
        <script>
    var randomScalingFactor = function () {
        return Math.round(Math.random() * 100);
    };

    var config = {
        type: 'pie',
        data: {
            datasets: [{
                data: [
                    ");
            EndContext();
            BeginContext(580, 28, false);
#line 24 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml"
               Write(Html.Raw(ViewBag.valoresPie));

#line default
#line hidden
            EndContext();
            BeginContext(608, 78, true);
            WriteLiteral("\r\n                ],\r\n                backgroundColor: [\r\n                    ");
            EndContext();
            BeginContext(687, 26, false);
#line 27 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml"
               Write(Html.Raw(ViewBag.coresPie));

#line default
#line hidden
            EndContext();
            BeginContext(713, 114, true);
            WriteLiteral("\r\n                ],\r\n                label: \'Dataset 1\'\r\n            }],\r\n            labels: [\r\n                ");
            EndContext();
            BeginContext(828, 27, false);
#line 32 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml"
           Write(Html.Raw(ViewBag.labelsPie));

#line default
#line hidden
            EndContext();
            BeginContext(855, 294, true);
            WriteLiteral(@"
            ]
        },
        options: {
            responsive: true
        }
    };

    window.onload = function () {
        var ctx = document.getElementById('chart-area').getContext('2d');
        window.myPie = new Chart(ctx, config);
    };
            var Cartoes = [ ");
            EndContext();
            BeginContext(1150, 27, false);
#line 44 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml"
                       Write(Html.Raw(ViewBag.LabelsBar));

#line default
#line hidden
            EndContext();
            BeginContext(1177, 48, true);
            WriteLiteral("];\r\n    var barChartData = {\r\n        labels: [ ");
            EndContext();
            BeginContext(1226, 27, false);
#line 46 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml"
             Write(Html.Raw(ViewBag.LabelsBar));

#line default
#line hidden
            EndContext();
            BeginContext(1253, 170, true);
            WriteLiteral("],\r\n        datasets: [{\r\n            backgroundColor:\"#0688FF\",\r\n            borderColor: \"#0540E8\",\r\n            borderWidth: 1,\r\n            data: [\r\n                 ");
            EndContext();
            BeginContext(1424, 28, false);
#line 52 "C:\Users\Jean\Documents\projetos\Cursos\Sistema de Gestao Financeira\Projeto\MyFinance\MyFinance\Views\Transacao\Dashboard.cshtml"
            Write(Html.Raw(ViewBag.ValoresBar));

#line default
#line hidden
            EndContext();
            BeginContext(1452, 80, true);
            WriteLiteral("\r\n            ]\r\n        }]\r\n\r\n    };\r\n\r\n        </script>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
