using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class AlistamientoRepuestoCriticoComfuavinav
    {
        AlistamientoRepuestoCriticoComfuavinavDAO alistamientoRepuestoCriticoComfuavinavDAO = new();

        public List<AlistamientoRepuestoCriticoComfuavinavDTO> ObtenerLista()
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfuavinavDTO alistamientoRepuestoCriticoComfuavinavDTO)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.AgregarRegistro(alistamientoRepuestoCriticoComfuavinavDTO);
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

        public bool InsercionMasiva(IEnumerable<AlistamientoRepuestoCriticoComfuavinavDTO> alistamientoRepuestoCriticoComfuavinavDTO)
        {
            return alistamientoRepuestoCriticoComfuavinavDAO.InsercionMasiva(alistamientoRepuestoCriticoComfuavinavDTO);
        }

    }
}
