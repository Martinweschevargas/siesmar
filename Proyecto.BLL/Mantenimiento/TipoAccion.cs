using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAccion
    {
        readonly TipoAccionDAO tipoAccionDAO = new();

        public List<TipoAccionDTO> ObtenerTipoAccions()
        {
            return tipoAccionDAO.ObtenerTipoAccions();
        }

        public string AgregarTipoAccion(TipoAccionDTO tipoAccionDto)
        {
            return tipoAccionDAO.AgregarTipoAccion(tipoAccionDto);
        }

        public TipoAccionDTO BuscarTipoAccionID(int Codigo)
        {
            return tipoAccionDAO.BuscarTipoAccionID(Codigo);
        }

        public string ActualizarTipoAccion(TipoAccionDTO tipoAccionDTO)
        {
            return tipoAccionDAO.ActualizarTipoAccion(tipoAccionDTO);
        }

        public bool EliminarTipoAccion(TipoAccionDTO tipoAccionDTO)
        {
            return tipoAccionDAO.EliminarTipoAccion(tipoAccionDTO);
        }

    }
}
