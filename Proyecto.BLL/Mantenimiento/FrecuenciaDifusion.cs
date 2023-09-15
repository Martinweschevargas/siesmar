using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FrecuenciaDifusion
    {
        readonly FrecuenciaDifusionDAO frecuenciaDifusionDAO = new();

        public List<FrecuenciaDifusionDTO> ObtenerFrecuenciaDifusions()
        {
            return frecuenciaDifusionDAO.ObtenerFrecuenciaDifusions();
        }

        public string AgregarFrecuenciaDifusion(FrecuenciaDifusionDTO frecuenciaDifusionDto)
        {
            return frecuenciaDifusionDAO.AgregarFrecuenciaDifusion(frecuenciaDifusionDto);
        }

        public FrecuenciaDifusionDTO BuscarFrecuenciaDifusionID(int Codigo)
        {
            return frecuenciaDifusionDAO.BuscarFrecuenciaDifusionID(Codigo);
        }

        public string ActualizarFrecuenciaDifusion(FrecuenciaDifusionDTO frecuenciaDifusionDto)
        {
            return frecuenciaDifusionDAO.ActualizarFrecuenciaDifusion(frecuenciaDifusionDto);
        }

        public string EliminarFrecuenciaDifusion(FrecuenciaDifusionDTO frecuenciaDifusionDto)
        {
            return frecuenciaDifusionDAO.EliminarFrecuenciaDifusion(frecuenciaDifusionDto);
        }

    }
}
