using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoBaja
    {
        readonly TipoBajaDAO tipoBajaDAO = new();

        public List<TipoBajaDTO> ObtenerTipoBajas()
        {
            return tipoBajaDAO.ObtenerTipoBajas();
        }

        public string AgregarTipoBaja(TipoBajaDTO tipoBajaDto)
        {
            return tipoBajaDAO.AgregarTipoBaja(tipoBajaDto);
        }

        public TipoBajaDTO BuscarTipoBajaID(int Codigo)
        {
            return tipoBajaDAO.BuscarTipoBajaID(Codigo);
        }

        public string ActualizarTipoBaja(TipoBajaDTO tipoBajaDto)
        {
            return tipoBajaDAO.ActualizarTipoBaja(tipoBajaDto);
        }

        public string EliminarTipoBaja(TipoBajaDTO tipoBajaDto)
        {
            return tipoBajaDAO.EliminarTipoBaja(tipoBajaDto);
        }

    }
}
