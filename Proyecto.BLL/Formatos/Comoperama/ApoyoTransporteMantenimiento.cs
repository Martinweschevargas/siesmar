using Marina.Siesmar.AccesoDatos.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperama
{
    public class ApoyoTransporteMantenimiento
    {
        ApoyoTransporteMantenimientoDAO apoyoTransporteMantenimientoDAO = new();

        public List<ApoyoTransporteMantenimientoDTO> ObtenerLista(int? CargaId = null)
        {
            return apoyoTransporteMantenimientoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO)
        {
            return apoyoTransporteMantenimientoDAO.AgregarRegistro(apoyoTransporteMantenimientoDTO);
        }

        public ApoyoTransporteMantenimientoDTO BuscarFormato(int Codigo)
        {
            return apoyoTransporteMantenimientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO)
        {
            return apoyoTransporteMantenimientoDAO.ActualizaFormato(apoyoTransporteMantenimientoDTO);
        }

        public bool EliminarFormato(ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO)
        {
            return apoyoTransporteMantenimientoDAO.EliminarFormato(apoyoTransporteMantenimientoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return apoyoTransporteMantenimientoDAO.InsertarDatos(datos);
        }

    }
}
