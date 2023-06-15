using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Test.Models
{
    public class ApplicationViewModel
    {
        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        public string Prenom { get; set; }
        [Key]
        [Required(ErrorMessage = "Le champ Mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ Téléphone est obligatoire.")]
        [Phone(ErrorMessage = "Veuillez entrer un numéro de téléphone valide.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ Niveau d'étude est obligatoire.")]
        public string NiveauEtude { get; set; }

        [Required(ErrorMessage = "Le champ Nombre d'années d'expérience est obligatoire.")]
        [Range(0, int.MaxValue, ErrorMessage = "Veuillez entrer un nombre d'années d'expérience valide.")]
        public int AnneesExperience { get; set; }

        [Required(ErrorMessage = "Le champ Dernier employeur est obligatoire.")]
        public string DernierEmployeur { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un fichier CV.")]
        [DataType(DataType.Upload)]

        [NotMapped] public IFormFile CVFile { get; set; }
    }
}
