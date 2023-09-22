using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Partida
    {
        readonly PartidaDAO partidaDAO = new();

        public List<PartidaDTO> ObtenerPartidas()
        {
            return partidaDAO.ObtenerPartidas();
        }

        public string AgregarPartida(PartidaDTO partidaDto)
        {
            return partidaDAO.AgregarPartida(partidaDto);
        }

        public PartidaDTO BuscarPartidaID(int Codigo)
        {
            return partidaDAO.BuscarPartidaID(Codigo);
        }

        public string ActualizarPartida(PartidaDTO partidaDTO)
        {
            return partidaDAO.ActualizarPartida(partidaDTO);
        }

        public string EliminarPartida(PartidaDTO partidaDTO)
        {
            return partidaDAO.EliminarPartida(partidaDTO);
        }

    }
}
