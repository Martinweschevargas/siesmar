using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoServicioSastreria
    {
        readonly TipoServicioSastreriaDAO tipoServicioSastreriaDAO = new();

        public List<TipoServicioSastreriaDTO> ObtenerTipoServicioSastrerias()
        {
            return tipoServicioSastreriaDAO.ObtenerTipoServicioSastrerias();
        }

        public string AgregarTipoServicioSastreria(TipoServicioSastreriaDTO tipoServicioSastreriaDto)
        {
            return tipoServicioSastreriaDAO.AgregarTipoServicioSastreria(tipoServicioSastreriaDto);
        }

        public TipoServicioSastreriaDTO BuscarTipoServicioSastreriaID(int Codigo)
        {
            return tipoServicioSastreriaDAO.BuscarTipoServicioSastreriaID(Codigo);
        }

        public string ActualizarTipoServicioSastreria(TipoServicioSastreriaDTO tipoServicioSastreriaDto)
        {
            return tipoServicioSastreriaDAO.ActualizarTipoServicioSastreria(tipoServicioSastreriaDto);
        }

        public string EliminarTipoServicioSastreria(TipoServicioSastreriaDTO tipoServicioSastreriaDto)
        {
            return tipoServicioSastreriaDAO.EliminarTipoServicioSastreria(tipoServicioSastreriaDto);
        }

    }
}
