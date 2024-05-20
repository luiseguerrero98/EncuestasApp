using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace encuestasBackend.Models 
{
    public class Encuesta
    {
        [Key]
        public int IdEncuesta {get; set; }
        public string nombreEncuesta {get; set;}
        public string descripcion{get; set;}

        public ICollection<EncuestaCampo> EncuestaCampos {get; set;}

    }
}