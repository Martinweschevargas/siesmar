using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AlistamientoMunicionComfas
    {
        AlistamientoMunicionComfasDAO alistamientoMunicionComfasDAO = new();

        public List<AlistamientoMunicionComfasDTO> ObtenerLista()
        {
            return alistamientoMunicionComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO)
        {
            return alistamientoMunicionComfasDAO.AgregarRegistro(alistamientoMunicionComfasDTO);
        }

        public AlistamientoMunicionComfasDTO BuscarFormato(int Codigo)
        {
            return alistamientoMunicionComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO)
        {
            return alistamientoMunicionComfasDAO.ActualizaFormato(alistamientoMunicionComfasDTO);
        }

        public bool EliminarFormato(AlistamientoMunicionComfasDTO alistamientoMunicionComfasDTO)
        {
            return alistamientoMunicionComfasDAO.EliminarFormato(alistamientoMunicionComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMunicionComfasDTO> alistamientoMunicionComfasDTO)
        {
            return alistamientoMunicionComfasDAO.InsercionMasiva(alistamientoMunicionComfasDTO);
        }

    }
}
