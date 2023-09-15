using Marina.Siesmar.AccesoDatos.Formatos.Jemgemar;
using Marina.Siesmar.Entidades.Formatos.Jemgemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jemgemar
{
    public class ArchivoRelacionTipoReunion
    {
        ArchivoRelacionTipoReunionDAO archivoRelacionTipoReunionDAO = new();

        public List<ArchivoRelacionTipoReunionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoRelacionTipoReunionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO, string? fecha)
        {
            return archivoRelacionTipoReunionDAO.AgregarRegistro(archivoRelacionTipoReunionDTO, fecha);
        }

        public ArchivoRelacionTipoReunionDTO EditarFormato(int Codigo)
        {
            return archivoRelacionTipoReunionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO)
        {
            return archivoRelacionTipoReunionDAO.ActualizaFormato(archivoRelacionTipoReunionDTO);
        }

        public bool EliminarFormato(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO)
        {
            return archivoRelacionTipoReunionDAO.EliminarFormato(archivoRelacionTipoReunionDTO);
        }

        public bool EliminarCarga(ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO)
        {
            return archivoRelacionTipoReunionDAO.EliminarCarga(archivoRelacionTipoReunionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoRelacionTipoReunionDAO.InsertarDatos(datos, fecha);
        }
    }
}
