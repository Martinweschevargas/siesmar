using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;

namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class Usuario
    {

        UsuarioDAO UsuarioDAO = new();

        public List<UsuarioDTO> ObtenerUsuarios(int? RolId = null)
        {
            return UsuarioDAO.ObtenerUsuarios(RolId);
        }

        public string AgregarUsuario(UsuarioDTO usuarioDto)
        {
            return UsuarioDAO.AgregarUsuario(usuarioDto);
        }

        public UsuarioDTO BuscarUsuarioDNI(int UsuarioId)
        {
            return UsuarioDAO.BuscarUsuarioDNI(UsuarioId);
        }

        public bool ActualizaUsuario(UsuarioDTO UsuarioDto)
        {
            return UsuarioDAO.ActualizarUsuario(UsuarioDto);

        }

        public bool EliminarUsuario(int Codigo)
        {
            return UsuarioDAO.EliminarUsuario(Codigo);
        }
    }
}
