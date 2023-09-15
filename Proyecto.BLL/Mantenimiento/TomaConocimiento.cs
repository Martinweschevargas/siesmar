using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TomaConocimiento
    {
        readonly TomaConocimientoDAO tomaConocimientoDAO = new();

        public List<TomaConocimientoDTO> ObtenerTomaConocimientos()
        {
            return tomaConocimientoDAO.ObtenerTomaConocimientos();
        }

        public string AgregarTomaConocimiento(TomaConocimientoDTO tomaConocimientoDto)
        {
            return tomaConocimientoDAO.AgregarTomaConocimiento(tomaConocimientoDto);
        }

        public TomaConocimientoDTO BuscarTomaConocimientoID(int Codigo)
        {
            return tomaConocimientoDAO.BuscarTomaConocimientoID(Codigo);
        }

        public string ActualizarTomaConocimiento(TomaConocimientoDTO tomaConocimientoDTO)
        {
            return tomaConocimientoDAO.ActualizarTomaConocimiento(tomaConocimientoDTO);
        }

        public bool EliminarTomaConocimiento(TomaConocimientoDTO tomaConocimientoDTO)
        {
            return tomaConocimientoDAO.EliminarTomaConocimiento(tomaConocimientoDTO);
        }

    }
}
