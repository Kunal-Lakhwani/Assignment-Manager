﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Assignment_Management.Data.Assignment_ManagementContext _context;

        public DetailsModel(Assignment_Management.Data.Assignment_ManagementContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(m => m.PRN == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
