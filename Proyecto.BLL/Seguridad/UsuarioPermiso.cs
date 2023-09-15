using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class UsuarioPermiso
    {
        UsuarioPermisoDAO usuarioPermisoDAO = new();

        public List<UsuarioPermisoDTO> ObtenerUsuarioPermiso()
        {
            return usuarioPermisoDAO.ObtenerUsuarioPermiso();
        }

        public string AgregarUsuarioPermiso(UsuarioPermisoDTO usuarioPermisoDTO)
        {
            return usuarioPermisoDAO.AgregarUsuarioPermiso(usuarioPermisoDTO);
        }

        public UsuarioPermisoDTO EditarUsuarioPermiso(int Codigo)
        {
            return usuarioPermisoDAO.BuscarUsuarioPermisoID(Codigo);
        }

        public bool ActualizaUsuarioPermiso(UsuarioPermisoDTO usuarioPermisoDTO)
        {
            return usuarioPermisoDAO.ActualizarUsuarioPermiso(usuarioPermisoDTO);
        }

        public string EliminarUsuarioPermiso(UsuarioPermisoDTO usuarioPermisoDTO)
        {
            return usuarioPermisoDAO.EliminarUsuarioPermiso(usuarioPermisoDTO);
        }



    }
}
