using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dincydet
{
    public class ArchivoActividadCulminadoExito
    {
        ArchivoActividadCulminadoExitoDAO archivoActividadCulminadoExitoDAO = new();

        public List<ArchivoActividadCulminadoExitoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return archivoActividadCulminadoExitoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExito, string? fecha)
        {
            return archivoActividadCulminadoExitoDAO.AgregarRegistro(archivoActividadCulminadoExito, fecha);
        }

        public ArchivoActividadCulminadoExitoDTO EditarFormato(int Codigo)
        {
            return archivoActividadCulminadoExitoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO)
        {
            return archivoActividadCulminadoExitoDAO.ActualizaFormato(archivoActividadCulminadoExitoDTO);
        }

        public bool EliminarFormato(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO)
        {
            return archivoActividadCulminadoExitoDAO.EliminarFormato(archivoActividadCulminadoExitoDTO);
        }

        public bool EliminarCarga(ArchivoActividadCulminadoExitoDTO archivoActividadCulminadoExitoDTO)
        {
            return archivoActividadCulminadoExitoDAO.EliminarCarga(archivoActividadCulminadoExitoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return archivoActividadCulminadoExitoDAO.InsertarDatos(datos, fecha);
        }

    }
}
