using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoCombustibleComoperguard
    {
        readonly TipoCombustibleComoperguardDAO TipoCombustibleComoperguardDAO = new();

        public List<TipoCombustibleComoperguardDTO> ObtenerTipoCombustibleComoperguards()
        {
            return TipoCombustibleComoperguardDAO.ObtenerTipoCombustibleComoperguards();
        }

        public string AgregarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO tipoCombustibleComoperguardDto)
        {
            return TipoCombustibleComoperguardDAO.AgregarTipoCombustibleComoperguard(tipoCombustibleComoperguardDto);
        }

        public TipoCombustibleComoperguardDTO BuscarTipoCombustibleComoperguardID(int Codigo)
        {
            return TipoCombustibleComoperguardDAO.BuscarTipoCombustibleComoperguardID(Codigo);
        }

        public string ActualizarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO tipoCombustibleComoperguardDto)
        {
            return TipoCombustibleComoperguardDAO.ActualizarTipoCombustibleComoperguard(tipoCombustibleComoperguardDto);
        }

        public string EliminarTipoCombustibleComoperguard(TipoCombustibleComoperguardDTO tipoCombustibleComoperguardDto)
        {
            return TipoCombustibleComoperguardDAO.EliminarTipoCombustibleComoperguard(tipoCombustibleComoperguardDto);
        }

    }
}
