using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Mapping.Models
{
    [Table("persona")]
    public class PersonModel
    {
        public PersonModel()
        {
            UserId = new UserModel();
        }

        public string? Cui { get; set; }
        public string? Primer_nombre { get; set; }
        public string? Segundo_nombre { get; set; }
        public string? Tercer_nombre { get; set; }
        public string? Primer_apellido { get; set; }
        public string? Apellido_casada { get; set; }
        public string? Nombre_completo { get; set; }
        public string? Segundo_apellido { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public char Codigo_genero { get; set; }
        public string? Correo_electronico { get; set; }
        public int Codigo_departamento_residencia { get; set; }
        public int Codigo_municipio_residencia { get; set; }
        public byte Zona { get; set; }
        public string? Direccion_residencia { get; set; }
        public int Codigo_estado { get; set; }
        public string? Usuario_ing { get; set; }
        public DateTime Fecha_ing { get; set; }
        public string? Usuario_act { get; set; }
        public DateTime Fecha_act { get; set; }
        public byte No_incluido_en_planilla { get; set; }
        public int Codigo_area { get; set; }
        public string? Foto { get; set; }

        public UserModel UserId { get; set; }

    }
}
