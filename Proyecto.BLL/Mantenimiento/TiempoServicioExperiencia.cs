using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TiempoServicioExperiencia
    {
        readonly TiempoServicioExperienciaDAO tiempoServicioExperienciaDAO = new();

        public List<TiempoServicioExperienciaDTO> ObtenerTiempoServicioExperiencias()
        {
            return tiempoServicioExperienciaDAO.ObtenerTiempoServicioExperiencias();
        }

        public string AgregarTiempoServicioExperiencia(TiempoServicioExperienciaDTO tiempoServicioExperienciaDto)
        {
            return tiempoServicioExperienciaDAO.AgregarTiempoServicioExperiencia(tiempoServicioExperienciaDto);
        }

        public TiempoServicioExperienciaDTO BuscarTiempoServicioExperienciaID(int Codigo)
        {
            return tiempoServicioExperienciaDAO.BuscarTiempoServicioExperienciaID(Codigo);
        }

        public string ActualizarTiempoServicioExperiencia(TiempoServicioExperienciaDTO tiempoServicioExperienciaDto)
        {
            return tiempoServicioExperienciaDAO.ActualizarTiempoServicioExperiencia(tiempoServicioExperienciaDto);
        }

        public string EliminarTiempoServicioExperiencia(TiempoServicioExperienciaDTO tiempoServicioExperienciaDto)
        {
            return tiempoServicioExperienciaDAO.EliminarTiempoServicioExperiencia(tiempoServicioExperienciaDto);
        }

    }
}
