using System;
using System.ComponentModel.DataAnnotations;

namespace EjemploConexionDll.Models.Dto
{
    public class ContactosDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        [RegularExpression("^[a-zñ]+[a-zñ ]+[a-zñ]$", ErrorMessage ="Solo letras")]
        public string Nombre { get; set; }

        [Required]
        public string TipoContacto { get; set; }

        [Required]
        [Display(Name ="Telfijo")]
        [RegularExpression("^[0-9]*$", ErrorMessage ="Solo Números")]
        [Range(0, 10, ErrorMessage = "10 Digitos")]
        public string Telfijo { get; set; }

        [Required]
        [Display(Name = "Telmovil")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo Números")]
        [Range(0, 10, ErrorMessage = "10 Digitos")]
        public string Telmovil { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaNac { get; set; }

        [Required]
        public string Sexo { get; set; }
        [Required]
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
        Divorciado,
        Viudo,
        Unionlibre 
    }
}