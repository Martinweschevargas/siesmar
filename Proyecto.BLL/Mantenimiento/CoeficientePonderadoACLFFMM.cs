using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CoeficientePonderadoACLFFMM
    {
        readonly CoeficientePonderadoACLFFMMDAO coeficientePonderadoACLFFMMDAO = new();

        public List<CoeficientePonderadoACLFFMMDTO> ObtenerCoeficientePonderadoACLFFMMs()
        {
            return coeficientePonderadoACLFFMMDAO.ObtenerCoeficientePonderadoACLFFMMs();
        }

        public string AgregarCoeficientePonderadoACLFFMM(CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDto)
        {
            return coeficientePonderadoACLFFMMDAO.AgregarCoeficientePonderadoACLFFMM(coeficientePonderadoACLFFMMDto);
        }

        public CoeficientePonderadoACLFFMMDTO BuscarCoeficientePonderadoACLFFMMID(int Codigo)
        {
            return coeficientePonderadoACLFFMMDAO.BuscarCoeficientePonderadoACLFFMMID(Codigo);
        }

        public string ActualizarCoeficientePonderadoACLFFMM(CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDto)
        {
            return coeficientePonderadoACLFFMMDAO.ActualizarCoeficientePonderadoACLFFMM(coeficientePonderadoACLFFMMDto);
        }

        public string EliminarCoeficientePonderadoACLFFMM(CoeficientePonderadoACLFFMMDTO coeficientePonderadoACLFFMMDto)
        {
            return coeficientePonderadoACLFFMMDAO.EliminarCoeficientePonderadoACLFFMM(coeficientePonderadoACLFFMMDto);
        }

    }
}
