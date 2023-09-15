using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoSiniestro
    {
        readonly TipoSiniestroDAO TipoSiniestroDAO = new();

        public List<TipoSiniestroDTO> ObtenerCapintanias()
        {
            return TipoSiniestroDAO.ObtenerTipoSiniestros();
        }

        public string AgregarTipoSiniestro(TipoSiniestroDTO TipoSiniestroDto)
        {
            return TipoSiniestroDAO.AgregarTipoSiniestro(TipoSiniestroDto);
        }

        public TipoSiniestroDTO BuscarTipoSiniestroID(int Codigo)
        {
            return TipoSiniestroDAO.BuscarTipoSiniestroID(Codigo);
        }

        public string ActualizarTipoSiniestro(TipoSiniestroDTO TipoSiniestroDTO)
        {
            return TipoSiniestroDAO.ActualizarTipoSiniestro(TipoSiniestroDTO);
        }

        public string EliminarTipoSiniestro(TipoSiniestroDTO TipoSiniestroDTO)
        {
            return TipoSiniestroDAO.EliminarTipoSiniestro(TipoSiniestroDTO);
        }

    }
}
