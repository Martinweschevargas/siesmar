using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Dependencia
    {
        readonly DependenciaDAO dependenciaDAO = new();

        public List<DependenciaDTO> ObtenerDependencias()
        {
            return dependenciaDAO.ObtenerDependencias();
        }

        public List<DependenciaDTO> ObtenerDependenciasSegundoNivel()
        {
            return dependenciaDAO.ObtenerDependenciasSegundoNivel();
        }

        public string AgregarDependencia(DependenciaDTO dependenciaDto)
        {
            return dependenciaDAO.AgregarDependencia(dependenciaDto);
        }

        public DependenciaDTO BuscarDependenciaID(int Codigo)
        {
            return dependenciaDAO.BuscarDependenciaID(Codigo);
        }

        public string ActualizarDependencia(DependenciaDTO dependenciaDTO)
        {
            return dependenciaDAO.ActualizarDependencia(dependenciaDTO);
        }

        public string EliminarDependencia(DependenciaDTO dependenciaDTO)
        {
            return dependenciaDAO.EliminarDependencia(dependenciaDTO);
        }

    }
}

