using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoDotacionVueloComfuavinav
    {
        EvaluacionAlistamientoDotacionVueloComfuavinavDAO evaluacionAlistamientoDotacionVueloComfuavinavDAO = new();

        public List<EvaluacionAlistamientoDotacionVueloComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO, string? fecha)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.AgregarRegistro(evaluacionAlistamientoDotacionVueloComfuavinavDTO, fecha);
        }

        public EvaluacionAlistamientoDotacionVueloComfuavinavDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.ActualizaFormato(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.EliminarFormato(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.EliminarCarga(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}

