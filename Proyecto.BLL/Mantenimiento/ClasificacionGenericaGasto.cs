using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionGenericaGasto
    {
        readonly ClasificacionGenericaGastoDAO clasificacionGenericaGastoDAO = new();

        public List<ClasificacionGenericaGastoDTO> ObtenerClasificacionGenericaGastos()
        {
            return clasificacionGenericaGastoDAO.ObtenerClasificacionGenericaGastos();
        }

        public string AgregarClasificacionGenericaGasto(ClasificacionGenericaGastoDTO clasificacionGenericaGastoDto)
        {
            return clasificacionGenericaGastoDAO.AgregarClasificacionGenericaGasto(clasificacionGenericaGastoDto);
        }

        public ClasificacionGenericaGastoDTO BuscarClasificacionGenericaGastoID(int Codigo)
        {
            return clasificacionGenericaGastoDAO.BuscarClasificacionGenericaGastoID(Codigo);
        }

        public string ActualizarClasificacionGenericaGasto(ClasificacionGenericaGastoDTO clasificacionGenericaGastoDto)
        {
            return clasificacionGenericaGastoDAO.ActualizarClasificacionGenericaGasto(clasificacionGenericaGastoDto);
        }

        public string EliminarClasificacionGenericaGasto(ClasificacionGenericaGastoDTO clasificacionGenericaGastoDto)
        {
            return clasificacionGenericaGastoDAO.EliminarClasificacionGenericaGasto(clasificacionGenericaGastoDto);
        }

    }
}
