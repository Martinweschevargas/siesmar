using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MaterialArmamento
    {
        readonly MaterialArmamentoDAO materialArmamentoDAO = new();

        public List<MaterialArmamentoDTO> ObtenerMaterialArmamentos()
        {
            return materialArmamentoDAO.ObtenerMaterialArmamentos();
        }

        public string AgregarMaterialArmamento(MaterialArmamentoDTO materialArmamentoDto)
        {
            return materialArmamentoDAO.AgregarMaterialArmamento(materialArmamentoDto);
        }

        public MaterialArmamentoDTO BuscarMaterialArmamentoID(int Codigo)
        {
            return materialArmamentoDAO.BuscarMaterialArmamentoID(Codigo);
        }

        public string ActualizarMaterialArmamento(MaterialArmamentoDTO materialArmamentoDto)
        {
            return materialArmamentoDAO.ActualizarMaterialArmamento(materialArmamentoDto);
        }

        public string EliminarMaterialArmamento(MaterialArmamentoDTO materialArmamentoDto)
        {
            return materialArmamentoDAO.EliminarMaterialArmamento(materialArmamentoDto);
        }

    }
}
