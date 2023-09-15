using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CapacidadOperativaRequerida
    {
        readonly CapacidadOperativaRequeridaDAO capacidadOperativaRequeridaDAO = new();

        public List<CapacidadOperativaRequeridaDTO> ObtenerCapacidadOperativaRequeridas()
        {
            return capacidadOperativaRequeridaDAO.ObtenerCapacidadOperativaRequeridas();
        }

        public string AgregarCapacidadOperativaRequerida(CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDto)
        {
            return capacidadOperativaRequeridaDAO.AgregarCapacidadOperativaRequerida(capacidadOperativaRequeridaDto);
        }

        public CapacidadOperativaRequeridaDTO BuscarCapacidadOperativaRequeridaID(int Codigo)
        {
            return capacidadOperativaRequeridaDAO.BuscarCapacidadOperativaRequeridaID(Codigo);
        }

        public string ActualizarCapacidadOperativaRequerida(CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDto)
        {
            return capacidadOperativaRequeridaDAO.ActualizarCapacidadOperativaRequerida(capacidadOperativaRequeridaDto);
        }

        public string EliminarCapacidadOperativaRequerida(CapacidadOperativaRequeridaDTO capacidadOperativaRequeridaDto)
        {
            return capacidadOperativaRequeridaDAO.EliminarCapacidadOperativaRequerida(capacidadOperativaRequeridaDto);
        }

    }
}
