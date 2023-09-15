using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoComision
    {
        readonly TipoComisionDAO tipoComisionDAO = new();

        public List<TipoComisionDTO> ObtenerTipoComisions()
        {
            return tipoComisionDAO.ObtenerTipoComisions();
        }

        public string AgregarTipoComision(TipoComisionDTO tipoComisionDto)
        {
            return tipoComisionDAO.AgregarTipoComision(tipoComisionDto);
        }

        public TipoComisionDTO BuscarTipoComisionID(int Codigo)
        {
            return tipoComisionDAO.BuscarTipoComisionID(Codigo);
        }

        public string ActualizarTipoComision(TipoComisionDTO tipoComisionDto)
        {
            return tipoComisionDAO.ActualizarTipoComision(tipoComisionDto);
        }

        public string EliminarTipoComision(TipoComisionDTO tipoComisionDto)
        {
            return tipoComisionDAO.EliminarTipoComision(tipoComisionDto);
        }

    }
}
