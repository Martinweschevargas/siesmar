using Marina.Siesmar.AccesoDatos.Formatos.Diresgrum;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresgrum
{
    public class PoblacionEscuelaGrumete
    {
        PoblacionEscuelaGrumeteDAO poblacionEscuelaGrumeteDAO = new();

        public List<PoblacionEscuelaGrumeteDTO> ObtenerLista()
        {
            return poblacionEscuelaGrumeteDAO.ObtenerLista();
        }

        public string AgregarRegistro(PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO)
        {
            return poblacionEscuelaGrumeteDAO.AgregarRegistro(poblacionEscuelaGrumeteDTO);
        }

        public PoblacionEscuelaGrumeteDTO EditarFormato(int Codigo)
        {
            return poblacionEscuelaGrumeteDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO)
        {
            return poblacionEscuelaGrumeteDAO.ActualizaFormato(poblacionEscuelaGrumeteDTO);
        }

        public bool EliminarFormato(PoblacionEscuelaGrumeteDTO poblacionEscuelaGrumeteDTO)
        {
            return poblacionEscuelaGrumeteDAO.EliminarFormato(poblacionEscuelaGrumeteDTO);
        }

        public bool InsertarRegistros(IEnumerable<PoblacionEscuelaGrumeteDTO> poblacionEscuelaGrumeteDTO)
        {
            return InsertarRegistros(poblacionEscuelaGrumeteDTO);
        }

    }
}
