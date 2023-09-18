using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoVehiculoTransporte
    {
        readonly TipoVehiculoTransporteDAO tipoVehiculoTransporteDAO = new();

        public List<TipoVehiculoTransporteDTO> ObtenerTipoVehiculoTransportes()
        {
            return tipoVehiculoTransporteDAO.ObtenerTipoVehiculoTransportes();
        }

        public string AgregarTipoVehiculoTransporte(TipoVehiculoTransporteDTO tipoVehiculoTransporteDto)
        {
            return tipoVehiculoTransporteDAO.AgregarTipoVehiculoTransporte(tipoVehiculoTransporteDto);
        }

        public TipoVehiculoTransporteDTO BuscarTipoVehiculoTransporteID(int Codigo)
        {
            return tipoVehiculoTransporteDAO.BuscarTipoVehiculoTransporteID(Codigo);
        }

        public string ActualizarTipoVehiculoTransporte(TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO)
        {
            return tipoVehiculoTransporteDAO.ActualizarTipoVehiculoTransporte(tipoVehiculoTransporteDTO);
        }

        public string EliminarTipoVehiculoTransporte(TipoVehiculoTransporteDTO tipoVehiculoTransporteDTO)
        {
            return tipoVehiculoTransporteDAO.EliminarTipoVehiculoTransporte(tipoVehiculoTransporteDTO);
        }

    }
}
