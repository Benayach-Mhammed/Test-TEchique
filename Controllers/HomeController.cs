using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using Test.Models;


namespace Test.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly IWebHostEnvironment _environment;

       
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;


        }

      public IActionResult Index()
{
    return RedirectToAction("SubmitApplication");
}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SubmitApplication()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitApplication(ApplicationViewModel model, IFormFile cvFile)
        {
            if (ModelState.IsValid)
            {
               
                Candidate candidate = new Candidate
                {
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    Mail = model.Mail,
                    Telephone = model.Telephone,
                    NiveauEtude = model.NiveauEtude,
                    AnneesExperience = model.AnneesExperience,
                    DernierEmployeur = model.DernierEmployeur
                };

               
                if (cvFile != null && cvFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Cvs");
                    string uniqueFileName = $"{Guid.NewGuid().ToString()}_{cvFile.FileName}";
                    string fileName = $"{model.Nom}_{model.Prenom}{Path.GetExtension(cvFile.FileName)}";
                    string filePath = Path.Combine(uploadsFolder, fileName);
                   
                 

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await cvFile.CopyToAsync(fileStream);
                    }

                    
                    candidate.CVPath = uniqueFileName;
                }

              
                string confirmationMessage = $"Bonjour {model.Prenom}, vous avez postulé avec succès pour l'offre xxxx";
              

                return RedirectToAction("Confirmation");
            }

            return View("SubmitApplication", model);
        }
        public IActionResult Confirmation()
        {
            return View();
        }

    }

}