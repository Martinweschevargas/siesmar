using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProvinciaUbigeo
    {
        readonly ProvinciaUbigeoDAO provinciaUbigeoDAO = new();

        public List<ProvinciaUbigeoDTO> ObtenerProvinciaUbigeos()
        {
            return provinciaUbigeoDAO.ObtenerProvinciaUbigeos();
        }

        public string AgregarProvinciaUbigeo(ProvinciaUbigeoDTO provinciaUbigeoDto)
        {
            return provinciaUbigeoDAO.AgregarProvinciaUbigeo(provinciaUbigeoDto);
        }

        public ProvinciaUbigeoDTO BuscarProvinciaUbigeoID(int Codigo)
        {
            return provinciaUbigeoDAO.BuscarProvinciaUbigeoID(Codigo);
        }

        public string ActualizarProvinciaUbigeo(ProvinciaUbigeoDTO provinciaUbigeoDTO)
        {
            return provinciaUbigeoDAO.ActualizarProvinciaUbigeo(provinciaUbigeoDTO);
        }

        public bool EliminarProvinciaUbigeo(ProvinciaUbigeoDTO provinciaUbigeoDTO)
        {
            return provinciaUbigeoDAO.EliminarProvinciaUbigeo(provinciaUbigeoDTO);
        }

    }
}