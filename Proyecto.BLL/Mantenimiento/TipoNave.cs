using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoNave
    {
        readonly TipoNaveDAO tipoNaveDAO = new();

        public List<TipoNaveDTO> ObtenerTipoNaves()
        {
            return tipoNaveDAO.ObtenerTipoNaves();
        }

        public string AgregarTipoNave(TipoNaveDTO tipoNaveDto)
        {
            return tipoNaveDAO.AgregarTipoNave(tipoNaveDto);
        }

        public TipoNaveDTO BuscarTipoNaveID(int Codigo)
        {
            return tipoNaveDAO.BuscarTipoNaveID(Codigo);
        }

        public string ActualizarTipoNave(TipoNaveDTO tipoNaveDTO)
        {
            return tipoNaveDAO.ActualizarTipoNave(tipoNaveDTO);
        }

        public string EliminarTipoNave(TipoNaveDTO tipoNaveDTO)
        {
            return tipoNaveDAO.EliminarTipoNave(tipoNaveDTO);
        }

    }
}
