using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class CuadroOperativosEntrenamientoOperacionComfas
    {
        CuadroOperativosEntrenamientoOperacionComfasDAO cuadroOperativosEntrenamientoOperacionComfasDAO = new();

        public List<CuadroOperativosEntrenamientoOperacionComfasDTO> ObtenerLista()
        {
            return cuadroOperativosEntrenamientoOperacionComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            return cuadroOperativosEntrenamientoOperacionComfasDAO.AgregarRegistro(cuadroOperativosEntrenamientoOperacionComfasDTO);
        }

        public CuadroOperativosEntrenamientoOperacionComfasDTO BuscarFormato(int Codigo)
        {
            return cuadroOperativosEntrenamientoOperacionComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            return cuadroOperativosEntrenamientoOperacionComfasDAO.ActualizaFormato(cuadroOperativosEntrenamientoOperacionComfasDTO);
        }

        public bool EliminarFormato(CuadroOperativosEntrenamientoOperacionComfasDTO cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            return cuadroOperativosEntrenamientoOperacionComfasDAO.EliminarFormato(cuadroOperativosEntrenamientoOperacionComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<CuadroOperativosEntrenamientoOperacionComfasDTO> cuadroOperativosEntrenamientoOperacionComfasDTO)
        {
            return cuadroOperativosEntrenamientoOperacionComfasDAO.InsercionMasiva(cuadroOperativosEntrenamientoOperacionComfasDTO);
        }

    }
}
