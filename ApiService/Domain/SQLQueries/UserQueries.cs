namespace ApiService.Domain.SQLQueries
{
    public class UserQueries
    {
        public string GetUsersAll { get; }
        public string GetUserById { get; }
        public string Create { get; }
        public string Update { get; }
        public string Delete { get; }
        public UserQueries()
        {
            GetUsersAll = "SELECT * FROM db_admon.usuario";
            GetUserById = "SELECT * FROM db_admon.usuario WHERE id_usuario = @id";
            Create = @"INSERT INTO db_admon.usuario (
                id_usuario,
                nombre_usuario,
                contrasenia,
                cui,
                super_admin,
                estado,
                usuario_ing,fecha_ing
            ) 
            VALUES( 
                @IdUsuario,
                @NombreUsuario,
                @Contrasenia,
                @Cui,
                @SuperAdmin,
                @CodigoEstado,
                @UsuarioIng,
                @FechaIng)";
            Update = "UPDATE db_admon.usuario SET contrasenia = @Contrasenia WHERE id_usuario = @id";
            Delete = "DELETE FROM db_admon.usuario WHERE id_usuario = @id";
        }
    }
}
