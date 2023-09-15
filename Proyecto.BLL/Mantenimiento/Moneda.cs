using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Moneda
    {
        readonly MonedaDAO monedaDAO = new();

        public List<MonedaDTO> ObtenerMonedas()
        {
            return monedaDAO.ObtenerMonedas();
        }

        public string AgregarMoneda(MonedaDTO monedaDto)
        {
            return monedaDAO.AgregarMoneda(monedaDto);
        }

        public MonedaDTO BuscarMonedaID(int Codigo)
        {
            return monedaDAO.BuscarMonedaID(Codigo);
        }

        public string ActualizarMoneda(MonedaDTO monedaDTO)
        {
            return monedaDAO.ActualizarMoneda(monedaDTO);
        }

        public string EliminarMoneda(MonedaDTO monedaDTO)
        {
            return monedaDAO.EliminarMoneda(monedaDTO);
        }

    }
}
