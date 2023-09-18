using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionCurso
    {
        readonly ClasificacionCursoDAO clasificacionCursoDAO = new();

        public List<ClasificacionCursoDTO> ObtenerClasificacionCursos()
        {
            return clasificacionCursoDAO.ObtenerClasificacionCursos();
        }

        public string AgregarClasificacionCurso(ClasificacionCursoDTO clasificacionCursoDto)
        {
            return clasificacionCursoDAO.AgregarClasificacionCurso(clasificacionCursoDto);
        }

        public ClasificacionCursoDTO BuscarClasificacionCursoID(int Codigo)
        {
            return clasificacionCursoDAO.BuscarClasificacionCursoID(Codigo);
        }

        public string ActualizarClasificacionCurso(ClasificacionCursoDTO clasificacionCursoDTO)
        {
            return clasificacionCursoDAO.ActualizarClasificacionCurso(clasificacionCursoDTO);
        }

        public string EliminarClasificacionCurso(ClasificacionCursoDTO clasificacionCursoDTO)
        {
            return clasificacionCursoDAO.EliminarClasificacionCurso(clasificacionCursoDTO);
        }

    }
}
