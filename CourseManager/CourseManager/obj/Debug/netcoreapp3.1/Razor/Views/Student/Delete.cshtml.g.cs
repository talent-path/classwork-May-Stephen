#pragma checksum "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\Student\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2de2ef1cd7bc50016d8f279a6909ac91ba57f189"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Delete), @"mvc.1.0.view", @"/Views/Student/Delete.cshtml")]
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
#line 1 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2de2ef1cd7bc50016d8f279a6909ac91ba57f189", @"/Views/Student/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a0572f074d3b8a640e694913b8cb8b34518460", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Student>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 5 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\Student\Delete.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>Are you sure you want to delete this course?</p>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\Student\Delete.cshtml"
 using (Html.BeginForm("Delete", "Student", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\Student\Delete.cshtml"
Write(Html.HiddenFor(s => s.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\Student\Delete.cshtml"
                              ;


#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"submit\">Yes</button>\r\n");
#nullable restore
#line 14 "C:\Users\SMay\Documents\Dell Training\classwork-May-Stephen\CourseManager\CourseManager\Views\Student\Delete.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<button>No</button>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Student> Html { get; private set; }
    }
}
#pragma warning restore 1591
