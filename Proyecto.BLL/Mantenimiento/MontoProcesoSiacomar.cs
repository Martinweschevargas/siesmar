using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MontoProcesoSiacomar
    {
        readonly MontoProcesoSiacomarDAO montoProcesoSiacomarDAO = new();

        public List<MontoProcesoSiacomarDTO> ObtenerMontoProcesoSiacomars()
        {
            return montoProcesoSiacomarDAO.ObtenerMontoProcesoSiacomars();
        }

        public string AgregarMontoProcesoSiacomar(MontoProcesoSiacomarDTO montoProcesoSiacomarDto)
        {
            return montoProcesoSiacomarDAO.AgregarMontoProcesoSiacomar(montoProcesoSiacomarDto);
        }

        public MontoProcesoSiacomarDTO BuscarMontoProcesoSiacomarID(int Codigo)
        {
            return montoProcesoSiacomarDAO.BuscarMontoProcesoSiacomarID(Codigo);
        }

        public string ActualizarMontoProcesoSiacomar(MontoProcesoSiacomarDTO montoProcesoSiacomarDTO)
        {
            return montoProcesoSiacomarDAO.ActualizarMontoProcesoSiacomar(montoProcesoSiacomarDTO);
        }

        public bool EliminarMontoProcesoSiacomar(int Codigo)
        {
            return montoProcesoSiacomarDAO.EliminarMontoProcesoSiacomar(Codigo);
        }

    }
}
