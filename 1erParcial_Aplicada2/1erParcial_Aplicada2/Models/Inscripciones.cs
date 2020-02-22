using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Models
{
    public class Inscripciones
    {
        [Key]
        [Required(ErrorMessage = "El campo InscripcionId no puede ser negativo ni estar vacío")]
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo Semestre no puede estar vacío")]
        public string Semestre { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 1000000000000, ErrorMessage = "El campo EstudianteId tiene que estar registrado ")]
        public int EstudianteId { get; set; }
        [Required]
        [Range(minimum:1,maximum:10000,ErrorMessage ="Tiene que poner un valor valido en campo Limite")]
        public int Limite { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 10000, ErrorMessage = "Tiene que poner un valor valido en campo Tomados")]
        public int Tomados { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "Los creditps tomados no pueden superar a los creditos limites")]
        public int Disponibles { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 1000000000000, ErrorMessage = "El campo Monto ")]
        public decimal Monto { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 1000000000000, ErrorMessage = "Tiene que poner un valor valido en campo Limite")]
        public decimal Balance { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            Semestre = string.Empty;
            Limite = 0;
            Tomados = 0;
            Disponibles = 0;
        }
    }
}
