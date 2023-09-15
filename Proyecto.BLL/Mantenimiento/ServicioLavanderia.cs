using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ServicioLavanderia
    {
        readonly ServicioLavanderiaDAO servicioLavanderiaDAO = new();

        public List<ServicioLavanderiaDTO> ObtenerServicioLavanderias()
        {
            return servicioLavanderiaDAO.ObtenerServicioLavanderias();
        }

        public string AgregarServicioLavanderia(ServicioLavanderiaDTO servicioLavanderiaDto)
        {
            return servicioLavanderiaDAO.AgregarServicioLavanderia(servicioLavanderiaDto);
        }

        public ServicioLavanderiaDTO BuscarServicioLavanderiaID(int Codigo)
        {
            return servicioLavanderiaDAO.BuscarServicioLavanderiaID(Codigo);
        }

        public string ActualizarServicioLavanderia(ServicioLavanderiaDTO servicioLavanderiaDTO)
        {
            return servicioLavanderiaDAO.ActualizarServicioLavanderia(servicioLavanderiaDTO);
        }

        public bool EliminarServicioLavanderia(ServicioLavanderiaDTO servicioLavanderiaDTO)
        {
            return servicioLavanderiaDAO.EliminarServicioLavanderia(servicioLavanderiaDTO);
        }

    }
}
