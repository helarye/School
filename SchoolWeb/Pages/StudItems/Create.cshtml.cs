using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.Models;

namespace School.Web.Pages.StudItems
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
            return Page();
        }

        [BindProperty]
        public StudItem StudItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudItem.Add(StudItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
