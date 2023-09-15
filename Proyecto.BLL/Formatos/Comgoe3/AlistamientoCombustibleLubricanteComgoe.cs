
using Marina.Siesmar.AccesoDatos.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comgoe3
{
    public class AlistamientoCombustibleLubricanteComgoe
    {
        AlistamientoCombustibleLubricanteComgoeDAO alistamientoCombustibleLubricanteComgoeDAO = new();

        public List<AlistamientoCombustibleLubricanteComgoeDTO> ObtenerLista()
        {
            return alistamientoCombustibleLubricanteComgoeDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComgoeDTO alistamientoCombustibleLubricanteComgoeDTO)
        {
            return alistamientoCombustibleLubricanteComgoeDAO.AgregarRegistro(alistamientoCombustibleLubricanteComgoeDTO);
        }

        public AlistamientoCombustibleLubricanteComgoeDTO BuscarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteComgoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComgoeDTO alistamientoCombustibleLubricanteComgoeDTO)
        {
            return alistamientoCombustibleLubricanteComgoeDAO.ActualizaFormato(alistamientoCombustibleLubricanteComgoeDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComgoeDTO alistamientoCombustibleLubricanteComgoeDTO)
        {
            return alistamientoCombustibleLubricanteComgoeDAO.EliminarFormato(alistamientoCombustibleLubricanteComgoeDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteComgoeDTO> alistamientoCombustibleLubricanteComgoeDTO)
        {
            return alistamientoCombustibleLubricanteComgoeDAO.InsercionMasiva(alistamientoCombustibleLubricanteComgoeDTO);
        }

    }
}
