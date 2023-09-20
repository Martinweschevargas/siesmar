using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class EvaluacionAlistEntrenamientoComescuama
    {
        EvaluacionAlistEntrenamientoComescuamaDAO evaluacionAlistEntrenamientoComescuamaDAO = new();

        public List<EvaluacionAlistEntrenamientoComescuamaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO, string? fecha)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.AgregarRegistro(evaluacionAlistEntrenamientoComescuamaDTO, fecha);
        }

        public EvaluacionAlistEntrenamientoComescuamaDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.ActualizaFormato(evaluacionAlistEntrenamientoComescuamaDTO);
        }

        public bool EliminarFormato(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.EliminarFormato(evaluacionAlistEntrenamientoComescuamaDTO);
        }

        public bool EliminarCarga(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.EliminarCarga(evaluacionAlistEntrenamientoComescuamaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.InsertarDatos(datos, fecha);
        }

    }
}
