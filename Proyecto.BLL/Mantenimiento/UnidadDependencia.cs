using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadDependencia
    {
        readonly UnidadDependenciaDAO capitaniaDAO = new();

        public List<UnidadDependenciaDTO> ObtenerUnidadDependencias()
        {
            return capitaniaDAO.ObtenerUnidadDependencias();
        }

        public string AgregarUnidadDependencia(UnidadDependenciaDTO capitaniaDto)
        {
            return capitaniaDAO.AgregarUnidadDependencia(capitaniaDto);
        }

        public UnidadDependenciaDTO BuscarUnidadDependenciaID(int Codigo)
        {
            return capitaniaDAO.BuscarUnidadDependenciaID(Codigo);
        }

        public string ActualizarUnidadDependencia(UnidadDependenciaDTO capitaniaDto)
        {
            return capitaniaDAO.ActualizarUnidadDependencia(capitaniaDto);
        }

        public string EliminarUnidadDependencia(UnidadDependenciaDTO capitaniaDto)
        {
            return capitaniaDAO.EliminarUnidadDependencia(capitaniaDto);
        }

    }
}
