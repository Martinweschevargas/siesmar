using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class ArchivoActividadEjecucion
    {
        ArchivoActividadEjecucionDAO archivoActividadEjecucionDAO = new();

        public List<ArchivoActividadEjecucionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoActividadEjecucionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoActividadEjecucionDTO archivoActividadEjecucion, string? fecha)
        {
            return archivoActividadEjecucionDAO.AgregarRegistro(archivoActividadEjecucion, fecha);
        }

        public ArchivoActividadEjecucionDTO BuscarFormato(int Codigo)
        {
            return archivoActividadEjecucionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO)
        {
            return archivoActividadEjecucionDAO.ActualizaFormato(archivoActividadEjecucionDTO);
        }

        public bool EliminarFormato(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO)
        {
            return archivoActividadEjecucionDAO.EliminarFormato(archivoActividadEjecucionDTO);
        }

        public bool EliminarCarga(ArchivoActividadEjecucionDTO archivoActividadEjecucionDTO)
        {
            return archivoActividadEjecucionDAO.EliminarCarga(archivoActividadEjecucionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoActividadEjecucionDAO.InsertarDatos(datos, fecha);
        }

    }
}
