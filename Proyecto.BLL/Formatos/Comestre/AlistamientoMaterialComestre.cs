
using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class AlistamientoMaterialComestre
    {
        AlistamientoMaterialComestreDAO alistamientoMaterialComestreDAO = new();

        public List<AlistamientoMaterialComestreDTO> ObtenerLista()
        {
            return alistamientoMaterialComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialComestreDTO alistamientoMaterialComestreDTO)
        {
            return alistamientoMaterialComestreDAO.AgregarRegistro(alistamientoMaterialComestreDTO);
        }

        public AlistamientoMaterialComestreDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComestreDTO alistamientoMaterialComestreDTO)
        {
            return alistamientoMaterialComestreDAO.ActualizaFormato(alistamientoMaterialComestreDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComestreDTO alistamientoMaterialComestreDTO)
        {
            return alistamientoMaterialComestreDAO.EliminarFormato(alistamientoMaterialComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialComestreDTO> alistamientoMaterialComestreDTO)
        {
            return alistamientoMaterialComestreDAO.InsercionMasiva(alistamientoMaterialComestreDTO);
        }

    }
}
