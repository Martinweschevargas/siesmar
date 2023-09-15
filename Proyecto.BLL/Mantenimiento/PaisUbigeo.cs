using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PaisUbigeo
    {
        readonly PaisUbigeoDAO paisUbigeoDAO = new();

        public List<PaisUbigeoDTO> ObtenerPaisUbigeos()
        {
            return paisUbigeoDAO.ObtenerPaisUbigeos();
        }

        public string AgregarPaisUbigeo(PaisUbigeoDTO paisUbigeoDto)
        {
            return paisUbigeoDAO.AgregarPaisUbigeo(paisUbigeoDto);
        }

        public PaisUbigeoDTO BuscarPaisUbigeoID(int Codigo)
        {
            return paisUbigeoDAO.BuscarPaisUbigeoID(Codigo);
        }

        public string ActualizarPaisUbigeo(PaisUbigeoDTO paisUbigeoDTO)
        {
            return paisUbigeoDAO.ActualizarPaisUbigeo(paisUbigeoDTO);
        }

        public bool EliminarPaisUbigeo(PaisUbigeoDTO paisUbigeoDTO)
        {
            return paisUbigeoDAO.EliminarPaisUbigeo(paisUbigeoDTO);
        }

    }
}