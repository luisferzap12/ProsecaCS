using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Proseca.Shared.Entidades
{
    public class Animal
    {
        public int Id { get; set; }

        [Display(Name = "Chapeta del animal")]
        [MaxLength(50, ErrorMessage = "Este campo no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Chapeta { get; set; }

        [Display(Name = "Nombre del animal")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Foto de la vaca")]
        public string ImagenUrl { get; set; }

        [Display(Name = "Sexo")]
        [RegularExpression("(?i)Macho|Hembra", ErrorMessage = "El estado debe ser 'Macho' o 'Hembra'")]
        [Required(ErrorMessage = "El sexo del animal es un campo obligatorio")]
        public string Sexo { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Esta fecha es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaN { get; set; }

        [Display(Name = "Nombre del padre del animal")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Padre { get; set; }

        [Display(Name = "Nombre de la madre del animal")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Madre { get; set; }


        [Display(Name = "Raza")]
        [MaxLength(50, ErrorMessage = "La raza no puede tener más de 50 caracteres.")]
        [Required(ErrorMessage = "La raza es obligatoria")]
        public string Raza { get; set; }


        [Display(Name = "Ultimo peso")]
        [Required(ErrorMessage = "El peso es obligatorio")]
        public int peso { get; set; }


        [Display(Name = "Color")]
        [MaxLength(30, ErrorMessage = "El color no puede tener más de 30 caracteres.")]
        [Required(ErrorMessage = "El color es obligatorio")]
        public string Color { get; set; }





        [JsonIgnore]
        public Finca Fincas { get; set; }
        public int FincaId { get; set; }

        [JsonIgnore]

        public ICollection<EventoDeSalud> EventosSalud { get; set; }

        [JsonIgnore]

        public ICollection<ProduccionLeche> ProduccionesLeche { get; set; }

        [JsonIgnore]

        public ICollection<Reproduccion> Reproducciones { get; set; }


        [JsonIgnore]

        public ICollection<Vacuna> Vacunas { get; set; }
    }
}
