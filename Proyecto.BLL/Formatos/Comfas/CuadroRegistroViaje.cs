using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class CuadroRegistroViaje
    {
        CuadroRegistroViajeDAO cuadroRegistroViajeDAO = new();

        public List<CuadroRegistroViajeDTO> ObtenerLista()
        {
            return cuadroRegistroViajeDAO.ObtenerLista();
        }

        public string AgregarRegistro(CuadroRegistroViajeDTO cuadroRegistroViajeDTO)
        {
            return cuadroRegistroViajeDAO.AgregarRegistro(cuadroRegistroViajeDTO);
        }

        public CuadroRegistroViajeDTO BuscarFormato(int Codigo)
        {
            return cuadroRegistroViajeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CuadroRegistroViajeDTO cuadroRegistroViajeDTO)
        {
            return cuadroRegistroViajeDAO.ActualizaFormato(cuadroRegistroViajeDTO);
        }

        public bool EliminarFormato(CuadroRegistroViajeDTO cuadroRegistroViajeDTO)
        {
            return cuadroRegistroViajeDAO.EliminarFormato(cuadroRegistroViajeDTO);
        }

        public bool InsercionMasiva(IEnumerable<CuadroRegistroViajeDTO> cuadroRegistroViajeDTO)
        {
            return cuadroRegistroViajeDAO.InsercionMasiva(cuadroRegistroViajeDTO);
        }

    }
}
