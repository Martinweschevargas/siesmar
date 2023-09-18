using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClubEsparcimiento
    {
        readonly ClubEsparcimientoDAO clubEsparcimientoDAO = new();

        public List<ClubEsparcimientoDTO> ObtenerClubEsparcimientos()
        {
            return clubEsparcimientoDAO.ObtenerClubEsparcimientos();
        }

        public string AgregarClubEsparcimiento(ClubEsparcimientoDTO clubEsparcimientoDto)
        {
            return clubEsparcimientoDAO.AgregarClubEsparcimiento(clubEsparcimientoDto);
        }

        public ClubEsparcimientoDTO BuscarClubEsparcimientoID(int Codigo)
        {
            return clubEsparcimientoDAO.BuscarClubEsparcimientoID(Codigo);
        }

        public string ActualizarClubEsparcimiento(ClubEsparcimientoDTO clubEsparcimientoDto)
        {
            return clubEsparcimientoDAO.ActualizarClubEsparcimiento(clubEsparcimientoDto);
        }

        public string EliminarClubEsparcimiento(ClubEsparcimientoDTO clubEsparcimientoDto)
        {
            return clubEsparcimientoDAO.EliminarClubEsparcimiento(clubEsparcimientoDto);
        }

    }
}
