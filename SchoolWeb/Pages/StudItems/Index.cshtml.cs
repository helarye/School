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
    public class IndexModel : PageModel
    {
        private readonly School.DataAccess.Data.ApplicationDbContext _context;

        public IndexModel(School.DataAccess.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudItem> StudItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            StudItem = await _context.StudItem.ToListAsync();
        }
    }
}
