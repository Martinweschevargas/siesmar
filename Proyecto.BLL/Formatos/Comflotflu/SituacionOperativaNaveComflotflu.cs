
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class SituacionOperativaNaveComflotflu
    {
        SituacionOperativaNaveComflotfluDAO situacionOperativaNaveComflotfluDAO = new();

        public List<SituacionOperativaNaveComflotfluDTO> ObtenerLista()
        {
            return situacionOperativaNaveComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO)
        {
            return situacionOperativaNaveComflotfluDAO.AgregarRegistro(situacionOperativaNaveComflotfluDTO);
        }

        public SituacionOperativaNaveComflotfluDTO BuscarFormato(int Codigo)
        {
            return situacionOperativaNaveComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO)
        {
            return situacionOperativaNaveComflotfluDAO.ActualizaFormato(situacionOperativaNaveComflotfluDTO);
        }

        public bool EliminarFormato(SituacionOperativaNaveComflotfluDTO situacionOperativaNaveComflotfluDTO)
        {
            return situacionOperativaNaveComflotfluDAO.EliminarFormato(situacionOperativaNaveComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperativaNaveComflotfluDTO> situacionOperativaNaveComflotfluDTO)
        {
            return situacionOperativaNaveComflotfluDAO.InsercionMasiva(situacionOperativaNaveComflotfluDTO);
        }

    }
}
