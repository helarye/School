using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.Models;

namespace School.Web.Pages.StudItems
{
    public class EditModel : PageModel
    {
        private readonly School.DataAccess.Data.ApplicationDbContext _context;

        public EditModel(School.DataAccess.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudItem StudItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studitem =  await _context.StudItem.FirstOrDefaultAsync(m => m.Id == id);
            if (studitem == null)
            {
                return NotFound();
            }
            StudItem = studitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudItemExists(StudItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudItemExists(int id)
        {
            return _context.StudItem.Any(e => e.Id == id);
        }
    }
}
