using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AreaSalonClubEsparcimiento
    {
        readonly AreaSalonClubEsparcimientoDAO AreaSalonClubEsparcimientoDAO = new();

        public List<AreaSalonClubEsparcimientoDTO> ObtenerAreaSalonClubEsparcimientos()
        {
            return AreaSalonClubEsparcimientoDAO.ObtenerAreaSalonClubEsparcimientos();
        }

        public string AgregarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO areaSalonClubEsparcimientoDto)
        {
            return AreaSalonClubEsparcimientoDAO.AgregarAreaSalonClubEsparcimiento(areaSalonClubEsparcimientoDto);
        }

        public AreaSalonClubEsparcimientoDTO BuscarAreaSalonClubEsparcimientoID(int Codigo)
        {
            return AreaSalonClubEsparcimientoDAO.BuscarAreaSalonClubEsparcimientoID(Codigo);
        }

        public string ActualizarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO areaSalonClubEsparcimientoDto)
        {
            return AreaSalonClubEsparcimientoDAO.ActualizarAreaSalonClubEsparcimiento(areaSalonClubEsparcimientoDto);
        }

        public string EliminarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO areaSalonClubEsparcimientoDto)
        {
            return AreaSalonClubEsparcimientoDAO.EliminarAreaSalonClubEsparcimiento(areaSalonClubEsparcimientoDto);
        }

    }
}
