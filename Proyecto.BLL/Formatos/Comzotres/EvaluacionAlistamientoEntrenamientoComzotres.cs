
using Marina.Siesmar.AccesoDatos.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzotres
{
    public class EvaluacionAlistamientoEntrenamientoComzotres
    {
        EvaluacionAlistamientoEntrenamientoComzotresDAO evaluacionAlistamientoEntrenamientoComzotresDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComzotresDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO, string? fecha)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComzotresDTO, fecha);
        }

        public EvaluacionAlistamientoEntrenamientoComzotresDTO EditarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComzotresDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComzotresDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.EliminarCarga(evaluacionAlistamientoEntrenamientoComzotresDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoEntrenamientoComzotresDAO.InsertarDatos(datos, fecha);
        }

    }
}
