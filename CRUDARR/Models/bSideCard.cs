
// Modelo utilizado en la BD

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDARR.Models
{
    public class BSideCard
    {
        [Key] //Lave principal
        public int Id { get; set; } //Crea campo Id

        [Required (ErrorMessage = "El Nombre es obligatorio")] //Requqerimientos en tabla 
        [StringLength(50, ErrorMessage = "El {0} debe de ser al menos {2} y maximo {1} caracteres", MinimumLength = 10)]
        [Display(Name = "NombreTitular")]
        public string NombreTitular { get; set; } //Crea campo Nombre titular

        [Required(ErrorMessage = "ELa numeracion es obligatoria")]
        [StringLength(16, ErrorMessage = "El {0} debe de ser al menos {2} y maximo {1} caracteres", MinimumLength = 16)]
        [Display(Name = "Numeracion")]
        public string Numeracion { get; set; } //Crea campo Numeracion

        [Required(ErrorMessage = "El CVV es obligatorio")]
        [StringLength(3, ErrorMessage = "El {0} debe de ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "CVV")]
        public string CVV { get; set; } //Crea campo CVV


        public DateTime FechaVencimiento { get; set; } //Crea campo Fecha


    }
}
