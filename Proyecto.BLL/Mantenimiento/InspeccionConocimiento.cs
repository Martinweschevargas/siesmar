using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InspeccionConocimiento
    {
        readonly InspeccionConocimientoDAO inspeccionConocimientoDAO = new();

        public List<InspeccionConocimientoDTO> ObtenerInspeccionConocimientos()
        {
            return inspeccionConocimientoDAO.ObtenerInspeccionConocimientos();
        }

        public string AgregarInspeccionConocimiento(InspeccionConocimientoDTO inspeccionConocimientoDto)
        {
            return inspeccionConocimientoDAO.AgregarInspeccionConocimiento(inspeccionConocimientoDto);
        }

        public InspeccionConocimientoDTO BuscarInspeccionConocimientoID(int Codigo)
        {
            return inspeccionConocimientoDAO.BuscarInspeccionConocimientoID(Codigo);
        }

        public string ActualizarInspeccionConocimiento(InspeccionConocimientoDTO inspeccionConocimientoDto)
        {
            return inspeccionConocimientoDAO.ActualizarInspeccionConocimiento(inspeccionConocimientoDto);
        }

        public string EliminarInspeccionConocimiento(InspeccionConocimientoDTO inspeccionConocimientoDto)
        {
            return inspeccionConocimientoDAO.EliminarInspeccionConocimiento(inspeccionConocimientoDto);
        }

    }
}
