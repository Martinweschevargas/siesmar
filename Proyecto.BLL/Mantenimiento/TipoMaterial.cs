using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoMaterial
    {
        readonly TipoMaterialDAO tipoMaterialDAO = new();

        public List<TipoMaterialDTO> ObtenerTipoMaterials()
        {
            return tipoMaterialDAO.ObtenerTipoMaterials();
        }

        public string AgregarTipoMaterial(TipoMaterialDTO tipoMaterialDto)
        {
            return tipoMaterialDAO.AgregarTipoMaterial(tipoMaterialDto);
        }

        public TipoMaterialDTO BuscarTipoMaterialID(int Codigo)
        {
            return tipoMaterialDAO.BuscarTipoMaterialID(Codigo);
        }

        public string ActualizarTipoMaterial(TipoMaterialDTO tipoMaterialDto)
        {
            return tipoMaterialDAO.ActualizarTipoMaterial(tipoMaterialDto);
        }

        public string EliminarTipoMaterial(TipoMaterialDTO tipoMaterialDto)
        {
            return tipoMaterialDAO.EliminarTipoMaterial(tipoMaterialDto);
        }

    }
}
