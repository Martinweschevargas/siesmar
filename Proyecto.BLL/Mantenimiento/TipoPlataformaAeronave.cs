using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPlataformaAeronave
    {
        readonly TipoPlataformaAeronaveDAO tipoPlataformaAeronaveDAO = new();

        public List<TipoPlataformaAeronaveDTO> ObtenerTipoPlataformaAeronaves()
        {
            return tipoPlataformaAeronaveDAO.ObtenerTipoPlataformaAeronaves();
        }

        public string AgregarTipoPlataformaAeronave(TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDto)
        {
            return tipoPlataformaAeronaveDAO.AgregarTipoPlataformaAeronave(tipoPlataformaAeronaveDto);
        }

        public TipoPlataformaAeronaveDTO BuscarTipoPlataformaAeronaveID(int Codigo)
        {
            return tipoPlataformaAeronaveDAO.BuscarTipoPlataformaAeronaveID(Codigo);
        }

        public string ActualizarTipoPlataformaAeronave(TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDto)
        {
            return tipoPlataformaAeronaveDAO.ActualizarTipoPlataformaAeronave(tipoPlataformaAeronaveDto);
        }

        public string EliminarTipoPlataformaAeronave(TipoPlataformaAeronaveDTO tipoPlataformaAeronaveDto)
        {
            return tipoPlataformaAeronaveDAO.EliminarTipoPlataformaAeronave(tipoPlataformaAeronaveDto);
        }

    }
}
