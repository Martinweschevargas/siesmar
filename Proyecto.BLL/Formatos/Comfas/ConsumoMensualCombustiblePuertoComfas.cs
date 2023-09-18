using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class ConsumoMensualCombustiblePuertoComfas
    {
        ConsumoMensualCombustiblePuertoComfasDAO consumoMensualCombustiblePuertoComfasDAO = new();

        public List<ConsumoMensualCombustiblePuertoComfasDTO> ObtenerLista()
        {
            return consumoMensualCombustiblePuertoComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(ConsumoMensualCombustiblePuertoComfasDTO consumoMensualCombustiblePuertoComfasDTO)
        {
            return consumoMensualCombustiblePuertoComfasDAO.AgregarRegistro(consumoMensualCombustiblePuertoComfasDTO);
        }

        public ConsumoMensualCombustiblePuertoComfasDTO BuscarFormato(int Codigo)
        {
            return consumoMensualCombustiblePuertoComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsumoMensualCombustiblePuertoComfasDTO consumoMensualCombustiblePuertoComfasDTO)
        {
            return consumoMensualCombustiblePuertoComfasDAO.ActualizaFormato(consumoMensualCombustiblePuertoComfasDTO);
        }

        public bool EliminarFormato(ConsumoMensualCombustiblePuertoComfasDTO consumoMensualCombustiblePuertoComfasDTO)
        {
            return consumoMensualCombustiblePuertoComfasDAO.EliminarFormato(consumoMensualCombustiblePuertoComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<ConsumoMensualCombustiblePuertoComfasDTO> consumoMensualCombustiblePuertoComfasDTO)
        {
            return consumoMensualCombustiblePuertoComfasDAO.InsercionMasiva(consumoMensualCombustiblePuertoComfasDTO);
        }

    }
}
