using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Condicion
    {
        readonly CondicionDAO condicionDAO = new();

        public List<CondicionDTO> ObtenerCondicions()
        {
            return condicionDAO.ObtenerCondicions();
        }

        public string AgregarCondicion(CondicionDTO condicionDto)
        {
            return condicionDAO.AgregarCondicion(condicionDto);
        }

        public CondicionDTO BuscarCondicionID(int Codigo)
        {
            return condicionDAO.BuscarCondicionID(Codigo);
        }

        public string ActualizarCondicion(CondicionDTO condicionDto)
        {
            return condicionDAO.ActualizarCondicion(condicionDto);
        }

        public string EliminarCondicion(CondicionDTO condicionDto)
        {
            return condicionDAO.EliminarCondicion(condicionDto);
        }

    }
}
