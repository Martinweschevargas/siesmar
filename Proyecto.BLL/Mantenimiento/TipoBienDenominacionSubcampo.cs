using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoBienDenominacionSubcampo
    {
        readonly TipoBienDenominacionSubcampoDAO tipoBienDenominacionSubcampoDAO = new();

        public List<TipoBienDenominacionSubcampoDTO> ObtenerTipoBienDenominacionSubcampos()
        {
            return tipoBienDenominacionSubcampoDAO.ObtenerTipoBienDenominacionSubcampos();
        }

        public string AgregarTipoBienDenominacionSubcampo(TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDto)
        {
            return tipoBienDenominacionSubcampoDAO.AgregarTipoBienDenominacionSubcampo(tipoBienDenominacionSubcampoDto);
        }

        public TipoBienDenominacionSubcampoDTO BuscarTipoBienDenominacionSubcampoID(int Codigo)
        {
            return tipoBienDenominacionSubcampoDAO.BuscarTipoBienDenominacionSubcampoID(Codigo);
        }

        public string ActualizarTipoBienDenominacionSubcampo(TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDto)
        {
            return tipoBienDenominacionSubcampoDAO.ActualizarTipoBienDenominacionSubcampo(tipoBienDenominacionSubcampoDto);
        }

        public string EliminarTipoBienDenominacionSubcampo(TipoBienDenominacionSubcampoDTO tipoBienDenominacionSubcampoDto)
        {
            return tipoBienDenominacionSubcampoDAO.EliminarTipoBienDenominacionSubcampo(tipoBienDenominacionSubcampoDto);
        }

    }
}
