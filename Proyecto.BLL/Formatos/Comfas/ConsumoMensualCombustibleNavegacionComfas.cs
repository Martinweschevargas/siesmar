using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class ConsumoMensualCombustibleNavegacionComfas
    {
        ConsumoMensualCombustibleNavegacionComfasDAO consumoMensualCombustibleNavegacionComfasDAO = new();

        public List<ConsumoMensualCombustibleNavegacionComfasDTO> ObtenerLista()
        {
            return consumoMensualCombustibleNavegacionComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO)
        {
            return consumoMensualCombustibleNavegacionComfasDAO.AgregarRegistro(consumoMensualCombustibleNavegacionComfasDTO);
        }

        public ConsumoMensualCombustibleNavegacionComfasDTO BuscarFormato(int Codigo)
        {
            return consumoMensualCombustibleNavegacionComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO)
        {
            return consumoMensualCombustibleNavegacionComfasDAO.ActualizaFormato(consumoMensualCombustibleNavegacionComfasDTO);
        }

        public bool EliminarFormato(ConsumoMensualCombustibleNavegacionComfasDTO consumoMensualCombustibleNavegacionComfasDTO)
        {
            return consumoMensualCombustibleNavegacionComfasDAO.EliminarFormato(consumoMensualCombustibleNavegacionComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<ConsumoMensualCombustibleNavegacionComfasDTO> consumoMensualCombustibleNavegacionComfasDTO)
        {
            return consumoMensualCombustibleNavegacionComfasDAO.InsercionMasiva(consumoMensualCombustibleNavegacionComfasDTO);
        }

    }
}
