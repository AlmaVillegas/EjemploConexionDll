using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploConexionDll.Models.Dto
{
    public class ContactosDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="Solo letras")]
        public string Nombre { get; set; }

        public string TipoContacto { get; set; }
        [Required]
        [Display(Name ="Telfijo")]
        [RegularExpression("^[0-9]*$", ErrorMessage ="Solo Números")]
        public string Telfijo { get; set; }
        [Required]
        [Display(Name = "Telmovil")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo Números")]
        public string Telmovil { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }

        public string Sexo { get; set; }

        public string EstadoCivil { get; set; }
    }

    public enum Sexo
    {
        Mujer,
        Hombre
    }

    public enum TipoContacto
    {
        Amistad,
        Pareja,
        Familia
    }
    public enum EstadoCivil
    {
        Soltero,
        Casado,
        Divorsiado,
        Viudo,
        Unionlibre 
    }
}