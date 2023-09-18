using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CausalLiquidacion
    {
        readonly CausalLiquidacionDAO causalLiquidacionDAO = new();

        public List<CausalLiquidacionDTO> ObtenerCausalLiquidacions()
        {
            return causalLiquidacionDAO.ObtenerCausalLiquidacions();
        }

        public string AgregarCausalLiquidacion(CausalLiquidacionDTO causalLiquidacionDto)
        {
            return causalLiquidacionDAO.AgregarCausalLiquidacion(causalLiquidacionDto);
        }

        public CausalLiquidacionDTO BuscarCausalLiquidacionID(int Codigo)
        {
            return causalLiquidacionDAO.BuscarCausalLiquidacionID(Codigo);
        }

        public string ActualizarCausalLiquidacion(CausalLiquidacionDTO causalLiquidacionDTO)
        {
            return causalLiquidacionDAO.ActualizarCausalLiquidacion(causalLiquidacionDTO);
        }

        public string EliminarCausalLiquidacion(CausalLiquidacionDTO causalLiquidacionDTO)
        {
            return causalLiquidacionDAO.EliminarCausalLiquidacion(causalLiquidacionDTO);
        }

    }
}
