using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoCiberataque
    {
        readonly TipoCiberataqueDAO tipoCiberataqueDAO = new();

        public List<TipoCiberataqueDTO> ObtenerTipoCiberataques()
        {
            return tipoCiberataqueDAO.ObtenerTipoCiberataques();
        }

        public string AgregarTipoCiberataque(TipoCiberataqueDTO tipoCiberataqueDto)
        {
            return tipoCiberataqueDAO.AgregarTipoCiberataque(tipoCiberataqueDto);
        }

        public TipoCiberataqueDTO BuscarTipoCiberataqueID(int Codigo)
        {
            return tipoCiberataqueDAO.BuscarTipoCiberataqueID(Codigo);
        }

        public string ActualizarTipoCiberataque(TipoCiberataqueDTO tipoCiberataqueDto)
        {
            return tipoCiberataqueDAO.ActualizarTipoCiberataque(tipoCiberataqueDto);
        }

        public string EliminarTipoCiberataque(TipoCiberataqueDTO tipoCiberataqueDto)
        {
            return tipoCiberataqueDAO.EliminarTipoCiberataque(tipoCiberataqueDto);
        }

    }
}
