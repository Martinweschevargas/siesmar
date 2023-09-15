using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Frecuencia
    {
        readonly FrecuenciaDAO frecuenciaDAO = new();

        public List<FrecuenciaDTO> ObtenerFrecuencias()
        {
            return frecuenciaDAO.ObtenerFrecuencias();
        }

        public string AgregarFrecuencia(FrecuenciaDTO frecuenciaDto)
        {
            return frecuenciaDAO.AgregarFrecuencia(frecuenciaDto);
        }

        public FrecuenciaDTO BuscarFrecuenciaID(int Codigo)
        {
            return frecuenciaDAO.BuscarFrecuenciaID(Codigo);
        }

        public string ActualizarFrecuencia(FrecuenciaDTO frecuenciaDto)
        {
            return frecuenciaDAO.ActualizarFrecuencia(frecuenciaDto);
        }

        public string EliminarFrecuencia(FrecuenciaDTO frecuenciaDto)
        {
            return frecuenciaDAO.EliminarFrecuencia(frecuenciaDto);
        }

    }
}
