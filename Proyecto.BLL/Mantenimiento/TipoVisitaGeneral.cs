using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoVisitaGeneral
    {
        readonly TipoVisitaGeneralDAO tipoVisitaGeneralDAO = new();

        public List<TipoVisitaGeneralDTO> ObtenerTipoVisitaGenerals()
        {
            return tipoVisitaGeneralDAO.ObtenerTipoVisitaGenerals();
        }

        public string AgregarTipoVisitaGeneral(TipoVisitaGeneralDTO tipoVisitaGeneralDto)
        {
            return tipoVisitaGeneralDAO.AgregarTipoVisitaGeneral(tipoVisitaGeneralDto);
        }

        public TipoVisitaGeneralDTO BuscarTipoVisitaGeneralID(int Codigo)
        {
            return tipoVisitaGeneralDAO.BuscarTipoVisitaGeneralID(Codigo);
        }

        public string ActualizarTipoVisitaGeneral(TipoVisitaGeneralDTO tipoVisitaGeneralDTO)
        {
            return tipoVisitaGeneralDAO.ActualizarTipoVisitaGeneral(tipoVisitaGeneralDTO);
        }

        public bool EliminarTipoVisitaGeneral(TipoVisitaGeneralDTO tipoVisitaGeneralDTO)
        {
            return tipoVisitaGeneralDAO.EliminarTipoVisitaGeneral(tipoVisitaGeneralDTO);
        }

    }
}