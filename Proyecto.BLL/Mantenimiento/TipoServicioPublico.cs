using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoServicioPublico
    {
        readonly TipoServicioPublicoDAO tipoServicioPublicoDAO = new();

        public List<TipoServicioPublicoDTO> ObtenerCapintanias()
        {
            return tipoServicioPublicoDAO.ObtenerTipoServicioPublicos();
        }

        public string AgregarTipoServicioPublico(TipoServicioPublicoDTO tipoServicioPublicoDto)
        {
            return tipoServicioPublicoDAO.AgregarTipoServicioPublico(tipoServicioPublicoDto);
        }

        public TipoServicioPublicoDTO BuscarTipoServicioPublicoID(int Codigo)
        {
            return tipoServicioPublicoDAO.BuscarTipoServicioPublicoID(Codigo);
        }

        public string ActualizarTipoServicioPublico(TipoServicioPublicoDTO tipoServicioPublicoDTO)
        {
            return tipoServicioPublicoDAO.ActualizarTipoServicioPublico(tipoServicioPublicoDTO);
        }

        public bool EliminarTipoServicioPublico(TipoServicioPublicoDTO tipoServicioPublicoDTO)
        {
            return tipoServicioPublicoDAO.EliminarTipoServicioPublico(tipoServicioPublicoDTO);
        }

    }
}
