using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MaterialRecreativo
    {
        readonly MaterialRecreativoDAO MaterialRecreativoDAO = new();

        public List<MaterialRecreativoDTO> ObtenerMaterialRecreativos()
        {
            return MaterialRecreativoDAO.ObtenerMaterialRecreativos();
        }

        public string AgregarMaterialRecreativo(MaterialRecreativoDTO materialRecreativoDto)
        {
            return MaterialRecreativoDAO.AgregarMaterialRecreativo(materialRecreativoDto);
        }

        public MaterialRecreativoDTO BuscarMaterialRecreativoID(int Codigo)
        {
            return MaterialRecreativoDAO.BuscarMaterialRecreativoID(Codigo);
        }

        public string ActualizarMaterialRecreativo(MaterialRecreativoDTO materialRecreativoDto)
        {
            return MaterialRecreativoDAO.ActualizarMaterialRecreativo(materialRecreativoDto);
        }

        public string EliminarMaterialRecreativo(MaterialRecreativoDTO materialRecreativoDto)
        {
            return MaterialRecreativoDAO.EliminarMaterialRecreativo(materialRecreativoDto);
        }

    }
}
