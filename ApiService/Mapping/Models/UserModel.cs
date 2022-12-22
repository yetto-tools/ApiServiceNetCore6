using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiService.Mapping.Models
{
    [Table("usuario")]
    public class UserModel
    {
        [Column("id_usuario")]
        public string Id_Usuario { set; get; } = string.Empty;
        public string Nombre_Usuario { set; get; } = string.Empty;
        public string Contrasenia { set; get; } = string.Empty;
        public string Cui { set; get; } = string.Empty;// NO	NULL FK -> db_rrhh.persona(cui)
        public byte Super_Admin { set; get; }
        public byte Estado { set; get; }
        public string Usuario_Ing { set; get; } = string.Empty;
        public DateTime Fecha_Ing { set; get; }
        public byte Set_Semana_Ant { set; get; }
        public byte Semana_A_Excluir { set; get; }
    }
}


