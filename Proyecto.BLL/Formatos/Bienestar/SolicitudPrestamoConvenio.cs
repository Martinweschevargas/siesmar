using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class SolicitudPrestamoConvenio
    {
        SolicitudPrestamoConvenioDAO solicitudPrestamoConvenioDAO = new();

        public List<SolicitudPrestamoConvenioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return solicitudPrestamoConvenioDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        //public List<SolicitudPrestamoConvenioDTO> BienestarVisualizacionSolicitudPrestamoConsumo(int? CargaId=null, string? fechaInicio=null, string fechaFin=null)
        //{
        //    return solicitudPrestamoConvenioDAO.BienestarVisualizacionSolicitudPrestamoConsumo(CargaId,fechaInicio ,fechaFin);
        //}

        public string AgregarRegistro(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO, string? fecha)
        {
            return solicitudPrestamoConvenioDAO.AgregarRegistro(solicitudPrestamoConvenioDTO, fecha);
        }

        public SolicitudPrestamoConvenioDTO EditarFormato(int Codigo)
        {
            return solicitudPrestamoConvenioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO)
        {
            return solicitudPrestamoConvenioDAO.ActualizaFormato(solicitudPrestamoConvenioDTO);
        }

        public bool EliminarFormato(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO)
        {
            return solicitudPrestamoConvenioDAO.EliminarFormato(solicitudPrestamoConvenioDTO);
        }

        public bool EliminarCarga(SolicitudPrestamoConvenioDTO solicitudPrestamoConvenioDTO)
        {
            return solicitudPrestamoConvenioDAO.EliminarCarga(solicitudPrestamoConvenioDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return solicitudPrestamoConvenioDAO.InsertarDatos(datos, fecha);
        }


    }
}
