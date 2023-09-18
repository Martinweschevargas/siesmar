using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CausalBaja
    {
        readonly CausalBajaDAO causalBajaDAO = new();

        public List<CausalBajaDTO> ObtenerCausalBajas()
        {
            return causalBajaDAO.ObtenerCausalBajas();
        }

        public string AgregarCausalBaja(CausalBajaDTO causalBajaDto)
        {
            return causalBajaDAO.AgregarCausalBaja(causalBajaDto);
        }

        public CausalBajaDTO BuscarCausalBajaID(int Codigo)
        {
            return causalBajaDAO.BuscarCausalBajaID(Codigo);
        }

        public string ActualizarCausalBaja(CausalBajaDTO causalBajaDto)
        {
            return causalBajaDAO.ActualizarCausalBaja(causalBajaDto);
        }

        public string EliminarCausalBaja(CausalBajaDTO causalBajaDto)
        {
            return causalBajaDAO.EliminarCausalBaja(causalBajaDto);
        }

    }
}
