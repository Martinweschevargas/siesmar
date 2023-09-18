using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater
{
    public class EvaluacionExpedienteTecnicoObra
    {
        EvaluacionExpedienteTecnicoObraDAO evaluacionExpedienteTecnicoObraDAO = new();

        public List<EvaluacionExpedienteTecnicoObraDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionExpedienteTecnicoObraDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO, string? fecha)
        {
            return evaluacionExpedienteTecnicoObraDAO.AgregarRegistro(evaluacionExpedienteTecnicoObraDTO, fecha);
        }

        public EvaluacionExpedienteTecnicoObraDTO EditarFormato(int Codigo)
        {
            return evaluacionExpedienteTecnicoObraDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO)
        {
            return evaluacionExpedienteTecnicoObraDAO.ActualizaFormato(evaluacionExpedienteTecnicoObraDTO);
        }

        public bool EliminarFormato(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO)
        {
            return evaluacionExpedienteTecnicoObraDAO.EliminarFormato(evaluacionExpedienteTecnicoObraDTO);
        }

        public bool EliminarCarga(EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO)
        {
            return evaluacionExpedienteTecnicoObraDAO.EliminarCarga(evaluacionExpedienteTecnicoObraDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionExpedienteTecnicoObraDAO.InsertarDatos(datos, fecha);
        }


    }
}
