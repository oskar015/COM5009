using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Fines
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

       
using System.Collections.Generic;  
using Microsoft.AspNetCore.Mvc.RazorPages;  

namespace ContosoUniversity.Pages.Fines
    {
        public class IndexModel : PageModel
        {
            private readonly ContosoUniversity.Data.SchoolContext _context;

            public IndexModel(ContosoUniversity.Data.SchoolContext context)
            {
                _context = context;
            }

            public List<Fine> Fine { get; set; }

            public void OnGet()
            {
                // Example data for demonstration purposes  
                Fine = new List<Fine>
                    {
                        new Fine { FineID = 1, Fine_amount = 50, User_owed = "John Doe" },
                        new Fine { FineID = 2, Fine_amount = 75, User_owed = "Jane Smith" }
                    };
            }
        }

        public class Fine
        {
            public int FineID { get; set; }
            public decimal Fine_amount { get; set; }
            public string User_owed { get; set; }
        }
    }
    }
}
