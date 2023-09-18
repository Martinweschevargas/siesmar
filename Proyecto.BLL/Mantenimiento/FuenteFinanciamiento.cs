using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FuenteFinanciamiento
    {
        readonly FuenteFinanciamientoDAO fuenteFinanciamientoDAO = new();

        public List<FuenteFinanciamientoDTO> ObtenerFuenteFinanciamientos()
        {
            return fuenteFinanciamientoDAO.ObtenerFuenteFinanciamientos();
        }

        public string AgregarFuenteFinanciamiento(FuenteFinanciamientoDTO fuenteFinanciamientoDto)
        {
            return fuenteFinanciamientoDAO.AgregarFuenteFinanciamiento(fuenteFinanciamientoDto);
        }

        public FuenteFinanciamientoDTO BuscarFuenteFinanciamientoID(int Codigo)
        {
            return fuenteFinanciamientoDAO.BuscarFuenteFinanciamientoID(Codigo);
        }

        public string ActualizarFuenteFinanciamiento(FuenteFinanciamientoDTO fuenteFinanciamientoDTO)
        {
            return fuenteFinanciamientoDAO.ActualizarFuenteFinanciamiento(fuenteFinanciamientoDTO);
        }

        public string EliminarFuenteFinanciamiento(FuenteFinanciamientoDTO fuenteFinanciamientoDTO)
        {
            return fuenteFinanciamientoDAO.EliminarFuenteFinanciamiento(fuenteFinanciamientoDTO);
        }

    }
}
