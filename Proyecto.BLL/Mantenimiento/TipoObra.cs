using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoObra
    {
        readonly TipoObraDAO capitaniaDAO = new();

        public List<TipoObraDTO> ObtenerTipoObras()
        {
            return capitaniaDAO.ObtenerTipoObras();
        }

        public string AgregarTipoObra(TipoObraDTO capitaniaDto)
        {
            return capitaniaDAO.AgregarTipoObra(capitaniaDto);
        }

        public TipoObraDTO BuscarTipoObraID(int Codigo)
        {
            return capitaniaDAO.BuscarTipoObraID(Codigo);
        }

        public string ActualizarTipoObra(TipoObraDTO capitaniaDto)
        {
            return capitaniaDAO.ActualizarTipoObra(capitaniaDto);
        }

        public string EliminarTipoObra(TipoObraDTO capitaniaDto)
        {
            return capitaniaDAO.EliminarTipoObra(capitaniaDto);
        }

    }
}
