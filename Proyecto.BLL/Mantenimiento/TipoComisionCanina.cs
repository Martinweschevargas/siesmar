using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoComisionCanina
    {
        readonly TipoComisionCaninaDAO tipoComisionCaninaDAO = new();

        public List<TipoComisionCaninaDTO> ObtenerTipoComisionCaninas()
        {
            return tipoComisionCaninaDAO.ObtenerTipoComisionCaninas();
        }

        public string AgregarTipoComisionCanina(TipoComisionCaninaDTO tipoComisionCaninaDto)
        {
            return tipoComisionCaninaDAO.AgregarTipoComisionCanina(tipoComisionCaninaDto);
        }

        public TipoComisionCaninaDTO BuscarTipoComisionCaninaID(int Codigo)
        {
            return tipoComisionCaninaDAO.BuscarTipoComisionCaninaID(Codigo);
        }

        public string ActualizarTipoComisionCanina(TipoComisionCaninaDTO tipoComisionCaninaDTO)
        {
            return tipoComisionCaninaDAO.ActualizarTipoComisionCanina(tipoComisionCaninaDTO);
        }

        public bool EliminarTipoComisionCanina(TipoComisionCaninaDTO tipoComisionCaninaDTO)
        {
            return tipoComisionCaninaDAO.EliminarTipoComisionCanina(tipoComisionCaninaDTO);
        }

    }
}
