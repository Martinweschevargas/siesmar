using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CoeficientePonderadoARC
    {
        readonly CoeficientePonderadoARCDAO coeficientePonderadoARCDAO = new();

        public List<CoeficientePonderadoARCDTO> ObtenerCoeficientePonderadoARCs()
        {
            return coeficientePonderadoARCDAO.ObtenerCoeficientePonderadoARCs();
        }

        public string AgregarCoeficientePonderadoARC(CoeficientePonderadoARCDTO coeficientePonderadoARCDto)
        {
            return coeficientePonderadoARCDAO.AgregarCoeficientePonderadoARC(coeficientePonderadoARCDto);
        }

        public CoeficientePonderadoARCDTO BuscarCoeficientePonderadoARCID(int Codigo)
        {
            return coeficientePonderadoARCDAO.BuscarCoeficientePonderadoARCID(Codigo);
        }

        public string ActualizarCoeficientePonderadoARC(CoeficientePonderadoARCDTO coeficientePonderadoARCDto)
        {
            return coeficientePonderadoARCDAO.ActualizarCoeficientePonderadoARC(coeficientePonderadoARCDto);
        }

        public string EliminarCoeficientePonderadoARC(CoeficientePonderadoARCDTO coeficientePonderadoARCDto)
        {
            return coeficientePonderadoARCDAO.EliminarCoeficientePonderadoARC(coeficientePonderadoARCDto);
        }

    }
}
