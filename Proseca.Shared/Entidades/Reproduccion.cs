using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proseca.Shared.Entidades
{
    public class Reproduccion
    {
        public int Id { get; set; }


        [Display(Name = "Fecha de preñez")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPrennez { get; set; }

        [Display(Name = "Tipo de inseminacion")]
        [RegularExpression("(?i)Inseminacion Artificial|Montaje Natural", ErrorMessage = "El tipo de inseminacion debe ser 'Inseminacion Artificial' o 'Montaje natural'")]
        [Required(ErrorMessage = "El sexo del animal es un campo obligatorio")]
        public string TipoInseminacion { get; set; }

        
        [Display(Name = "Numero de crias")]
        [Required(ErrorMessage = "El numero de crias es obligatorio")]
        public int NumeroCrias { get; set; }


        [Display(Name = "Numero de abortos")]
        [Required(ErrorMessage = "El numero de crias es obligatorio")]
        public int NumeroAbortos { get; set; }

        [JsonIgnore]
        public Animal Animales { get; set; }
        public int AnimalId { get; set; }

    }
}
