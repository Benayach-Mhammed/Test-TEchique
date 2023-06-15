using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Views.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candidate Candidate { get; set; }

        public async Task<IActionResult> OnGetAsync(string mail)
        {
            if (string.IsNullOrEmpty(mail))
            {
                return NotFound();
            }

            Candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Mail == mail);

            if (Candidate == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string mail)
        {
            if (string.IsNullOrEmpty(mail))
            {
                return NotFound();
            }

            Candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Mail == mail);

            if (Candidate != null)
            {
                _context.Candidates.Remove(Candidate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
