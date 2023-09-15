using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AlistamientoMaterialComfas
    {
        AlistamientoMaterialComfasDAO alistamientoMaterialComfasDAO = new();

        public List<AlistamientoMaterialComfasDTO> ObtenerLista()
        {
            return alistamientoMaterialComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO)
        {
            return alistamientoMaterialComfasDAO.AgregarRegistro(alistamientoMaterialComfasDTO);
        }

        public AlistamientoMaterialComfasDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO)
        {
            return alistamientoMaterialComfasDAO.ActualizaFormato(alistamientoMaterialComfasDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComfasDTO alistamientoMaterialComfasDTO)
        {
            return alistamientoMaterialComfasDAO.EliminarFormato(alistamientoMaterialComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialComfasDTO> alistamientoMaterialComfasDTO)
        {
            return alistamientoMaterialComfasDAO.InsercionMasiva(alistamientoMaterialComfasDTO);
        }

    }
}
