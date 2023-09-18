using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoBien
    {
        readonly TipoBienDAO tipoBienDAO = new();

        public List<TipoBienDTO> ObtenerTipoBiens()
        {
            return tipoBienDAO.ObtenerTipoBiens();
        }

        public string AgregarTipoBien(TipoBienDTO tipoBienDto)
        {
            return tipoBienDAO.AgregarTipoBien(tipoBienDto);
        }

        public TipoBienDTO BuscarTipoBienID(int Codigo)
        {
            return tipoBienDAO.BuscarTipoBienID(Codigo);
        }

        public string ActualizarTipoBien(TipoBienDTO tipoBienDTO)
        {
            return tipoBienDAO.ActualizarTipoBien(tipoBienDTO);
        }

        public bool EliminarTipoBien(TipoBienDTO tipoBienDTO)
        {
            return tipoBienDAO.EliminarTipoBien(tipoBienDTO);
        }

    }
}
