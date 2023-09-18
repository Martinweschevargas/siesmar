using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class EvaluacionAlistPersonalComescuama
    {
        EvaluacionAlistPersonalComescuamaDAO evaluacionAlistPersonalComescuamaDAO = new();

        public List<EvaluacionAlistPersonalComescuamaDTO> ObtenerLista(int? CargaId = null)
        {
            return evaluacionAlistPersonalComescuamaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO)
        {
            return evaluacionAlistPersonalComescuamaDAO.AgregarRegistro(evaluacionAlistPersonalComescuamaDTO);
        }

        public EvaluacionAlistPersonalComescuamaDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistPersonalComescuamaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO)
        {
            return evaluacionAlistPersonalComescuamaDAO.ActualizaFormato(evaluacionAlistPersonalComescuamaDTO);
        }

        public bool EliminarFormato(EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO)
        {
            return evaluacionAlistPersonalComescuamaDAO.EliminarFormato(evaluacionAlistPersonalComescuamaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return evaluacionAlistPersonalComescuamaDAO.InsertarDatos(datos);
        }

    }
}
