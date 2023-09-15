
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class FormatoSituacionOperatividadEquiposComflotflu
    {
        FormatoSituacionOperatividadEquiposComflotfluDAO formatoSituacionOperatividadEquiposComflotfluDAO = new();

        public List<FormatoSituacionOperatividadEquiposComflotfluDTO> ObtenerLista()
        {
            return formatoSituacionOperatividadEquiposComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(FormatoSituacionOperatividadEquiposComflotfluDTO formatoSituacionOperatividadEquiposComflotfluDTO)
        {
            return formatoSituacionOperatividadEquiposComflotfluDAO.AgregarRegistro(formatoSituacionOperatividadEquiposComflotfluDTO);
        }

        public FormatoSituacionOperatividadEquiposComflotfluDTO BuscarFormato(int Codigo)
        {
            return formatoSituacionOperatividadEquiposComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(FormatoSituacionOperatividadEquiposComflotfluDTO formatoSituacionOperatividadEquiposComflotfluDTO)
        {
            return formatoSituacionOperatividadEquiposComflotfluDAO.ActualizaFormato(formatoSituacionOperatividadEquiposComflotfluDTO);
        }

        public bool EliminarFormato(FormatoSituacionOperatividadEquiposComflotfluDTO formatoSituacionOperatividadEquiposComflotfluDTO)
        {
            return formatoSituacionOperatividadEquiposComflotfluDAO.EliminarFormato(formatoSituacionOperatividadEquiposComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<FormatoSituacionOperatividadEquiposComflotfluDTO> formatoSituacionOperatividadEquiposComflotfluDTO)
        {
            return formatoSituacionOperatividadEquiposComflotfluDAO.InsercionMasiva(formatoSituacionOperatividadEquiposComflotfluDTO);
        }

    }
}
