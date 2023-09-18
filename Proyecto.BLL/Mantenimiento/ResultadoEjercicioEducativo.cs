using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ResultadoEjercicioEducativo
    {
        readonly ResultadoEjercicioEducativoDAO ResultadoEjercicioEducativoDAO = new();

        public List<ResultadoEjercicioEducativoDTO> ObtenerResultadoEjercicioEducativos()
        {
            return ResultadoEjercicioEducativoDAO.ObtenerResultadoEjercicioEducativos();
        }

        public string AgregarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO resultadoEjercicioEducativoDto)
        {
            return ResultadoEjercicioEducativoDAO.AgregarResultadoEjercicioEducativo(resultadoEjercicioEducativoDto);
        }

        public ResultadoEjercicioEducativoDTO BuscarResultadoEjercicioEducativoID(int Codigo)
        {
            return ResultadoEjercicioEducativoDAO.BuscarResultadoEjercicioEducativoID(Codigo);
        }

        public string ActualizarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO resultadoEjercicioEducativoDto)
        {
            return ResultadoEjercicioEducativoDAO.ActualizarResultadoEjercicioEducativo(resultadoEjercicioEducativoDto);
        }

        public string EliminarResultadoEjercicioEducativo(ResultadoEjercicioEducativoDTO resultadoEjercicioEducativoDto)
        {
            return ResultadoEjercicioEducativoDAO.EliminarResultadoEjercicioEducativo(resultadoEjercicioEducativoDto);
        }

    }
}
