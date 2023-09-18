using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionEspecialidad
    {
        readonly ClasificacionEspecialidadDAO clasificacionEspecialidadDAO = new();

        public List<ClasificacionEspecialidadDTO> ObtenerClasificacionEspecialidads()
        {
            return clasificacionEspecialidadDAO.ObtenerClasificacionEspecialidads();
        }

        public string AgregarClasificacionEspecialidad(ClasificacionEspecialidadDTO clasificacionEspecialidadDto)
        {
            return clasificacionEspecialidadDAO.AgregarClasificacionEspecialidad(clasificacionEspecialidadDto);
        }

        public ClasificacionEspecialidadDTO BuscarClasificacionEspecialidadID(int Codigo)
        {
            return clasificacionEspecialidadDAO.BuscarClasificacionEspecialidadID(Codigo);
        }

        public string ActualizarClasificacionEspecialidad(ClasificacionEspecialidadDTO clasificacionEspecialidadDTO)
        {
            return clasificacionEspecialidadDAO.ActualizarClasificacionEspecialidad(clasificacionEspecialidadDTO);
        }

        public bool EliminarClasificacionEspecialidad(ClasificacionEspecialidadDTO clasificacionEspecialidadDTO)
        {
            return clasificacionEspecialidadDAO.EliminarClasificacionEspecialidad(clasificacionEspecialidadDTO);
        }

    }
}
