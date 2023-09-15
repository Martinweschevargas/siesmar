using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAtencion
    {
        readonly TipoAtencionDAO tipoAtencionDAO = new();

        public List<TipoAtencionDTO> ObtenerTipoAtencions()
        {
            return tipoAtencionDAO.ObtenerTipoAtencions();
        }

        public string AgregarTipoAtencion(TipoAtencionDTO tipoAtencionDto)
        {
            return tipoAtencionDAO.AgregarTipoAtencion(tipoAtencionDto);
        }

        public TipoAtencionDTO BuscarTipoAtencionID(int Codigo)
        {
            return tipoAtencionDAO.BuscarTipoAtencionID(Codigo);
        }

        public string ActualizarTipoAtencion(TipoAtencionDTO tipoAtencionDTO)
        {
            return tipoAtencionDAO.ActualizarTipoAtencion(tipoAtencionDTO);
        }

        public bool EliminarTipoAtencion(TipoAtencionDTO tipoAtencionDTO)
        {
            return tipoAtencionDAO.EliminarTipoAtencion(tipoAtencionDTO);
        }

    }
}
