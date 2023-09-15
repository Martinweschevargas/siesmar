using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater
{
    public class ActosDisposicionFinal
    {
        ActosDisposicionFinalDAO actosDisposicionFinalDAO = new();

        public List<ActosDisposicionFinalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return actosDisposicionFinalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ActosDisposicionFinalDTO actosDisposicionFinalDTO, string? fecha)
        {
            return actosDisposicionFinalDAO.AgregarRegistro(actosDisposicionFinalDTO, fecha);
        }

        public ActosDisposicionFinalDTO EditarFormado(int Codigo)
        {
            return actosDisposicionFinalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActosDisposicionFinalDTO actosDisposicionFinalDTO)
        {
            return actosDisposicionFinalDAO.ActualizaFormato(actosDisposicionFinalDTO);
        }

        public bool EliminarFormato(ActosDisposicionFinalDTO actosDisposicionFinalDTO)
        {
            return actosDisposicionFinalDAO.EliminarFormato(actosDisposicionFinalDTO);
        }

        public bool EliminarCarga(ActosDisposicionFinalDTO actosDisposicionFinalDTO)
        {
            return actosDisposicionFinalDAO.EliminarCarga(actosDisposicionFinalDTO);
        }


        public string InsertarDatos(DataTable datos, string fecha)
        {
            return actosDisposicionFinalDAO.InsertarDatos(datos, fecha);
        }


    }
}
