using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPrestamoConvenio
    {
        readonly TipoPrestamoConvenioDAO TipoPrestamoConvenioDAO = new();

        public List<TipoPrestamoConvenioDTO> ObtenerTipoPrestamoConvenios()
        {
            return TipoPrestamoConvenioDAO.ObtenerTipoPrestamoConvenios();
        }

        public string AgregarTipoPrestamoConvenio(TipoPrestamoConvenioDTO tipoPrestamoConvenioDto)
        {
            return TipoPrestamoConvenioDAO.AgregarTipoPrestamoConvenio(tipoPrestamoConvenioDto);
        }

        public TipoPrestamoConvenioDTO BuscarTipoPrestamoConvenioID(int Codigo)
        {
            return TipoPrestamoConvenioDAO.BuscarTipoPrestamoConvenioID(Codigo);
        }

        public string ActualizarTipoPrestamoConvenio(TipoPrestamoConvenioDTO tipoPrestamoConvenioDto)
        {
            return TipoPrestamoConvenioDAO.ActualizarTipoPrestamoConvenio(tipoPrestamoConvenioDto);
        }

        public string EliminarTipoPrestamoConvenio(TipoPrestamoConvenioDTO tipoPrestamoConvenioDto)
        {
            return TipoPrestamoConvenioDAO.EliminarTipoPrestamoConvenio(tipoPrestamoConvenioDto);
        }

    }
}
