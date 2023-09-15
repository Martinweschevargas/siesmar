using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class ConsumoMensualLubricanteNavegacionComfas
    {
        ConsumoMensualLubricanteNavegacionComfasDAO consumoMensualLubricanteNavegacionComfasDAO = new();

        public List<ConsumoMensualLubricanteNavegacionComfasDTO> ObtenerLista()
        {
            return consumoMensualLubricanteNavegacionComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO)
        {
            return consumoMensualLubricanteNavegacionComfasDAO.AgregarRegistro(consumoMensualLubricanteNavegacionComfasDTO);
        }

        public ConsumoMensualLubricanteNavegacionComfasDTO BuscarFormato(int Codigo)
        {
            return consumoMensualLubricanteNavegacionComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO)
        {
            return consumoMensualLubricanteNavegacionComfasDAO.ActualizaFormato(consumoMensualLubricanteNavegacionComfasDTO);
        }

        public bool EliminarFormato(ConsumoMensualLubricanteNavegacionComfasDTO consumoMensualLubricanteNavegacionComfasDTO)
        {
            return consumoMensualLubricanteNavegacionComfasDAO.EliminarFormato(consumoMensualLubricanteNavegacionComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<ConsumoMensualLubricanteNavegacionComfasDTO> consumoMensualLubricanteNavegacionComfasDTO)
        {
            return consumoMensualLubricanteNavegacionComfasDAO.InsercionMasiva(consumoMensualLubricanteNavegacionComfasDTO);
        }

    }
}
