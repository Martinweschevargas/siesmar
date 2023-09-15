using Marina.Siesmar.AccesoDatos.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperama
{
    public class ApoyoSaludTipoActividad
    {
        ApoyoSaludTipoActividadDAO apoyoSaludTipoActividadDAO = new();

        public List<ApoyoSaludTipoActividadDTO> ObtenerLista(int? CargaId = null)
        {
            return apoyoSaludTipoActividadDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ApoyoSaludTipoActividadDTO apoyoSaludTipoActividadDTO)
        {
            return apoyoSaludTipoActividadDAO.AgregarRegistro(apoyoSaludTipoActividadDTO);
        }

        public ApoyoSaludTipoActividadDTO BuscarFormato(int Codigo)
        {
            return apoyoSaludTipoActividadDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ApoyoSaludTipoActividadDTO apoyoSaludTipoActividadDTO)
        {
            return apoyoSaludTipoActividadDAO.ActualizaFormato(apoyoSaludTipoActividadDTO);
        }

        public bool EliminarFormato(ApoyoSaludTipoActividadDTO apoyoSaludTipoActividadDTO)
        {
            return apoyoSaludTipoActividadDAO.EliminarFormato(apoyoSaludTipoActividadDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return apoyoSaludTipoActividadDAO.InsertarDatos(datos);
        }

    }
}
