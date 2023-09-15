
using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzouno
{
    public class EvaluacionAlistamientoEntrenamientoComzouno
    {
        EvaluacionAlistamientoEntrenamientoComzounoDAO evaluacionAlistamientoEntrenamientoComzounoDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO, string? fecha=null)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComzounoDTO, fecha);
        }

        public EvaluacionAlistamientoEntrenamientoComzounoDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComzounoDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComzounoDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComzounoDTO evaluacionAlistamientoEntrenamientoComzounoDTO)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.EliminarCarga(evaluacionAlistamientoEntrenamientoComzounoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoEntrenamientoComzounoDAO.InsertarDatos(datos, fecha);
        }

    }
}
