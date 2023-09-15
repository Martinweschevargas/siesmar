using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MontoInversion
    {
        readonly MontoInversionDAO montoInversionDAO = new();

        public List<MontoInversionDTO> ObtenerMontoInversions()
        {
            return montoInversionDAO.ObtenerMontoInversions();
        }

        public string AgregarMontoInversion(MontoInversionDTO montoInversionDto)
        {
            return montoInversionDAO.AgregarMontoInversion(montoInversionDto);
        }

        public MontoInversionDTO BuscarMontoInversionID(int Codigo)
        {
            return montoInversionDAO.BuscarMontoInversionID(Codigo);
        }

        public string ActualizarMontoInversion(MontoInversionDTO montoInversionDTO)
        {
            return montoInversionDAO.ActualizarMontoInversion(montoInversionDTO);
        }

        public bool EliminarMontoInversion(int Codigo)
        {
            return montoInversionDAO.EliminarMontoInversion(Codigo);
        }

    }
}
