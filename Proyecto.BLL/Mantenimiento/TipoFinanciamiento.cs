using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoFinanciamiento
    {
        readonly TipoFinanciamientoDAO tipoFinanciamientoDAO = new();

        public List<TipoFinanciamientoDTO> ObtenerTipoFinanciamientos()
        {
            return tipoFinanciamientoDAO.ObtenerTipoFinanciamientos();
        }

        public string AgregarTipoFinanciamiento(TipoFinanciamientoDTO tipoFinanciamientoDto)
        {
            return tipoFinanciamientoDAO.AgregarTipoFinanciamiento(tipoFinanciamientoDto);
        }

        public TipoFinanciamientoDTO BuscarTipoFinanciamientoID(int Codigo)
        {
            return tipoFinanciamientoDAO.BuscarTipoFinanciamientoID(Codigo);
        }

        public string ActualizarTipoFinanciamiento(TipoFinanciamientoDTO tipoFinanciamientoDTO)
        {
            return tipoFinanciamientoDAO.ActualizarTipoFinanciamiento(tipoFinanciamientoDTO);
        }

        public bool EliminarTipoFinanciamiento(TipoFinanciamientoDTO tipoFinanciamientoDTO)
        {
            return tipoFinanciamientoDAO.EliminarTipoFinanciamiento(tipoFinanciamientoDTO);
        }

    }
}
