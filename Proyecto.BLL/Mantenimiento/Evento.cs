using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Evento
    {
        readonly EventoDAO eventoDAO = new();

        public List<EventoDTO> ObtenerEventos()
        {
            return eventoDAO.ObtenerEventos();
        }

        public string AgregarEvento(EventoDTO eventoDto)
        {
            return eventoDAO.AgregarEvento(eventoDto);
        }

        public EventoDTO BuscarEventoID(int Codigo)
        {
            return eventoDAO.BuscarEventoID(Codigo);
        }

        public string ActualizarEvento(EventoDTO eventoDTO)
        {
            return eventoDAO.ActualizarEvento(eventoDTO);
        }

        public bool EliminarEvento(EventoDTO eventoDTO)
        {
            return eventoDAO.EliminarEvento(eventoDTO);
        }

    }
}
