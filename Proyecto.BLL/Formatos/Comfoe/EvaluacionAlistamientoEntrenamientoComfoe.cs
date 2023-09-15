
using Marina.Siesmar.AccesoDatos.Formatos.Comfoe;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfoe
{
    public class EvaluacionAlistamientoEntrenamientoComfoe
    {
        EvaluacionAlistamientoEntrenamientoComfoeDAO evaluacionAlistamientoEntrenamientoComfoeDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComfoeDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO, string? fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfoeDTO, fecha);
        }

        public EvaluacionAlistamientoEntrenamientoComfoeDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComfoeDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComfoeDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.EliminarCarga(evaluacionAlistamientoEntrenamientoComfoeDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfoeDAO.InsertarDatos(datos, fecha);
        }

    }
}
