using Marina.Siesmar.AccesoDatos.Formatos.Centac;
using Marina.Siesmar.Entidades.Formatos.Centac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Centac
{
    public class EntrenamientoRealizadoComandancia
    {
        EntrenamientoRealizadoComandanciaDAO entrenamientoRealizadoComandanciaDAO = new();

        public List<EntrenamientoRealizadoComandanciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return entrenamientoRealizadoComandanciaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO, string? fecha = null)
        {
            return entrenamientoRealizadoComandanciaDAO.AgregarRegistro(entrenamientoRealizadoComandanciaDTO, fecha);
        }

        public EntrenamientoRealizadoComandanciaDTO EditarFormato(int Codigo)
        {
            return entrenamientoRealizadoComandanciaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO)
        {
            return entrenamientoRealizadoComandanciaDAO.ActualizaFormato(entrenamientoRealizadoComandanciaDTO);
        }

        public bool EliminarFormato(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO)
        {
            return entrenamientoRealizadoComandanciaDAO.EliminarFormato(entrenamientoRealizadoComandanciaDTO);
        }

        public bool EliminarCarga(EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO)
        {
            return entrenamientoRealizadoComandanciaDAO.EliminarCarga(entrenamientoRealizadoComandanciaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return entrenamientoRealizadoComandanciaDAO.InsertarDatos(datos, fecha);
        }

    }
}
