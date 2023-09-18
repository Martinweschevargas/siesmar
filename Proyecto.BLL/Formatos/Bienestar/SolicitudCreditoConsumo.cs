using Marina.Siesmar.AccesoDatos.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Bienestar
{
    public class SolicitudCreditoConsumo
    {
        SolicitudCreditoConsumoDAO solicitudCreditoConsumoDAO = new();

        public List<SolicitudCreditoConsumoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return solicitudCreditoConsumoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        //public List<SolicitudCreditoConsumoDTO> BienestarVisualizacionSolicitudCreditoConsumo(int? CargaId=null, string? fechaInicio=null, string? fechaFin=null)
        //{
        //    return solicitudCreditoConsumoDAO.BienestarVisualizacionSolicitudCreditoConsumo(CargaId, fechaInicio, fechaFin);
        //}


        public string AgregarRegistro(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO, string fecha)
        {
            return solicitudCreditoConsumoDAO.AgregarRegistro(solicitudCreditoConsumoDTO, fecha);
        }

        public SolicitudCreditoConsumoDTO EditarFormato(int Codigo)
        {
            return solicitudCreditoConsumoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO)
        {
            return solicitudCreditoConsumoDAO.ActualizaFormato(solicitudCreditoConsumoDTO);
        }

        public bool EliminarFormato(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO)
        {
            return solicitudCreditoConsumoDAO.EliminarFormato(solicitudCreditoConsumoDTO);
        }

        public bool EliminarCarga(SolicitudCreditoConsumoDTO solicitudCreditoConsumoDTO)
        {
            return solicitudCreditoConsumoDAO.EliminarCarga(solicitudCreditoConsumoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return solicitudCreditoConsumoDAO.InsertarDatos(datos, fecha);
        }


    }
}
