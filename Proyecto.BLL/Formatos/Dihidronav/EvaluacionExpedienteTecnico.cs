using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class EvaluacionExpedienteTecnico
    {
        EvaluacionExpedienteTecnicoDAO evaluacionExpedienteTecnicoDAO = new();

        public List<EvaluacionExpedienteTecnicoDTO> ObtenerLista(int? CargaId = null)
        {
            return evaluacionExpedienteTecnicoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnico)
        {
            return evaluacionExpedienteTecnicoDAO.AgregarRegistro(evaluacionExpedienteTecnico);
        }

        public EvaluacionExpedienteTecnicoDTO BuscarFormato(int Codigo)
        {
            return evaluacionExpedienteTecnicoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO)
        {
            return evaluacionExpedienteTecnicoDAO.ActualizaFormato(evaluacionExpedienteTecnicoDTO);
        }

        public bool EliminarFormato(EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO)
        {
            return evaluacionExpedienteTecnicoDAO.EliminarFormato( evaluacionExpedienteTecnicoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return evaluacionExpedienteTecnicoDAO.InsertarDatos(datos);
        }


    }
}
