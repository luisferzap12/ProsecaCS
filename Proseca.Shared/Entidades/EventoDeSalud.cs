using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proseca.Shared.Entidades
{
    public class EventoDeSalud
    {
        public int Id { get; set; }

        [Display(Name = "Estado del animal")]
        [MaxLength(50, ErrorMessage = "El estado no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Nomre de la enfermedad")]
        [MaxLength(50, ErrorMessage = "El estado no puede tener más de 50 caracteres.")]
        public string Enfermedad { get; set; }


        [Display(Name = "Fecha de Inico")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de fin")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [JsonIgnore]
        public Animal Animales { get; set; }
        public int AnimalId { get; set; }

    }
}
