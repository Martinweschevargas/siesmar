using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoMaterialRequeridoComescuama
    {
        readonly AlistamientoMaterialRequeridoComescuamaDAO alistamientoMaterialRequeridoComescuamaDAO = new();

        public List<AlistamientoMaterialRequeridoComescuamaDTO> ObtenerAlistamientoMaterialRequeridoComescuamas()
        {
            return alistamientoMaterialRequeridoComescuamaDAO.ObtenerAlistamientoMaterialRequeridoComescuamas();
        }

        public string AgregarAlistamientoMaterialRequeridoComescuama(AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDto)
        {
            return alistamientoMaterialRequeridoComescuamaDAO.AgregarAlistamientoMaterialRequeridoComescuama(alistamientoMaterialRequeridoComescuamaDto);
        }

        public AlistamientoMaterialRequeridoComescuamaDTO BuscarAlistamientoMaterialRequeridoComescuamaID(int Codigo)
        {
            return alistamientoMaterialRequeridoComescuamaDAO.BuscarAlistamientoMaterialRequeridoComescuamaID(Codigo);
        }

        public string ActualizarAlistamientoMaterialRequeridoComescuama(AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDto)
        {
            return alistamientoMaterialRequeridoComescuamaDAO.ActualizarAlistamientoMaterialRequeridoComescuama(alistamientoMaterialRequeridoComescuamaDto);
        }

        public string EliminarAlistamientoMaterialRequeridoComescuama(AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDto)
        {
            return alistamientoMaterialRequeridoComescuamaDAO.EliminarAlistamientoMaterialRequeridoComescuama(alistamientoMaterialRequeridoComescuamaDto);
        }

    }
}
