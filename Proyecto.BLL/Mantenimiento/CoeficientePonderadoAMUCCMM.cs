using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CoeficientePonderadoAMUCCMM
    {
        readonly CoeficientePonderadoAMUCCMMDAO coeficientePonderadoAMUCCMMDAO = new();

        public List<CoeficientePonderadoAMUCCMMDTO> ObtenerCoeficientePonderadoAMUCCMMs()
        {
            return coeficientePonderadoAMUCCMMDAO.ObtenerCoeficientePonderadoAMUCCMMs();
        }

        public string AgregarCoeficientePonderadoAMUCCMM(CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDto)
        {
            return coeficientePonderadoAMUCCMMDAO.AgregarCoeficientePonderadoAMUCCMM(coeficientePonderadoAMUCCMMDto);
        }

        public CoeficientePonderadoAMUCCMMDTO BuscarCoeficientePonderadoAMUCCMMID(int Codigo)
        {
            return coeficientePonderadoAMUCCMMDAO.BuscarCoeficientePonderadoAMUCCMMID(Codigo);
        }

        public string ActualizarCoeficientePonderadoAMUCCMM(CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDto)
        {
            return coeficientePonderadoAMUCCMMDAO.ActualizarCoeficientePonderadoAMUCCMM(coeficientePonderadoAMUCCMMDto);
        }

        public string EliminarCoeficientePonderadoAMUCCMM(CoeficientePonderadoAMUCCMMDTO coeficientePonderadoAMUCCMMDto)
        {
            return coeficientePonderadoAMUCCMMDAO.EliminarCoeficientePonderadoAMUCCMM(coeficientePonderadoAMUCCMMDto);
        }

    }
}
