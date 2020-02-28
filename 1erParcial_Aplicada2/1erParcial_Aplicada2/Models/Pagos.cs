using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Models
{
    public class Pagos
    {
        [Key]
        [Required(ErrorMessage = "El campo AsignaturaId no puede ser negativo ni estar vacío")]
        public int PagoId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "La InscripcionId no puede estar vacío")]
        [Range(minimum: 1, maximum: 1000000000, ErrorMessage = "La InscripcionId tiene que existir para ser valido")]
        public int InscripcionId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 100000000000, ErrorMessage = "El Monto no puede ser negativo y debe ser mayor a 0")]
        public decimal Monto { get; set; }

        public Pagos()
        {
            PagoId = 0;
            Fecha = DateTime.Now;
            InscripcionId = 0;
            Monto = 0;
        }
    }
}
