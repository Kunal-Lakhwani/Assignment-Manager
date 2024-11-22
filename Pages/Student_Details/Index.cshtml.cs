using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment_Management.Data;
using Assignment_Management.Models;

namespace Assignment_Management.Pages.Student_Details
{
    public class IndexModel : PageModel
    {
        private readonly Assignment_Management.Data.Assignment_ManagementContext _context;

        public IndexModel(Assignment_Management.Data.Assignment_ManagementContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
