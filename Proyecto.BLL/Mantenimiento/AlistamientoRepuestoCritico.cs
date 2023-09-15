using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoRepuestoCritico
    {
        readonly AlistamientoRepuestoCriticoDAO alistamientoRepuestoCriticoDAO = new();

        public List<AlistamientoRepuestoCriticoDTO> ObtenerAlistamientoRepuestoCriticos()
        {
            return alistamientoRepuestoCriticoDAO.ObtenerAlistamientoRepuestoCriticos();
        }

        public string AgregarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO alistamientoRepuestoCriticoDto)
        {
            return alistamientoRepuestoCriticoDAO.AgregarAlistamientoRepuestoCritico(alistamientoRepuestoCriticoDto);
        }

        public AlistamientoRepuestoCriticoDTO BuscarAlistamientoRepuestoCriticoID(int Codigo)
        {
            return alistamientoRepuestoCriticoDAO.BuscarAlistamientoRepuestoCriticoID(Codigo);
        }

        public string ActualizarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO alistamientoRepuestoCriticoDto)
        {
            return alistamientoRepuestoCriticoDAO.ActualizarAlistamientoRepuestoCritico(alistamientoRepuestoCriticoDto);
        }

        public string EliminarAlistamientoRepuestoCritico(AlistamientoRepuestoCriticoDTO alistamientoRepuestoCriticoDto)
        {
            return alistamientoRepuestoCriticoDAO.EliminarAlistamientoRepuestoCritico(alistamientoRepuestoCriticoDto);
        }

    }
}
