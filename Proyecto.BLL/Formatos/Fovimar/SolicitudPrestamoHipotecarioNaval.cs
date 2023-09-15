using Marina.Siesmar.AccesoDatos.Formatos.Fovimar;
using Marina.Siesmar.Entidades.Formatos.Fovimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Fovimar
{
    public class SolicitudPrestamoHipotecarioNaval
    {
        SolicitudPrestamoHipotecarioNavalDAO solicitudPrestamoHipotecarioNavalDAO = new();

        public List<SolicitudPrestamoHipotecarioNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return solicitudPrestamoHipotecarioNavalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNaval, string? fecha)
        {
            return solicitudPrestamoHipotecarioNavalDAO.AgregarRegistro(solicitudPrestamoHipotecarioNaval, fecha);
        }

        public SolicitudPrestamoHipotecarioNavalDTO EditarFormato(int Codigo)
        {
            return solicitudPrestamoHipotecarioNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO)
        {
            return solicitudPrestamoHipotecarioNavalDAO.ActualizaFormato(solicitudPrestamoHipotecarioNavalDTO);
        }

        public bool EliminarFormato(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO)
        {
            return solicitudPrestamoHipotecarioNavalDAO.EliminarFormato(solicitudPrestamoHipotecarioNavalDTO);
        }

        public bool EliminarCarga(SolicitudPrestamoHipotecarioNavalDTO solicitudPrestamoHipotecarioNavalDTO)
        {
            return solicitudPrestamoHipotecarioNavalDAO.EliminarCarga(solicitudPrestamoHipotecarioNavalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return solicitudPrestamoHipotecarioNavalDAO.InsertarDatos(datos, fecha);
        }

    }
}
