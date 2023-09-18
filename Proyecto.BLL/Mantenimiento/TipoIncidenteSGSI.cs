using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoIncidenteSGSI
    {
        readonly TipoIncidenteSGSIDAO tipoIncidenteSGSIDAO = new();

        public List<TipoIncidenteSGSIDTO> ObtenerTipoIncidenteSGSIs()
        {
            return tipoIncidenteSGSIDAO.ObtenerTipoIncidenteSGSIs();
        }

        public string AgregarTipoIncidenteSGSI(TipoIncidenteSGSIDTO tipoIncidenteSGSIDto)
        {
            return tipoIncidenteSGSIDAO.AgregarTipoIncidenteSGSI(tipoIncidenteSGSIDto);
        }

        public TipoIncidenteSGSIDTO BuscarTipoIncidenteSGSIID(int Codigo)
        {
            return tipoIncidenteSGSIDAO.BuscarTipoIncidenteSGSIID(Codigo);
        }

        public string ActualizarTipoIncidenteSGSI(TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO)
        {
            return tipoIncidenteSGSIDAO.ActualizarTipoIncidenteSGSI(tipoIncidenteSGSIDTO);
        }

        public string EliminarTipoIncidenteSGSI(TipoIncidenteSGSIDTO tipoIncidenteSGSIDTO)
        {
            return tipoIncidenteSGSIDAO.EliminarTipoIncidenteSGSI(tipoIncidenteSGSIDTO);
        }

    }
}
