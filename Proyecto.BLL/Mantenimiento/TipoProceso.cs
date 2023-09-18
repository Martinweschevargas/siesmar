using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoProceso
    {
        readonly TipoProcesoDAO tipoProcesoDAO = new();

        public List<TipoProcesoDTO> ObtenerTipoProcesos()
        {
            return tipoProcesoDAO.ObtenerTipoProcesos();
        }

        public string AgregarTipoProceso(TipoProcesoDTO tipoProcesoDto)
        {
            return tipoProcesoDAO.AgregarTipoProceso(tipoProcesoDto);
        }

        public TipoProcesoDTO BuscarTipoProcesoID(int Codigo)
        {
            return tipoProcesoDAO.BuscarTipoProcesoID(Codigo);
        }

        public string ActualizarTipoProceso(TipoProcesoDTO tipoProcesoDTO)
        {
            return tipoProcesoDAO.ActualizarTipoProceso(tipoProcesoDTO);
        }

        public bool EliminarTipoProceso(TipoProcesoDTO tipoProcesoDTO)
        {
            return tipoProcesoDAO.EliminarTipoProceso(tipoProcesoDTO);
        }

    }
}
