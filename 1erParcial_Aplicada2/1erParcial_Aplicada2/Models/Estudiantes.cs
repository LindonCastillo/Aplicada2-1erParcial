using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Models
{
    public class Estudiantes
    {
        [Key]
        [Required(ErrorMessage = "El campo AsignaturaId no puede ser negativo ni estar vacío")]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "El campo Matricula no puede estar vacío")]
        [StringLength(maximumLength: 10, ErrorMessage ="La Matricula es muy larga")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "El campo Nombres no puede estar vacío")]
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre es muy largo")]
        public string Nombres { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 100000000000, ErrorMessage = "El Balance no puede ser negativo, ni estar vacío")]
        public decimal Balance { get; set; }

        public Estudiantes()
        {
            EstudianteId = 0;
            Matricula = string.Empty;
            Nombres = string.Empty;
            Balance = 0;
        }
    }
}
