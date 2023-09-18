using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CentroGasto
    {
        readonly CentroGastoDAO centroGastoDAO = new();

        public List<CentroGastoDTO> ObtenerCentroGastos()
        {
            return centroGastoDAO.ObtenerCentroGastos();
        }

        public string AgregarCentroGasto(CentroGastoDTO centroGastoDto)
        {
            return centroGastoDAO.AgregarCentroGasto(centroGastoDto);
        }

        public CentroGastoDTO BuscarCentroGastoID(int Codigo)
        {
            return centroGastoDAO.BuscarCentroGastoID(Codigo);
        }

        public string ActualizarCentroGasto(CentroGastoDTO centroGastoDto)
        {
            return centroGastoDAO.ActualizarCentroGasto(centroGastoDto);
        }

        public string EliminarCentroGasto(CentroGastoDTO centroGastoDto)
        {
            return centroGastoDAO.EliminarCentroGasto(centroGastoDto);
        }

    }
}
