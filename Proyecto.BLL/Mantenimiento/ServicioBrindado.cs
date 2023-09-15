using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ServicioBrindado
    {
        readonly ServicioBrindadoDAO ServicioBrindadoDAO = new();

        public List<ServicioBrindadoDTO> ObtenerServicioBrindados()
        {
            return ServicioBrindadoDAO.ObtenerServicioBrindados();
        }

        public string AgregarServicioBrindado(ServicioBrindadoDTO servicioBrindadoDTO)
        {
            return ServicioBrindadoDAO.AgregarServicioBrindado(servicioBrindadoDTO);
        }

        public ServicioBrindadoDTO BuscarServicioBrindadoID(int Codigo)
        {
            return ServicioBrindadoDAO.BuscarServicioBrindadoID(Codigo);
        }

        public string ActualizarServicioBrindado(ServicioBrindadoDTO servicioBrindadoDTO)
        {
            return ServicioBrindadoDAO.ActualizarServicioBrindado(servicioBrindadoDTO);
        }

        public string EliminarServicioBrindado(ServicioBrindadoDTO servicioBrindadoDTO)
        {
            return ServicioBrindadoDAO.EliminarServicioBrindado(servicioBrindadoDTO);
        }

    }
}
