using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PuntoDistribucionCombustible
    {
        readonly PuntoDistribucionCombustibleDAO puntoDistribucionCombustibleDAO = new();

        public List<PuntoDistribucionCombustibleDTO> ObtenerPuntoDistribucionCombustibles()
        {
            return puntoDistribucionCombustibleDAO.ObtenerPuntoDistribucionCombustibles();
        }

        public string AgregarPuntoDistribucionCombustible(PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDto)
        {
            return puntoDistribucionCombustibleDAO.AgregarPuntoDistribucionCombustible(puntoDistribucionCombustibleDto);
        }

        public PuntoDistribucionCombustibleDTO BuscarPuntoDistribucionCombustibleID(int Codigo)
        {
            return puntoDistribucionCombustibleDAO.BuscarPuntoDistribucionCombustibleID(Codigo);
        }

        public string ActualizarPuntoDistribucionCombustible(PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO)
        {
            return puntoDistribucionCombustibleDAO.ActualizarPuntoDistribucionCombustible(puntoDistribucionCombustibleDTO);
        }

        public bool EliminarPuntoDistribucionCombustible(PuntoDistribucionCombustibleDTO puntoDistribucionCombustibleDTO)
        {
            return puntoDistribucionCombustibleDAO.EliminarPuntoDistribucionCombustible(puntoDistribucionCombustibleDTO);
        }

    }
}
