using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ResultadoApelacionReconsideracion
    {
        readonly ResultadoApelacionReconsideracionDAO resultadoApelacionReconsideracionDAO = new();

        public List<ResultadoApelacionReconsideracionDTO> ObtenerResultadoApelacionReconsideracions()
        {
            return resultadoApelacionReconsideracionDAO.ObtenerResultadoApelacionReconsideracions();
        }

        public string AgregarResultadoApelacionReconsideracion(ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDto)
        {
            return resultadoApelacionReconsideracionDAO.AgregarResultadoApelacionReconsideracion(resultadoApelacionReconsideracionDto);
        }

        public ResultadoApelacionReconsideracionDTO BuscarResultadoApelacionReconsideracionID(int Codigo)
        {
            return resultadoApelacionReconsideracionDAO.BuscarResultadoApelacionReconsideracionID(Codigo);
        }

        public string ActualizarResultadoApelacionReconsideracion(ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO)
        {
            return resultadoApelacionReconsideracionDAO.ActualizarResultadoApelacionReconsideracion(resultadoApelacionReconsideracionDTO);
        }

        public string EliminarResultadoApelacionReconsideracion(ResultadoApelacionReconsideracionDTO resultadoApelacionReconsideracionDTO)
        {
            return resultadoApelacionReconsideracionDAO.EliminarResultadoApelacionReconsideracion(resultadoApelacionReconsideracionDTO);
        }

    }
}
