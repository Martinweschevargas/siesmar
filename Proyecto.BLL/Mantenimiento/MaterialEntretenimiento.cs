using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MaterialEntretenimiento
    {
        readonly MaterialEntretenimientoDAO MaterialEntretenimientoDAO = new();

        public List<MaterialEntretenimientoDTO> ObtenerMaterialEntretenimientos()
        {
            return MaterialEntretenimientoDAO.ObtenerMaterialEntretenimientos();
        }

        public string AgregarMaterialEntretenimiento(MaterialEntretenimientoDTO materialEntretenimientoDto)
        {
            return MaterialEntretenimientoDAO.AgregarMaterialEntretenimiento(materialEntretenimientoDto);
        }

        public MaterialEntretenimientoDTO BuscarMaterialEntretenimientoID(int Codigo)
        {
            return MaterialEntretenimientoDAO.BuscarMaterialEntretenimientoID(Codigo);
        }

        public string ActualizarMaterialEntretenimiento(MaterialEntretenimientoDTO materialEntretenimientoDto)
        {
            return MaterialEntretenimientoDAO.ActualizarMaterialEntretenimiento(materialEntretenimientoDto);
        }

        public string EliminarMaterialEntretenimiento(MaterialEntretenimientoDTO materialEntretenimientoDto)
        {
            return MaterialEntretenimientoDAO.EliminarMaterialEntretenimiento(materialEntretenimientoDto);
        }

    }
}
