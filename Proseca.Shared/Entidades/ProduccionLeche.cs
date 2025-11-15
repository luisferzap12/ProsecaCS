using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proseca.Shared.Entidades
{
    public class ProduccionLeche
    {
        public int Id { get; set; }

        [Display(Name = "Cantidad de leche por litros")]
        [Required(ErrorMessage = "La cantidad de leche es obligatoria")]
        public int CantidadLeche { get; set; }


        [Display(Name = "Fecha Ultima produccion")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaUltimaProduccion { get; set; }


        [JsonIgnore]
        public Animal Animales { get; set; }
        public int AnimalId { get; set; }

    }
}
