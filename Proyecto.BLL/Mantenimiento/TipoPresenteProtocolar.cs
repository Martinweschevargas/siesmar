using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPresenteProtocolar
    {
        readonly TipoPresenteProtocolarDAO capitaniaDAO = new();

        public List<TipoPresenteProtocolarDTO> ObtenerTipoPresenteProtocolars()
        {
            return capitaniaDAO.ObtenerTipoPresenteProtocolars();
        }

        public string AgregarTipoPresenteProtocolar(TipoPresenteProtocolarDTO capitaniaDto)
        {
            return capitaniaDAO.AgregarTipoPresenteProtocolar(capitaniaDto);
        }

        public TipoPresenteProtocolarDTO BuscarTipoPresenteProtocolarID(int Codigo)
        {
            return capitaniaDAO.BuscarTipoPresenteProtocolarID(Codigo);
        }

        public string ActualizarTipoPresenteProtocolar(TipoPresenteProtocolarDTO capitaniaDto)
        {
            return capitaniaDAO.ActualizarTipoPresenteProtocolar(capitaniaDto);
        }

        public string EliminarTipoPresenteProtocolar(TipoPresenteProtocolarDTO capitaniaDto)
        {
            return capitaniaDAO.EliminarTipoPresenteProtocolar(capitaniaDto);
        }

    }
}
