using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirnotemat;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirnotemat;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirnotemat
{
    public class RegistroEvaluacionMuestra
    {
        RegistroEvaluacionMuestraDAO registroEvaluacionMuestraDAO = new();

        public List<RegistroEvaluacionMuestraDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return registroEvaluacionMuestraDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(RegistroEvaluacionMuestraDTO registroEvaluacionMuestra, string? fecha)
        {
            return registroEvaluacionMuestraDAO.AgregarRegistro(registroEvaluacionMuestra, fecha);
        }

        public RegistroEvaluacionMuestraDTO EditarFormato(int Codigo)
        {
            return registroEvaluacionMuestraDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO)
        {
            return registroEvaluacionMuestraDAO.ActualizaFormato(registroEvaluacionMuestraDTO);
        }

        public bool EliminarFormato(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO)
        {
            return registroEvaluacionMuestraDAO.EliminarFormato(registroEvaluacionMuestraDTO);
        }

        public bool EliminarCarga(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO)
        {
            return registroEvaluacionMuestraDAO.EliminarCarga(registroEvaluacionMuestraDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return registroEvaluacionMuestraDAO.InsertarDatos(datos, fecha);
        }

    }
}
