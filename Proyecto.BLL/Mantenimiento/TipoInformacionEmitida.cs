using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoInformacionEmitida
    {
        readonly TipoInformacionEmitidaDAO tipoInformacionEmitidaDAO = new();

        public List<TipoInformacionEmitidaDTO> ObtenerTipoInformacionEmitidas()
        {
            return tipoInformacionEmitidaDAO.ObtenerTipoInformacionEmitidas();
        }

        public string AgregarTipoInformacionEmitida(TipoInformacionEmitidaDTO tipoInformacionEmitidaDto)
        {
            return tipoInformacionEmitidaDAO.AgregarTipoInformacionEmitida(tipoInformacionEmitidaDto);
        }

        public TipoInformacionEmitidaDTO BuscarTipoInformacionEmitidaID(int Codigo)
        {
            return tipoInformacionEmitidaDAO.BuscarTipoInformacionEmitidaID(Codigo);
        }

        public string ActualizarTipoInformacionEmitida(TipoInformacionEmitidaDTO tipoInformacionEmitidaDto)
        {
            return tipoInformacionEmitidaDAO.ActualizarTipoInformacionEmitida(tipoInformacionEmitidaDto);
        }

        public string EliminarTipoInformacionEmitida(TipoInformacionEmitidaDTO tipoInformacionEmitidaDto)
        {
            return tipoInformacionEmitidaDAO.EliminarTipoInformacionEmitida(tipoInformacionEmitidaDto);
        }

    }
}
