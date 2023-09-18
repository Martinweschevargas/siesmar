
using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class AlistamientoCombustibleLubricanteJesehin
    {
        AlistamientoCombustibleLubricanteJesehinDAO alistamientoCombustibleLubricanteJesehinDAO = new();

        public List<AlistamientoCombustibleLubricanteJesehinDTO> ObtenerLista()
        {
            return alistamientoCombustibleLubricanteJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO)
        {
            return alistamientoCombustibleLubricanteJesehinDAO.AgregarRegistro(alistamientoCombustibleLubricanteJesehinDTO);
        }

        public AlistamientoCombustibleLubricanteJesehinDTO BuscarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO)
        {
            return alistamientoCombustibleLubricanteJesehinDAO.ActualizaFormato(alistamientoCombustibleLubricanteJesehinDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteJesehinDTO alistamientoCombustibleLubricanteJesehinDTO)
        {
            return alistamientoCombustibleLubricanteJesehinDAO.EliminarFormato(alistamientoCombustibleLubricanteJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteJesehinDTO> alistamientoCombustibleLubricanteJesehinDTO)
        {
            return alistamientoCombustibleLubricanteJesehinDAO.InsercionMasiva(alistamientoCombustibleLubricanteJesehinDTO);
        }

    }
}
