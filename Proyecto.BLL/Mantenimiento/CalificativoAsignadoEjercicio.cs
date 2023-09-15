using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CalificativoAsignadoEjercicio
    {
        readonly CalificativoAsignadoEjercicioDAO calificativoAsignadoEjercicioDAO = new();

        public List<CalificativoAsignadoEjercicioDTO> ObtenerCalificativoAsignadoEjercicios()
        {
            return calificativoAsignadoEjercicioDAO.ObtenerCalificativoAsignadoEjercicios();
        }

        public string AgregarCalificativoAsignadoEjercicio(CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDto)
        {
            return calificativoAsignadoEjercicioDAO.AgregarCalificativoAsignadoEjercicio(calificativoAsignadoEjercicioDto);
        }

        public CalificativoAsignadoEjercicioDTO BuscarCalificativoAsignadoEjercicioID(int Codigo)
        {
            return calificativoAsignadoEjercicioDAO.BuscarCalificativoAsignadoEjercicioID(Codigo);
        }

        public string ActualizarCalificativoAsignadoEjercicio(CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDto)
        {
            return calificativoAsignadoEjercicioDAO.ActualizarCalificativoAsignadoEjercicio(calificativoAsignadoEjercicioDto);
        }

        public string EliminarCalificativoAsignadoEjercicio(CalificativoAsignadoEjercicioDTO calificativoAsignadoEjercicioDto)
        {
            return calificativoAsignadoEjercicioDAO.EliminarCalificativoAsignadoEjercicio(calificativoAsignadoEjercicioDto);
        }

    }
}
