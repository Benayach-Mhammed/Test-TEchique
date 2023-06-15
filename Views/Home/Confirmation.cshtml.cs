using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Data;
using Test.Models;

namespace Test.Views.Admin
{
    public class ConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ConfirmationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Candidate Candidate { get; set; }

        public IActionResult OnGet(string mail)
        {
            if (mail == null)
            {
                return NotFound();
            }

            Candidate = _context.Candidates.FirstOrDefault(c => c.Mail == mail);

            if (Candidate == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
