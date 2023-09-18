using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPersonalMilitar
    {
        readonly TipoPersonalMilitarDAO tipoPersonalMilitarDAO = new();

        public List<TipoPersonalMilitarDTO> ObtenerTipoPersonalMilitars()
        {
            return tipoPersonalMilitarDAO.ObtenerTipoPersonalMilitars();
        }

        public string AgregarTipoPersonalMilitar(TipoPersonalMilitarDTO tipoPersonalMilitarDto)
        {
            return tipoPersonalMilitarDAO.AgregarTipoPersonalMilitar(tipoPersonalMilitarDto);
        }

        public TipoPersonalMilitarDTO BuscarTipoPersonalMilitarID(int Codigo)
        {
            return tipoPersonalMilitarDAO.BuscarTipoPersonalMilitarID(Codigo);
        }

        public string ActualizarTipoPersonalMilitar(TipoPersonalMilitarDTO tipoPersonalMilitarDTO)
        {
            return tipoPersonalMilitarDAO.ActualizarTipoPersonalMilitar(tipoPersonalMilitarDTO);
        }

        public string EliminarTipoPersonalMilitar(TipoPersonalMilitarDTO tipoPersonalMilitarDTO)
        {
            return tipoPersonalMilitarDAO.EliminarTipoPersonalMilitar(tipoPersonalMilitarDTO);
        }

    }
}
