using Azure;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace ContosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}

/* (tried to add a filter search function to the books)
< h1 > Index </ h1 >

< p >
    < a asp - page = "Create" > Create New </ a >
</ p >

< form >
    < p >
        < label > Title: < input type = "text" asp -for= "SearchString" /></ label >
        < input type = "submit" value = "Filter" />
    </ p >
</ form >


< table class= "table" >
    < thead >
        < tr >
            < th >
                @Html.DisplayNameFor(model => model.Course[0].Title)
            </ th >
            < th >
                @Html.DisplayNameFor(model => model.Course[0].Credits)
            </ th >
            < th ></ th >
        </ tr >
    </ thead >
    < tbody >
        @foreach(var item in Model.Course)
        {
            < tr >
                < td >
                    @Html.DisplayFor(modelItem => item.Title)
                </ td >
                < td >
                    @Html.DisplayFor(modelItem => item.Credits)
                </ td >
                < td >
                    < a asp - page = "./Edit" asp - route - id = "@item.CourseID" > Edit </ a > |
                    < a asp - page = "./Details" asp - route - id = "@item.CourseID" > Details </ a > |
                    < a asp - page = "./Delete" asp - route - id = "@item.CourseID" > Delete </ a >
                </ td >
            </ tr >
        }
    </ tbody >
</ table >

----


#pragma warning disable CA1050 // Declare types in namespaces
public class IndexModel(ContosoUniversity.Data.SchoolContext context) : PageModel
#pragma warning restore CA1050 // Declare types in namespaces
{
    private readonly ContosoUniversity.Data.SchoolContext _context = context;

    public IList<Course> Course { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public SelectList? Genres { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? CourseGenre { get; set; }

    public async Task OnGetAsync(string searchString)
    {
        var courses = from m in _context.Courses
                      select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            courses = courses.Where(s => s.Title.Contains(searchString));
        }

        Course = await courses.ToListAsync(); // Fixed the issue by assigning to the correct property
    }
}

*/
