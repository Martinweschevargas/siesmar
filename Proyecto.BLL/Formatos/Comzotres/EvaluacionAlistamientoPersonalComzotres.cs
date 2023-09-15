
using Marina.Siesmar.AccesoDatos.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzotres
{
    public class EvaluacionAlistamientoPersonalComzotres
    {
        EvaluacionAlistamientoPersonalComzotresDAO evaluacionAlistamientoPersonalComzotresDAO = new();

        public List<EvaluacionAlistamientoPersonalComzotresDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO, string? fecha)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.AgregarRegistro(evaluacionAlistamientoPersonalComzotresDTO, fecha);
        }

        public EvaluacionAlistamientoPersonalComzotresDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.ActualizaFormato(evaluacionAlistamientoPersonalComzotresDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.EliminarFormato(evaluacionAlistamientoPersonalComzotresDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.EliminarCarga(evaluacionAlistamientoPersonalComzotresDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoPersonalComzotresDAO.InsertarDatos(datos, fecha);
        }
    }
}
