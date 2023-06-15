using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Mail,Telephone,NiveauEtude,AnneesExperience,DernierEmployeur,CVPath")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

      
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nom,Prenom,Mail,Telephone,NiveauEtude,AnneesExperience,DernierEmployeur,CVPath")] Candidate candidate)
        {
            if (id != candidate.Mail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.Mail))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

       
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FirstOrDefaultAsync(m => m.Mail == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(m => m.Mail == id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(string id)
        {
            return _context.Candidates.Any(e => e.Mail == id);
        }
    }
}
