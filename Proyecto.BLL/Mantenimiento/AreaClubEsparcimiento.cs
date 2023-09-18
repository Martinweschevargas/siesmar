using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AreaClubEsparcimiento
    {
        readonly AreaClubEsparcimientoDAO areaClubEsparcimientoDAO = new();

        public List<AreaClubEsparcimientoDTO> ObtenerAreaClubEsparcimientos()
        {
            return areaClubEsparcimientoDAO.ObtenerAreaClubEsparcimientos();
        }

        public string AgregarAreaClubEsparcimiento(AreaClubEsparcimientoDTO areaClubEsparcimientoDto)
        {
            return areaClubEsparcimientoDAO.AgregarAreaClubEsparcimiento(areaClubEsparcimientoDto);
        }

        public AreaClubEsparcimientoDTO BuscarAreaClubEsparcimientoID(int Codigo)
        {
            return areaClubEsparcimientoDAO.BuscarAreaClubEsparcimientoID(Codigo);
        }

        public string ActualizarAreaClubEsparcimiento(AreaClubEsparcimientoDTO areaClubEsparcimientoDto)
        {
            return areaClubEsparcimientoDAO.ActualizarAreaClubEsparcimiento(areaClubEsparcimientoDto);
        }

        public string EliminarAreaClubEsparcimiento(AreaClubEsparcimientoDTO areaClubEsparcimientoDto)
        {
            return areaClubEsparcimientoDAO.EliminarAreaClubEsparcimiento(areaClubEsparcimientoDto);
        }

    }
}
