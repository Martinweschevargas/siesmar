
using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzouno
{
    public class EvaluacionAlistamientoPersonalComzouno
    {
        EvaluacionAlistamientoPersonalComzounoDAO evaluacionAlistamientoPersonalComzounoDAO = new();

        public List<EvaluacionAlistamientoPersonalComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO, string? fecha = null)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.AgregarRegistro(evaluacionAlistamientoPersonalComzounoDTO, fecha);
        }

        public EvaluacionAlistamientoPersonalComzounoDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.ActualizaFormato(evaluacionAlistamientoPersonalComzounoDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.EliminarFormato(evaluacionAlistamientoPersonalComzounoDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.EliminarCarga(evaluacionAlistamientoPersonalComzounoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoPersonalComzounoDAO.InsertarDatos(datos, fecha);
        }

    }
}
