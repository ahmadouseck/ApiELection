using System.ComponentModel.DataAnnotations;

namespace ApiELection.models
{
    public class Electeur
    {
        [Key]
        public int NumE { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Lieu_residence { get; set; }

        // relation Manu_to_one avec la table Bureau : Un bureau
        public Bureau Bureau { get; set; }
    }
}
