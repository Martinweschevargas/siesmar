using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoVehiculoMovil
    {
        readonly TipoVehiculoMovilDAO TipoVehiculoMovilDAO = new();

        public List<TipoVehiculoMovilDTO> ObtenerCapintanias()
        {
            return TipoVehiculoMovilDAO.ObtenerTipoVehiculoMovils();
        }

        public string AgregarTipoVehiculoMovil(TipoVehiculoMovilDTO tipoVehiculoMovilDto)
        {
            return TipoVehiculoMovilDAO.AgregarTipoVehiculoMovil(tipoVehiculoMovilDto);
        }

        public TipoVehiculoMovilDTO BuscarTipoVehiculoMovilID(int Codigo)
        {
            return TipoVehiculoMovilDAO.BuscarTipoVehiculoMovilID(Codigo);
        }

        public string ActualizarTipoVehiculoMovil(TipoVehiculoMovilDTO tipoVehiculoMovilDto)
        {
            return TipoVehiculoMovilDAO.ActualizarTipoVehiculoMovil(tipoVehiculoMovilDto);
        }

        public string EliminarTipoVehiculoMovil(TipoVehiculoMovilDTO tipoVehiculoMovilDto)
        {
            return TipoVehiculoMovilDAO.EliminarTipoVehiculoMovil(tipoVehiculoMovilDto);
        }

    }
}
