using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FrecuenciaImpresion
    {
        readonly FrecuenciaImpresionDAO frecuenciaImpresionDAO = new();

        public List<FrecuenciaImpresionDTO> ObtenerFrecuenciaImpresions()
        {
            return frecuenciaImpresionDAO.ObtenerFrecuenciaImpresions();
        }

        public string AgregarFrecuenciaImpresion(FrecuenciaImpresionDTO frecuenciaImpresionDto)
        {
            return frecuenciaImpresionDAO.AgregarFrecuenciaImpresion(frecuenciaImpresionDto);
        }

        public FrecuenciaImpresionDTO BuscarFrecuenciaImpresionID(int Codigo)
        {
            return frecuenciaImpresionDAO.BuscarFrecuenciaImpresionID(Codigo);
        }

        public string ActualizarFrecuenciaImpresion(FrecuenciaImpresionDTO frecuenciaImpresionDto)
        {
            return frecuenciaImpresionDAO.ActualizarFrecuenciaImpresion(frecuenciaImpresionDto);
        }

        public string EliminarFrecuenciaImpresion(FrecuenciaImpresionDTO frecuenciaImpresionDto)
        {
            return frecuenciaImpresionDAO.EliminarFrecuenciaImpresion(frecuenciaImpresionDto);
        }

    }
}
