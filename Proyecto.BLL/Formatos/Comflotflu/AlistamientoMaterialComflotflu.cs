
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class AlistamientoMaterialComflotflu
    {
        AlistamientoMaterialComflotfluDAO alistamientoMaterialComflotfluDAO = new();

        public List<AlistamientoMaterialComflotfluDTO> ObtenerLista()
        {
            return alistamientoMaterialComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialComflotfluDTO alistamientoMaterialComflotfluDTO)
        {
            return alistamientoMaterialComflotfluDAO.AgregarRegistro(alistamientoMaterialComflotfluDTO);
        }

        public AlistamientoMaterialComflotfluDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComflotfluDTO alistamientoMaterialComflotfluDTO)
        {
            return alistamientoMaterialComflotfluDAO.ActualizaFormato(alistamientoMaterialComflotfluDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComflotfluDTO alistamientoMaterialComflotfluDTO)
        {
            return alistamientoMaterialComflotfluDAO.EliminarFormato(alistamientoMaterialComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialComflotfluDTO> alistamientoMaterialComflotfluDTO)
        {
            return alistamientoMaterialComflotfluDAO.InsercionMasiva(alistamientoMaterialComflotfluDTO);
        }

    }
}
