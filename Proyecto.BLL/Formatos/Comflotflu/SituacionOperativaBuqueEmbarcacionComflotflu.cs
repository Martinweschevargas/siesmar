
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class SituacionOperativaBuqueEmbarcacionComflotflu
    {
        SituacionOperativaBuqueEmbarcacionComflotfluDAO situacionOperativaBuqueEmbarcacionComflotfluDAO = new();

        public List<SituacionOperativaBuqueEmbarcacionComflotfluDTO> ObtenerLista()
        {
            return situacionOperativaBuqueEmbarcacionComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperativaBuqueEmbarcacionComflotfluDTO situacionOperativaBuqueEmbarcacionComflotfluDTO)
        {
            return situacionOperativaBuqueEmbarcacionComflotfluDAO.AgregarRegistro(situacionOperativaBuqueEmbarcacionComflotfluDTO);
        }

        public SituacionOperativaBuqueEmbarcacionComflotfluDTO BuscarFormato(int Codigo)
        {
            return situacionOperativaBuqueEmbarcacionComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperativaBuqueEmbarcacionComflotfluDTO situacionOperativaBuqueEmbarcacionComflotfluDTO)
        {
            return situacionOperativaBuqueEmbarcacionComflotfluDAO.ActualizaFormato(situacionOperativaBuqueEmbarcacionComflotfluDTO);
        }

        public bool EliminarFormato(SituacionOperativaBuqueEmbarcacionComflotfluDTO situacionOperativaBuqueEmbarcacionComflotfluDTO)
        {
            return situacionOperativaBuqueEmbarcacionComflotfluDAO.EliminarFormato(situacionOperativaBuqueEmbarcacionComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperativaBuqueEmbarcacionComflotfluDTO> situacionOperativaBuqueEmbarcacionComflotfluDTO)
        {
            return situacionOperativaBuqueEmbarcacionComflotfluDAO.InsercionMasiva(situacionOperativaBuqueEmbarcacionComflotfluDTO);
        }

    }
}
