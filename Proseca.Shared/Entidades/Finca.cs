using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proseca.Shared.Entidades
{
    public class Finca
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la finca")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Cantidad de animales")]
        [Required(ErrorMessage = "La cantidad es obligatorio")]
        public int Cantidad { get; set; }

        [JsonIgnore]

        public ICollection<Animal> Animales { get; set; }


    }
}
