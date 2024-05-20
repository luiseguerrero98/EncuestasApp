using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace encuestasBackend.Models 
{
    public class EncuestaCampo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEncuestaCampo {get; set;}

        [ForeignKey("Encuesta")]
        public int IdEncuesta {get; set;}
        public string nombre {get; set;}
        public string titulo {get; set;}

        [Column(TypeName = "BIT")]
        public bool requerido {get; set;}

        // [Required]
        [ValidateNever]
        public Encuesta Encuesta {get; set;}

    }
}