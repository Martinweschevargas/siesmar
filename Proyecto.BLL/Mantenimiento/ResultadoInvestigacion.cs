using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ResultadoInvestigacion
    {
        readonly ResultadoInvestigacionDAO resultadoInvestigacionDAO = new();

        public List<ResultadoInvestigacionDTO> ObtenerResultadoInvestigacions()
        {
            return resultadoInvestigacionDAO.ObtenerResultadoInvestigacions();
        }

        public string AgregarResultadoInvestigacion(ResultadoInvestigacionDTO resultadoInvestigacionDto)
        {
            return resultadoInvestigacionDAO.AgregarResultadoInvestigacion(resultadoInvestigacionDto);
        }

        public ResultadoInvestigacionDTO BuscarResultadoInvestigacionID(int Codigo)
        {
            return resultadoInvestigacionDAO.BuscarResultadoInvestigacionID(Codigo);
        }

        public string ActualizarResultadoInvestigacion(ResultadoInvestigacionDTO resultadoInvestigacionDTO)
        {
            return resultadoInvestigacionDAO.ActualizarResultadoInvestigacion(resultadoInvestigacionDTO);
        }

        public string EliminarResultadoInvestigacion(ResultadoInvestigacionDTO resultadoInvestigacionDTO)
        {
            return resultadoInvestigacionDAO.EliminarResultadoInvestigacion(resultadoInvestigacionDTO);
        }

    }
}
