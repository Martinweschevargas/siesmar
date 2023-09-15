using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;

namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class Menu
    {
        MenuDAO menuDao = new();

        public List<MenuPrincipalDTO> ObtenerDependencias(int UsuarioId)
        {
            return menuDao.ObtenerDependencias(UsuarioId);
        }

        public List<MenuPrincipalDTO> ObtenerDependenciasSubordinadas1(string DependenciaDesc, int UsuarioId)
        {
            return menuDao.ObtenerDependenciasSubordinadas1(DependenciaDesc, UsuarioId);
        }

        public List<MenuPrincipalDTO> ObtenerDependenciasSubordinadas2(string DependenciaDesc, int UsuarioId)
        {
            return menuDao.ObtenerDependenciasSubordinadas2(DependenciaDesc, UsuarioId);
        }

        public List<MenuPrincipalDTO> ObtenerMenuSeguridad(int usuario)
        {
            return menuDao.ObtenerMenuSeguridad(usuario);
        }
        public int ValidarPermisos(int Usuario, int Formato, int Permiso)
        {
            return menuDao.ValidarPermiso(Usuario, Formato, Permiso);
        }

    }
}
