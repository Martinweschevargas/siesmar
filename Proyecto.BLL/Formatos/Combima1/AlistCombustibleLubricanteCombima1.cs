using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class AlistCombustibleLubricanteCombima1
    {
        AlistCombustibleLubricanteCombima1DAO alistCombustibleLubricanteCombima1DAO = new();

        public List<AlistCombustibleLubricanteCombima1DTO> ObtenerLista()
        {
            return alistCombustibleLubricanteCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO)
        {
            return alistCombustibleLubricanteCombima1DAO.AgregarRegistro(alistCombustibleLubricanteCombima1DTO);
        }

        public AlistCombustibleLubricanteCombima1DTO BuscarFormato(int Codigo)
        {
            return alistCombustibleLubricanteCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO)
        {
            return alistCombustibleLubricanteCombima1DAO.ActualizaFormato(alistCombustibleLubricanteCombima1DTO);
        }

        public bool EliminarFormato(AlistCombustibleLubricanteCombima1DTO alistCombustibleLubricanteCombima1DTO)
        {
            return alistCombustibleLubricanteCombima1DAO.EliminarFormato(alistCombustibleLubricanteCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistCombustibleLubricanteCombima1DTO> alistCombustibleLubricanteCombima1DTO)
        {
            return alistCombustibleLubricanteCombima1DAO.InsercionMasiva(alistCombustibleLubricanteCombima1DTO);
        }

    }
}
