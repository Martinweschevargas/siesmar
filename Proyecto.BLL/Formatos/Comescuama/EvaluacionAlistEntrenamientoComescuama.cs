using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class EvaluacionAlistEntrenamientoComescuama
    {
        EvaluacionAlistEntrenamientoComescuamaDAO evaluacionAlistEntrenamientoComescuamaDAO = new();

        public List<EvaluacionAlistEntrenamientoComescuamaDTO> ObtenerLista(int? CargaId = null)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.AgregarRegistro(evaluacionAlistEntrenamientoComescuamaDTO);
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

        public string InsertarDatos(DataTable datos)
        {
            return evaluacionAlistEntrenamientoComescuamaDAO.InsertarDatos(datos);
        }

    }
}
