
using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class AlistamientoCombustibleLubricanteComestre
    {
        AlistamientoCombustibleLubricanteComestreDAO alistamientoCombustibleLubricanteComestreDAO = new();

        public List<AlistamientoCombustibleLubricanteComestreDTO> ObtenerLista()
        {
            return alistamientoCombustibleLubricanteComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComestreDTO alistamientoCombustibleLubricanteComestreDTO)
        {
            return alistamientoCombustibleLubricanteComestreDAO.AgregarRegistro(alistamientoCombustibleLubricanteComestreDTO);
        }

        public AlistamientoCombustibleLubricanteComestreDTO BuscarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComestreDTO alistamientoCombustibleLubricanteComestreDTO)
        {
            return alistamientoCombustibleLubricanteComestreDAO.ActualizaFormato(alistamientoCombustibleLubricanteComestreDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComestreDTO alistamientoCombustibleLubricanteComestreDTO)
        {
            return alistamientoCombustibleLubricanteComestreDAO.EliminarFormato(alistamientoCombustibleLubricanteComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteComestreDTO> alistamientoCombustibleLubricanteComestreDTO)
        {
            return alistamientoCombustibleLubricanteComestreDAO.InsercionMasiva(alistamientoCombustibleLubricanteComestreDTO);
        }

    }
}
