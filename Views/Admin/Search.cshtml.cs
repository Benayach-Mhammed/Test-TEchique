using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Views.Admin
{
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string SearchTerm { get; set; }
        
        public List<Candidate> SearchResults { get; set; }

        public async Task<IActionResult> OnGetAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Page();
            }

            SearchResults = await _context.Candidates
                .Where(c => c.Mail.Contains(searchTerm) || c.Nom.Contains(searchTerm) || c.Prenom.Contains(searchTerm) || c.Telephone.Contains(searchTerm))
                .ToListAsync();

            return Page();
        }
    }
}
