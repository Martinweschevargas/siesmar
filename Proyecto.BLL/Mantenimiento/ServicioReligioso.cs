using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ServicioReligioso
    {
        readonly ServicioReligiosoDAO servicioReligiosoDAO = new();

        public List<ServicioReligiosoDTO> ObtenerCapintanias()
        {
            return servicioReligiosoDAO.ObtenerServicioReligiosos();
        }

        public string AgregarServicioReligioso(ServicioReligiosoDTO servicioReligiosoDto)
        {
            return servicioReligiosoDAO.AgregarServicioReligioso(servicioReligiosoDto);
        }

        public ServicioReligiosoDTO BuscarServicioReligiosoID(int Codigo)
        {
            return servicioReligiosoDAO.BuscarServicioReligiosoID(Codigo);
        }

        public string ActualizarServicioReligioso(ServicioReligiosoDTO servicioReligiosoDTO)
        {
            return servicioReligiosoDAO.ActualizarServicioReligioso(servicioReligiosoDTO);
        }

        public bool EliminarServicioReligioso(ServicioReligiosoDTO servicioReligiosoDTO)
        {
            return servicioReligiosoDAO.EliminarServicioReligioso(servicioReligiosoDTO);
        }

    }
}
