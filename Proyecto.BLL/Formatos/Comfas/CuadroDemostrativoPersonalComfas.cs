using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class CuadroDemostrativoPersonalComfas
    {
        CuadroDemostrativoPersonalComfasDAO cuadroDemostrativoPersonalComfasDAO = new();

        public List<CuadroDemostrativoPersonalComfasDTO> ObtenerLista()
        {
            return cuadroDemostrativoPersonalComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO)
        {
            return cuadroDemostrativoPersonalComfasDAO.AgregarRegistro(cuadroDemostrativoPersonalComfasDTO);
        }

        public CuadroDemostrativoPersonalComfasDTO BuscarFormato(int Codigo)
        {
            return cuadroDemostrativoPersonalComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO)
        {
            return cuadroDemostrativoPersonalComfasDAO.ActualizaFormato(cuadroDemostrativoPersonalComfasDTO);
        }

        public bool EliminarFormato(CuadroDemostrativoPersonalComfasDTO cuadroDemostrativoPersonalComfasDTO)
        {
            return cuadroDemostrativoPersonalComfasDAO.EliminarFormato(cuadroDemostrativoPersonalComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<CuadroDemostrativoPersonalComfasDTO> cuadroDemostrativoPersonalComfasDTO)
        {
            return cuadroDemostrativoPersonalComfasDAO.InsercionMasiva(cuadroDemostrativoPersonalComfasDTO);
        }

    }
}
