using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CoeficientePonderadoACLCCMM
    {
        readonly CoeficientePonderadoACLCCMMDAO coeficientePonderadoACLCCMMDAO = new();

        public List<CoeficientePonderadoACLCCMMDTO> ObtenerCoeficientePonderadoACLCCMMs()
        {
            return coeficientePonderadoACLCCMMDAO.ObtenerCoeficientePonderadoACLCCMMs();
        }

        public string AgregarCoeficientePonderadoACLCCMM(CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDto)
        {
            return coeficientePonderadoACLCCMMDAO.AgregarCoeficientePonderadoACLCCMM(coeficientePonderadoACLCCMMDto);
        }

        public CoeficientePonderadoACLCCMMDTO BuscarCoeficientePonderadoACLCCMMID(int Codigo)
        {
            return coeficientePonderadoACLCCMMDAO.BuscarCoeficientePonderadoACLCCMMID(Codigo);
        }

        public string ActualizarCoeficientePonderadoACLCCMM(CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDto)
        {
            return coeficientePonderadoACLCCMMDAO.ActualizarCoeficientePonderadoACLCCMM(coeficientePonderadoACLCCMMDto);
        }

        public string EliminarCoeficientePonderadoACLCCMM(CoeficientePonderadoACLCCMMDTO coeficientePonderadoACLCCMMDto)
        {
            return coeficientePonderadoACLCCMMDAO.EliminarCoeficientePonderadoACLCCMM(coeficientePonderadoACLCCMMDto);
        }

    }
}
