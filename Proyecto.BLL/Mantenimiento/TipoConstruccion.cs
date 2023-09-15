using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoConstruccion
    {
        readonly TipoConstruccionDAO tipoConstruccionDAO = new();

        public List<TipoConstruccionDTO> ObtenerTipoConstruccions()
        {
            return tipoConstruccionDAO.ObtenerTipoConstruccions();
        }

        public string AgregarTipoConstruccion(TipoConstruccionDTO tipoConstruccionDto)
        {
            return tipoConstruccionDAO.AgregarTipoConstruccion(tipoConstruccionDto);
        }

        public TipoConstruccionDTO BuscarTipoConstruccionID(int Codigo)
        {
            return tipoConstruccionDAO.BuscarTipoConstruccionID(Codigo);
        }

        public string ActualizarTipoConstruccion(TipoConstruccionDTO tipoConstruccionDto)
        {
            return tipoConstruccionDAO.ActualizarTipoConstruccion(tipoConstruccionDto);
        }

        public string EliminarTipoConstruccion(TipoConstruccionDTO tipoConstruccionDto)
        {
            return tipoConstruccionDAO.EliminarTipoConstruccion(tipoConstruccionDto);
        }

    }
}
