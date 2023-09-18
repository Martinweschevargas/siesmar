using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoCarta
    {
        readonly TipoCartaDAO TipoCartaDAO = new();

        public List<TipoCartaDTO> ObtenerTipoCartas()
        {
            return TipoCartaDAO.ObtenerTipoCartas();
        }

        public string AgregarTipoCarta(TipoCartaDTO tipoCartaDto)
        {
            return TipoCartaDAO.AgregarTipoCarta(tipoCartaDto);
        }

        public TipoCartaDTO BuscarTipoCartaID(int Codigo)
        {
            return TipoCartaDAO.BuscarTipoCartaID(Codigo);
        }

        public string ActualizarTipoCarta(TipoCartaDTO tipoCartaDto)
        {
            return TipoCartaDAO.ActualizarTipoCarta(tipoCartaDto);
        }

        public string EliminarTipoCarta(TipoCartaDTO tipoCartaDto)
        {
            return TipoCartaDAO.EliminarTipoCarta(tipoCartaDto);
        }

    }
}
