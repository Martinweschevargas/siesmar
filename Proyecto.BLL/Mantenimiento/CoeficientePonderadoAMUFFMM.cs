using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CoeficientePonderadoAMUFFMM
    {
        readonly CoeficientePonderadoAMUFFMMDAO coeficientePonderadoAMUFFMMDAO = new();

        public List<CoeficientePonderadoAMUFFMMDTO> ObtenerCoeficientePonderadoAMUFFMMs()
        {
            return coeficientePonderadoAMUFFMMDAO.ObtenerCoeficientePonderadoAMUFFMMs();
        }

        public string AgregarCoeficientePonderadoAMUFFMM(CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDto)
        {
            return coeficientePonderadoAMUFFMMDAO.AgregarCoeficientePonderadoAMUFFMM(coeficientePonderadoAMUFFMMDto);
        }

        public CoeficientePonderadoAMUFFMMDTO BuscarCoeficientePonderadoAMUFFMMID(int Codigo)
        {
            return coeficientePonderadoAMUFFMMDAO.BuscarCoeficientePonderadoAMUFFMMID(Codigo);
        }

        public string ActualizarCoeficientePonderadoAMUFFMM(CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDto)
        {
            return coeficientePonderadoAMUFFMMDAO.ActualizarCoeficientePonderadoAMUFFMM(coeficientePonderadoAMUFFMMDto);
        }

        public string EliminarCoeficientePonderadoAMUFFMM(CoeficientePonderadoAMUFFMMDTO coeficientePonderadoAMUFFMMDto)
        {
            return coeficientePonderadoAMUFFMMDAO.EliminarCoeficientePonderadoAMUFFMM(coeficientePonderadoAMUFFMMDto);
        }

    }
}
