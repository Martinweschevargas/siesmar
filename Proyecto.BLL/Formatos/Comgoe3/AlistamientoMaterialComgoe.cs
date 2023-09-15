
using Marina.Siesmar.AccesoDatos.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comgoe3
{
    public class AlistamientoMaterialComgoe
    {
        AlistamientoMaterialComgoeDAO alistamientoMaterialComgoeDAO = new();

        public List<AlistamientoMaterialComgoeDTO> ObtenerLista()
        {
            return alistamientoMaterialComgoeDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialComgoeDTO alistamientoMaterialComgoeDTO)
        {
            return alistamientoMaterialComgoeDAO.AgregarRegistro(alistamientoMaterialComgoeDTO);
        }

        public AlistamientoMaterialComgoeDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialComgoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComgoeDTO alistamientoMaterialComgoeDTO)
        {
            return alistamientoMaterialComgoeDAO.ActualizaFormato(alistamientoMaterialComgoeDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComgoeDTO alistamientoMaterialComgoeDTO)
        {
            return alistamientoMaterialComgoeDAO.EliminarFormato(alistamientoMaterialComgoeDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialComgoeDTO> alistamientoMaterialComgoeDTO)
        {
            return alistamientoMaterialComgoeDAO.InsercionMasiva(alistamientoMaterialComgoeDTO);
        }

    }
}
