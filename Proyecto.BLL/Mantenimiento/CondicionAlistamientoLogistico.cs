using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionAlistamientoLogistico
    {
        readonly CondicionAlistamientoLogisticoDAO condicionAlistamientoLogisticoDAO = new();

        public List<CondicionAlistamientoLogisticoDTO> ObtenerCondicionAlistamientoLogisticos()
        {
            return condicionAlistamientoLogisticoDAO.ObtenerCondicionAlistamientoLogisticos();
        }

        public string AgregarCondicionAlistamientoLogistico(CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDto)
        {
            return condicionAlistamientoLogisticoDAO.AgregarCondicionAlistamientoLogistico(condicionAlistamientoLogisticoDto);
        }

        public CondicionAlistamientoLogisticoDTO BuscarCondicionAlistamientoLogisticoID(int Codigo)
        {
            return condicionAlistamientoLogisticoDAO.BuscarCondicionAlistamientoLogisticoID(Codigo);
        }

        public string ActualizarCondicionAlistamientoLogistico(CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDto)
        {
            return condicionAlistamientoLogisticoDAO.ActualizarCondicionAlistamientoLogistico(condicionAlistamientoLogisticoDto);
        }

        public string EliminarCondicionAlistamientoLogistico(CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDto)
        {
            return condicionAlistamientoLogisticoDAO.EliminarCondicionAlistamientoLogistico(condicionAlistamientoLogisticoDto);
        }

    }
}
