#pragma checksum "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d88b6f6475e1a429a1422e2ca80b72911feec629"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Deposit), @"mvc.1.0.view", @"/Views/Home/Deposit.cshtml")]
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
#line 1 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\_ViewImports.cshtml"
using OnlineBankingApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\_ViewImports.cshtml"
using OnlineBankingApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d88b6f6475e1a429a1422e2ca80b72911feec629", @"/Views/Home/Deposit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7ec532fb0fb66f4a03e2adb33c3057a6818d7f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Deposit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineBankingApp.Models.Account>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateDeposit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    string Role = HttpContextAccessor.HttpContext.Session.GetString("Role");

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
 if (Role == "Teller"){

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h2>Deposit Funds</h2>\r\n</div>\r\n");
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-6\" justify-content-center>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d88b6f6475e1a429a1422e2ca80b72911feec6295158", async() => {
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d88b6f6475e1a429a1422e2ca80b72911feec6295482", async() => {
                    WriteLiteral("Customer:");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 20 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CustomerId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
#nullable restore
#line 21 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
               Write(Html.DropDownListFor(model => model.CustomerId, ViewBag.Customers as SelectList, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d88b6f6475e1a429a1422e2ca80b72911feec6297471", async() => {
                    WriteLiteral("Amount to Deposit:");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 24 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Balance);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d88b6f6475e1a429a1422e2ca80b72911feec6299038", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 25 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Balance);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Deposit\" class=\"btn btn-primary\" />\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 33 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Deposit History</h3>\r\n");
#nullable restore
#line 36 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
 if (Role == "Customer")
{

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
 if (ViewBag.AccountActivities == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No Deposit history found.</p>\r\n");
#nullable restore
#line 41 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Amount</th>\r\n            <th>Date</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 52 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
         foreach (var payment in ViewBag.AccountActivities)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 55 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
               Write(payment.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 56 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
               Write(payment.ActivityDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 58 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 61 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
 if (Role == "Teller"){
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
     if (ViewBag.Acti == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>No Teller Deposit history found.</p>\r\n");
#nullable restore
#line 67 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row justify-content-center"">
        <table>
            <thead>
                <tr>
                    <th>Customer Name</th>
                    <th>Amount</th>
                    <th>Date</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 80 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
                 foreach (var activity in ViewBag.Acti)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 83 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
                       Write(activity.Account.Customer.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 84 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
                       Write(activity.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 85 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
                       Write(activity.ActivityDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 87 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n        </div>\r\n");
#nullable restore
#line 91 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\Users\Tric\Desktop\OnlineBankingApp\OnlineBankingApp\Views\Home\Deposit.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineBankingApp.Models.Account> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
