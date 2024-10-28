using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.Models;

namespace School.Web.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly School.DataAccess.Data.ApplicationDbContext _context;

        public CreateModel(School.DataAccess.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudItemId"] = new SelectList(_context.StudItem, "Id", "Name");
        ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
