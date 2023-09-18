using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class AlistamientoMaterialComescla
    {
        AlistamientoMaterialComesclaDAO alistamientoMaterialComesclaDAO = new();

        public List<AlistamientoMaterialComesclaDTO> ObtenerLista()
        {
            return alistamientoMaterialComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialComesclaDTO alistamientoMaterialComesclaDTO)
        {
            return alistamientoMaterialComesclaDAO.AgregarRegistro(alistamientoMaterialComesclaDTO);
        }

        public AlistamientoMaterialComesclaDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComesclaDTO alistamientoMaterialComesclaDTO)
        {
            return alistamientoMaterialComesclaDAO.ActualizaFormato(alistamientoMaterialComesclaDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComesclaDTO alistamientoMaterialComesclaDTO)
        {
            return alistamientoMaterialComesclaDAO.EliminarFormato(alistamientoMaterialComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoMaterialComesclaDTO> alistamientoMaterialComesclaDTO)
        {
            return alistamientoMaterialComesclaDAO.InsercionMasiva(alistamientoMaterialComesclaDTO);
        }

    }
}
