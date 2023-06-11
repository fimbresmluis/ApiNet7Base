using APINETALL.Structs;
namespace APINETALL.Repositories
{
    public class UsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> _logger;
        public UsuarioDto ObtenerUsuario(string user, string password)
        {
            try
            {
                //Cambiar a buscarlo en la base de datos comparando usuario y contraseña previamente encriptada por el cliente
                return new UsuarioDto { Id = 1, Nombre = user, IdRol = 1 };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[ObtenerUsuario] Error en ObtenerUsuario de la capa de datos");
                throw;
            }
        }

    }

}