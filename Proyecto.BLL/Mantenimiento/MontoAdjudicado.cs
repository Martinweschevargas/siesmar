using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MontoAdjudicado
    {
        readonly MontoAdjudicadoDAO montoAdjudicadoDAO = new();

        public List<MontoAdjudicadoDTO> ObtenerMontoAdjudicados()
        {
            return montoAdjudicadoDAO.ObtenerMontoAdjudicados();
        }

        public string AgregarMontoAdjudicado(MontoAdjudicadoDTO montoAdjudicadoDto)
        {
            return montoAdjudicadoDAO.AgregarMontoAdjudicado(montoAdjudicadoDto);
        }

        public MontoAdjudicadoDTO BuscarMontoAdjudicadoID(int Codigo)
        {
            return montoAdjudicadoDAO.BuscarMontoAdjudicadoID(Codigo);
        }

        public string ActualizarMontoAdjudicado(MontoAdjudicadoDTO montoAdjudicadoDTO)
        {
            return montoAdjudicadoDAO.ActualizarMontoAdjudicado(montoAdjudicadoDTO);
        }

        public bool EliminarMontoAdjudicado(int Codigo)
        {
            return montoAdjudicadoDAO.EliminarMontoAdjudicado(Codigo);
        }

    }
}
