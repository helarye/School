using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.Models;

namespace School.Web.Pages.StudItems
{
    public class DetailsModel : PageModel
    {
        private readonly School.DataAccess.Data.ApplicationDbContext _context;

        public DetailsModel(School.DataAccess.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public StudItem StudItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studitem = await _context.StudItem.FirstOrDefaultAsync(m => m.Id == id);
            if (studitem == null)
            {
                return NotFound();
            }
            else
            {
                StudItem = studitem;
            }
            return Page();
        }
    }
}
