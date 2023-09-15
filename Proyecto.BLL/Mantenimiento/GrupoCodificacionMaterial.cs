using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoCodificacionMaterial
    {
        readonly GrupoCodificacionMaterialDAO grupoCodificacionMaterialDAO = new();

        public List<GrupoCodificacionMaterialDTO> ObtenerGrupoCodificacionMaterials()
        {
            return grupoCodificacionMaterialDAO.ObtenerGrupoCodificacionMaterials();
        }

        public string AgregarGrupoCodificacionMaterial(GrupoCodificacionMaterialDTO grupoCodificacionMaterialDto)
        {
            return grupoCodificacionMaterialDAO.AgregarGrupoCodificacionMaterial(grupoCodificacionMaterialDto);
        }

        public GrupoCodificacionMaterialDTO BuscarGrupoCodificacionMaterialID(int Codigo)
        {
            return grupoCodificacionMaterialDAO.BuscarGrupoCodificacionMaterialID(Codigo);
        }

        public string ActualizarGrupoCodificacionMaterial(GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO)
        {
            return grupoCodificacionMaterialDAO.ActualizarGrupoCodificacionMaterial(grupoCodificacionMaterialDTO);
        }

        public bool EliminarGrupoCodificacionMaterial(GrupoCodificacionMaterialDTO grupoCodificacionMaterialDTO)
        {
            return grupoCodificacionMaterialDAO.EliminarGrupoCodificacionMaterial(grupoCodificacionMaterialDTO);
        }

    }
}
