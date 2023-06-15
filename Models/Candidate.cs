using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Test.Models
{
    public class Candidate
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Key]
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string NiveauEtude { get; set; }
        public int AnneesExperience { get; set; }
        public string DernierEmployeur { get; set; }
        public string CVPath { get; set; }
        
    }
}
