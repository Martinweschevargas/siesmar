using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoSituacionBien
    {
        readonly TipoSituacionBienDAO tipoSituacionBienDAO = new();

        public List<TipoSituacionBienDTO> ObtenerTipoSituacionBiens()
        {
            return tipoSituacionBienDAO.ObtenerTipoSituacionBiens();
        }

        public string AgregarTipoSituacionBien(TipoSituacionBienDTO tipoSituacionBienDto)
        {
            return tipoSituacionBienDAO.AgregarTipoSituacionBien(tipoSituacionBienDto);
        }

        public TipoSituacionBienDTO BuscarTipoSituacionBienID(int Codigo)
        {
            return tipoSituacionBienDAO.BuscarTipoSituacionBienID(Codigo);
        }

        public string ActualizarTipoSituacionBien(TipoSituacionBienDTO tipoSituacionBienDTO)
        {
            return tipoSituacionBienDAO.ActualizarTipoSituacionBien(tipoSituacionBienDTO);
        }

        public bool EliminarTipoSituacionBien(TipoSituacionBienDTO tipoSituacionBienDTO)
        {
            return tipoSituacionBienDAO.EliminarTipoSituacionBien(tipoSituacionBienDTO);
        }

    }
}
