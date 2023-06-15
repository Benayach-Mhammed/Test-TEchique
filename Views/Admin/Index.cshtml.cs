using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Views.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Candidate> Candidates { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Candidates = await _context.Candidates.ToListAsync();
            return Page();
        }
    }
}
