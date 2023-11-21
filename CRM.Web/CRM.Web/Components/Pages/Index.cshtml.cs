using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRM.Data;
using CRM.Entities;

namespace CRM.Web.Components.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CRM.Data.EntitiesDbContext _context;

        public IndexModel(CRM.Data.EntitiesDbContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Companies
                .Include(c => c.Owner).ToListAsync();
        }
    }
}
