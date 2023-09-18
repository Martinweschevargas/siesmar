using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoBienSubcampo
    {
        readonly TipoBienSubcampoDAO tipoBienSubcampoDAO = new();

        public List<TipoBienSubcampoDTO> ObtenerTipoBienSubcampos()
        {
            return tipoBienSubcampoDAO.ObtenerTipoBienSubcampos();
        }

        public string AgregarTipoBienSubcampo(TipoBienSubcampoDTO tipoBienSubcampoDto)
        {
            return tipoBienSubcampoDAO.AgregarTipoBienSubcampo(tipoBienSubcampoDto);
        }

        public TipoBienSubcampoDTO BuscarTipoBienSubcampoID(int Codigo)
        {
            return tipoBienSubcampoDAO.BuscarTipoBienSubcampoID(Codigo);
        }

        public string ActualizarTipoBienSubcampo(TipoBienSubcampoDTO tipoBienSubcampoDTO)
        {
            return tipoBienSubcampoDAO.ActualizarTipoBienSubcampo(tipoBienSubcampoDTO);
        }

        public bool EliminarTipoBienSubcampo(TipoBienSubcampoDTO tipoBienSubcampoDTO)
        {
            return tipoBienSubcampoDAO.EliminarTipoBienSubcampo(tipoBienSubcampoDTO);
        }

    }
}
