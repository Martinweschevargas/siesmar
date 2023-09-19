using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class AlistamientoRepuestoCriticoComfuavinav
    {
        AlistamientoRepuestoCriticoComfuavinavDAO alistamientoRepuestoCriticoComfuavinavDAO = new();

        public List<AlistamientoRepuestoCriticoComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO, string? fecha)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.AgregarRegistro(alistamientoRepuestoCriticoComfuavinavDTO, fecha);
        }

        public AlistamientoRepuestoCriticoComfuavinavDTO BuscarFormato(int Codigo)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.ActualizaFormato(alistamientoRepuestoCriticoComfuavinavDTO);
        }

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.EliminarFormato(alistamientoRepuestoCriticoComfuavinavDTO);
        }

        public bool EliminarCarga(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.EliminarCarga(alistamientoRepuestoCriticoComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}
