using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiELection.models
{
    public class Centre
    {
        [Key]
        public int NumC { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Lieu { get; set; }
        [Required]
        public int NombreBureau { get; set; }

        // relation One_to_many avec la table Bureau : Collection de bureau
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Bureau> Bureaux { get; set; }
    }
}
