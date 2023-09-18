using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAeronave
    {
        readonly TipoAeronaveDAO tipoAeronaveDAO = new();

        public List<TipoAeronaveDTO> ObtenerTipoAeronaves()
        {
            return tipoAeronaveDAO.ObtenerTipoAeronaves();
        }

        public string AgregarTipoAeronave(TipoAeronaveDTO tipoAeronaveDto)
        {
            return tipoAeronaveDAO.AgregarTipoAeronave(tipoAeronaveDto);
        }

        public TipoAeronaveDTO BuscarTipoAeronaveID(int Codigo)
        {
            return tipoAeronaveDAO.BuscarTipoAeronaveID(Codigo);
        }

        public string ActualizarTipoAeronave(TipoAeronaveDTO tipoAeronaveDTO)
        {
            return tipoAeronaveDAO.ActualizarTipoAeronave(tipoAeronaveDTO);
        }

        public bool EliminarTipoAeronave(TipoAeronaveDTO tipoAeronaveDTO)
        {
            return tipoAeronaveDAO.EliminarTipoAeronave(tipoAeronaveDTO);
        }

    }
}
