
using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class AlistamientoMaterialJesehin
    {
        AlistamientoMaterialJesehinDAO alistamientoMaterialJesehinDAO = new();

        public List<AlistamientoMaterialJesehinDTO> ObtenerLista()
        {
            return alistamientoMaterialJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO)
        {
            return alistamientoMaterialJesehinDAO.AgregarRegistro(alistamientoMaterialJesehinDTO);
        }

        public AlistamientoMaterialJesehinDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO)
        {
            return alistamientoMaterialJesehinDAO.ActualizaFormato(alistamientoMaterialJesehinDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialJesehinDTO alistamientoMaterialJesehinDTO)
        {
            return alistamientoMaterialJesehinDAO.EliminarFormato(alistamientoMaterialJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialJesehinDTO> alistamientoMaterialJesehinDTO)
        {
            return alistamientoMaterialJesehinDAO.InsercionMasiva(alistamientoMaterialJesehinDTO);
        }

    }
}
