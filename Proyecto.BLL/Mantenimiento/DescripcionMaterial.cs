using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DescripcionMaterial
    {
        readonly DescripcionMaterialDAO descripcionMaterialDAO = new();

        public List<DescripcionMaterialDTO> ObtenerDescripcionMaterials()
        {
            return descripcionMaterialDAO.ObtenerDescripcionMaterials();
        }

        public string AgregarDescripcionMaterial(DescripcionMaterialDTO descripcionMaterialDto)
        {
            return descripcionMaterialDAO.AgregarDescripcionMaterial(descripcionMaterialDto);
        }

        public DescripcionMaterialDTO BuscarDescripcionMaterialID(int Codigo)
        {
            return descripcionMaterialDAO.BuscarDescripcionMaterialID(Codigo);
        }

        public string ActualizarDescripcionMaterial(DescripcionMaterialDTO descripcionMaterialDto)
        {
            return descripcionMaterialDAO.ActualizarDescripcionMaterial(descripcionMaterialDto);
        }

        public string EliminarDescripcionMaterial(DescripcionMaterialDTO descripcionMaterialDto)
        {
            return descripcionMaterialDAO.EliminarDescripcionMaterial(descripcionMaterialDto);
        }

    }
}
