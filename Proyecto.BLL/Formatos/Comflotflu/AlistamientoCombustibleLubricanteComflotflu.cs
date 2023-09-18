
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class AlistamientoCombustibleLubricanteComflotflu
    {
        AlistamientoCombustibleLubricanteComflotfluDAO alistamientoCombustibleLubricanteComflotfluDAO = new();

        public List<AlistamientoCombustibleLubricanteComflotfluDTO> ObtenerLista()
        {
            return alistamientoCombustibleLubricanteComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComflotfluDTO alistamientoCombustibleLubricanteComflotfluDTO)
        {
            return alistamientoCombustibleLubricanteComflotfluDAO.AgregarRegistro(alistamientoCombustibleLubricanteComflotfluDTO);
        }

        public AlistamientoCombustibleLubricanteComflotfluDTO BuscarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComflotfluDTO alistamientoCombustibleLubricanteComflotfluDTO)
        {
            return alistamientoCombustibleLubricanteComflotfluDAO.ActualizaFormato(alistamientoCombustibleLubricanteComflotfluDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComflotfluDTO alistamientoCombustibleLubricanteComflotfluDTO)
        {
            return alistamientoCombustibleLubricanteComflotfluDAO.EliminarFormato(alistamientoCombustibleLubricanteComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteComflotfluDTO> alistamientoCombustibleLubricanteComflotfluDTO)
        {
            return alistamientoCombustibleLubricanteComflotfluDAO.InsercionMasiva(alistamientoCombustibleLubricanteComflotfluDTO);
        }

    }
}
