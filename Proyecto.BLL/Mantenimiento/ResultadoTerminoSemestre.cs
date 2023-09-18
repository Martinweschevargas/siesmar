using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ResultadoTerminoSemestre
    {
        readonly ResultadoTerminoSemestreDAO resultadoTerminoSemestreDAO = new();

        public List<ResultadoTerminoSemestreDTO> ObtenerResultadoTerminoSemestres()
        {
            return resultadoTerminoSemestreDAO.ObtenerResultadoTerminoSemestres();
        }

        public string AgregarResultadoTerminoSemestre(ResultadoTerminoSemestreDTO resultadoTerminoSemestreDto)
        {
            return resultadoTerminoSemestreDAO.AgregarResultadoTerminoSemestre(resultadoTerminoSemestreDto);
        }

        public ResultadoTerminoSemestreDTO BuscarResultadoTerminoSemestreID(int Codigo)
        {
            return resultadoTerminoSemestreDAO.BuscarResultadoTerminoSemestreID(Codigo);
        }

        public string ActualizarResultadoTerminoSemestre(ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO)
        {
            return resultadoTerminoSemestreDAO.ActualizarResultadoTerminoSemestre(resultadoTerminoSemestreDTO);
        }

        public string EliminarResultadoTerminoSemestre(ResultadoTerminoSemestreDTO resultadoTerminoSemestreDTO)
        {
            return resultadoTerminoSemestreDAO.EliminarResultadoTerminoSemestre(resultadoTerminoSemestreDTO);
        }

    }
}
