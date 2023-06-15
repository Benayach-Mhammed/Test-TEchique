using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Views.Admin
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public class LoginInputModel
        {
            [Required(ErrorMessage = "Le champ Email est obligatoire.")]
            [EmailAddress(ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Le champ Mot de passe est obligatoire.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Admin/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Échec de la tentative de connexion. Veuillez vérifier vos informations de connexion.");
                }
            }

        
            return Page();
        }
    }
}
