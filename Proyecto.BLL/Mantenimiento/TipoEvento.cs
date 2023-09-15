using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEvento
    {
        readonly TipoEventoDAO tipoEventoDAO = new();

        public List<TipoEventoDTO> ObtenerTipoEventos()
        {
            return tipoEventoDAO.ObtenerTipoEventos();
        }

        public string AgregarTipoEvento(TipoEventoDTO tipoEventoDto)
        {
            return tipoEventoDAO.AgregarTipoEvento(tipoEventoDto);
        }

        public TipoEventoDTO BuscarTipoEventoID(int Codigo)
        {
            return tipoEventoDAO.BuscarTipoEventoID(Codigo);
        }

        public string ActualizarTipoEvento(TipoEventoDTO tipoEventoDTO)
        {
            return tipoEventoDAO.ActualizarTipoEvento(tipoEventoDTO);
        }

        public bool EliminarTipoEvento(TipoEventoDTO tipoEventoDTO)
        {
            return tipoEventoDAO.EliminarTipoEvento(tipoEventoDTO);
        }

    }
}
