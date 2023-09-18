using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MaterialDeportivo
    {
        readonly MaterialDeportivoDAO MaterialDeportivoDAO = new();

        public List<MaterialDeportivoDTO> ObtenerMaterialDeportivos()
        {
            return MaterialDeportivoDAO.ObtenerMaterialDeportivos();
        }

        public string AgregarMaterialDeportivo(MaterialDeportivoDTO materialDeportivoDto)
        {
            return MaterialDeportivoDAO.AgregarMaterialDeportivo(materialDeportivoDto);
        }

        public MaterialDeportivoDTO BuscarMaterialDeportivoID(int Codigo)
        {
            return MaterialDeportivoDAO.BuscarMaterialDeportivoID(Codigo);
        }

        public string ActualizarMaterialDeportivo(MaterialDeportivoDTO materialDeportivoDto)
        {
            return MaterialDeportivoDAO.ActualizarMaterialDeportivo(materialDeportivoDto);
        }

        public string EliminarMaterialDeportivo(MaterialDeportivoDTO materialDeportivoDto)
        {
            return MaterialDeportivoDAO.EliminarMaterialDeportivo(materialDeportivoDto);
        }

    }
}
