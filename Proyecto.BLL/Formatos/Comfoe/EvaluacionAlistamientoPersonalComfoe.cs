
using Marina.Siesmar.AccesoDatos.Formatos.Comfoe;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfoe
{
    public class EvaluacionAlistamientoPersonalComfoe
    {
        EvaluacionAlistamientoPersonalComfoeDAO evaluacionAlistamientoPersonalComfoeDAO = new();

        public List<EvaluacionAlistamientoPersonalComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfoeDTO evaluacionAlistamientoPersonalComfoeDTO, string? fecha)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.AgregarRegistro(evaluacionAlistamientoPersonalComfoeDTO, fecha);
        }

        public EvaluacionAlistamientoPersonalComfoeDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComfoeDTO evaluacionAlistamientoPersonalComfoeDTO)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.ActualizaFormato(evaluacionAlistamientoPersonalComfoeDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfoeDTO evaluacionAlistamientoPersonalComfoeDTO)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.EliminarFormato(evaluacionAlistamientoPersonalComfoeDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComfoeDTO evaluacionAlistamientoPersonalComfoeDTO)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.EliminarCarga(evaluacionAlistamientoPersonalComfoeDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoPersonalComfoeDAO.InsertarDatos(datos, fecha);
        }

    }
}
