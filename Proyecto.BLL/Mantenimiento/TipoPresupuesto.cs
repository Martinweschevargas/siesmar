using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPresupuesto
    {
        readonly TipoPresupuestoDAO tipoPresupuestoDAO = new();

        public List<TipoPresupuestoDTO> ObtenerTipoPresupuestos()
        {
            return tipoPresupuestoDAO.ObtenerTipoPresupuestos();
        }

        public string AgregarTipoPresupuesto(TipoPresupuestoDTO tipoPresupuestoDto)
        {
            return tipoPresupuestoDAO.AgregarTipoPresupuesto(tipoPresupuestoDto);
        }

        public TipoPresupuestoDTO BuscarTipoPresupuestoID(int Codigo)
        {
            return tipoPresupuestoDAO.BuscarTipoPresupuestoID(Codigo);
        }

        public string ActualizarTipoPresupuesto(TipoPresupuestoDTO tipoPresupuestoDTO)
        {
            return tipoPresupuestoDAO.ActualizarTipoPresupuesto(tipoPresupuestoDTO);
        }

        public bool EliminarTipoPresupuesto(TipoPresupuestoDTO tipoPresupuestoDTO)
        {
            return tipoPresupuestoDAO.EliminarTipoPresupuesto(tipoPresupuestoDTO);
        }

    }
}
