using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Views.Home
{
    public class SubmitApplicationModel : PageModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }
        public int AnneesExperience { get; set; }
        public string DernierEmployeur { get; set; }
        public IFormFile CVFile { get; set; }
    }
}
