using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class MillaNavegacionUnidadComfas
    {
        MillaNavegacionUnidadComfasDAO millaNavegacionUnidadComfasDAO = new();

        public List<MillaNavegacionUnidadComfasDTO> ObtenerLista()
        {
            return millaNavegacionUnidadComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(MillaNavegacionUnidadComfasDTO millaNavegacionUnidadComfasDTO)
        {
            return millaNavegacionUnidadComfasDAO.AgregarRegistro(millaNavegacionUnidadComfasDTO);
        }

        public MillaNavegacionUnidadComfasDTO BuscarFormato(int Codigo)
        {
            return millaNavegacionUnidadComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MillaNavegacionUnidadComfasDTO millaNavegacionUnidadComfasDTO)
        {
            return millaNavegacionUnidadComfasDAO.ActualizaFormato(millaNavegacionUnidadComfasDTO);
        }

        public bool EliminarFormato(MillaNavegacionUnidadComfasDTO millaNavegacionUnidadComfasDTO)
        {
            return millaNavegacionUnidadComfasDAO.EliminarFormato(millaNavegacionUnidadComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<MillaNavegacionUnidadComfasDTO> millaNavegacionUnidadComfasDTO)
        {
            return millaNavegacionUnidadComfasDAO.InsercionMasiva(millaNavegacionUnidadComfasDTO);
        }

    }
}
