using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class ConsumoMensualLubricantePuertoComfas
    {
        ConsumoMensualLubricantePuertoComfasDAO consumoMensualLubricantePuertoComfasDAO = new();

        public List<ConsumoMensualLubricantePuertoComfasDTO> ObtenerLista()
        {
            return consumoMensualLubricantePuertoComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO)
        {
            return consumoMensualLubricantePuertoComfasDAO.AgregarRegistro(consumoMensualLubricantePuertoComfasDTO);
        }

        public ConsumoMensualLubricantePuertoComfasDTO BuscarFormato(int Codigo)
        {
            return consumoMensualLubricantePuertoComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO)
        {
            return consumoMensualLubricantePuertoComfasDAO.ActualizaFormato(consumoMensualLubricantePuertoComfasDTO);
        }

        public bool EliminarFormato(ConsumoMensualLubricantePuertoComfasDTO consumoMensualLubricantePuertoComfasDTO)
        {
            return consumoMensualLubricantePuertoComfasDAO.EliminarFormato(consumoMensualLubricantePuertoComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<ConsumoMensualLubricantePuertoComfasDTO> consumoMensualLubricantePuertoComfasDTO)
        {
            return consumoMensualLubricantePuertoComfasDAO.InsercionMasiva(consumoMensualLubricantePuertoComfasDTO);
        }

    }
}
