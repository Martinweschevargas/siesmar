using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ZonaNaval
    {
        readonly ZonaNavalDAO zonaNavalDAO = new();

        public List<ZonaNavalDTO> ObtenerZonaNavals()
        {
            return zonaNavalDAO.ObtenerZonaNavals();
        }

        public string AgregarZonaNaval(ZonaNavalDTO zonaNavalDto)
        {
            return zonaNavalDAO.AgregarZonaNaval(zonaNavalDto);
        }

        public ZonaNavalDTO BuscarZonaNavalID(int Codigo)
        {
            return zonaNavalDAO.BuscarZonaNavalID(Codigo);
        }

        public string ActualizarZonaNaval(ZonaNavalDTO zonaNavalDTO)
        {
            return zonaNavalDAO.ActualizarZonaNaval(zonaNavalDTO);
        }

        public bool EliminarZonaNaval(ZonaNavalDTO zonaNavalDTO)
        {
            return zonaNavalDAO.EliminarZonaNaval(zonaNavalDTO);
        }

    }
}
