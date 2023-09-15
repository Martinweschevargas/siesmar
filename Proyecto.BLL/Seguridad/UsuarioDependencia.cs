using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class UsuarioDependencia
    {
        UsuarioDependenciaDAO usuarioDependenciaDAO = new();

        public List<UsuarioDependenciaDTO> ObtenerUsuarioDependencia()
        {
            return usuarioDependenciaDAO.ObtenerUsuarioDependencia();
        }

        public string AgregarUsuarioDependencia(UsuarioDependenciaDTO usuarioDependenciaDTO)
        {
            return usuarioDependenciaDAO.AgregarUsuarioDependencia(usuarioDependenciaDTO);
        }

        public UsuarioDependenciaDTO EditarUsuarioDependencia(int Codigo)
        {
            return usuarioDependenciaDAO.BuscarUsuarioDependenciaID(Codigo);
        }

        public string ActualizarUsuarioDependencia(UsuarioDependenciaDTO usuarioDependenciaDTO)
        {
            return usuarioDependenciaDAO.ActualizarUsuarioDependencia(usuarioDependenciaDTO);
        }

        public string EliminarUsuarioDependencia(int Codigo)
        {
            return usuarioDependenciaDAO.EliminarUsuarioDependencia(Codigo);
        }



    }
}
