using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proseca.Shared.Entidades
{
    public class Vacuna
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la vacuna")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Razon de la vacuna")]
        [MaxLength(50, ErrorMessage = "La razon de la vacuna no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Razon { get; set; }


        [JsonIgnore] //1-m(v)
        public Animal Animales { get; set; }
        public int AnimalId { get; set; }



    }
}
