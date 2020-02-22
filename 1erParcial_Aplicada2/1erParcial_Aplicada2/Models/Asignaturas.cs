using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1erParcial_Aplicada2.Models
{
    public class Asignaturas
    {
        [Key]
        [Required(ErrorMessage = "El campo AsignaturaId no puede ser negativo ni estar vacío")]
        public int AsignaturaId{ get; set; }
        [Required(ErrorMessage = "El campo Codigo no puede estar vacío")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo Descripcion no puede estar vacío")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo PreRequisito no puede estar vacío")]
        public string PreRequisito { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "El numero de creditos no puede ser negativo, ni muy alto")]
        public int Creditos { get; set; }

        public Asignaturas()
        {
            AsignaturaId = 0;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            PreRequisito = string.Empty;
            Creditos = 0;
        }

    }
}
