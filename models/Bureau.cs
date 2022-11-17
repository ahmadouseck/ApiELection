using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiELection.models
{
    public class Bureau
    {
        [Key]
        public int NumB { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public int Capacite { get; set; }

        [NotMapped]
        // relation Manu_to_one avec la table Centre : Un centre
        public Centre Centre { get; set; }
        // relation One_to_many avec la table Electeur : Collection d'electeur
        [NotMapped]
        [JsonIgnore]
        public ICollection<Electeur>? Electeurs { get; set; }


       



    }
}
