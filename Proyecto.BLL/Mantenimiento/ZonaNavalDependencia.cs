using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ZonaNavalDependencia
    {
        readonly ZonaNavalDependenciaDAO zonaNavalDependenciaDAO = new();

        public List<ZonaNavalDependenciaDTO> ObtenerZonaNavalDependencias()
        {
            return zonaNavalDependenciaDAO.ObtenerZonaNavalDependencias();
        }

        public string AgregarZonaNavalDependencia(ZonaNavalDependenciaDTO zonaNavalDependenciaDto)
        {
            return zonaNavalDependenciaDAO.AgregarZonaNavalDependencia(zonaNavalDependenciaDto);
        }

        public ZonaNavalDependenciaDTO BuscarZonaNavalDependenciaID(int Codigo)
        {
            return zonaNavalDependenciaDAO.BuscarZonaNavalDependenciaID(Codigo);
        }

        public string ActualizarZonaNavalDependencia(ZonaNavalDependenciaDTO zonaNavalDependenciaDTO)
        {
            return zonaNavalDependenciaDAO.ActualizarZonaNavalDependencia(zonaNavalDependenciaDTO);
        }

        public bool EliminarZonaNavalDependencia(ZonaNavalDependenciaDTO zonaNavalDependenciaDTO)
        {
            return zonaNavalDependenciaDAO.EliminarZonaNavalDependencia(zonaNavalDependenciaDTO);
        }

    }
}
