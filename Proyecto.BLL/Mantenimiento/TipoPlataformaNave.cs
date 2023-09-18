using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPlataformaNave
    {
        readonly TipoPlataformaNaveDAO tipoPlataformaNaveDAO = new();

        public List<TipoPlataformaNaveDTO> ObtenerTipoPlataformaNaves()
        {
            return tipoPlataformaNaveDAO.ObtenerTipoPlataformaNaves();
        }

        public string AgregarTipoPlataformaNave(TipoPlataformaNaveDTO tipoPlataformaNaveDto)
        {
            return tipoPlataformaNaveDAO.AgregarTipoPlataformaNave(tipoPlataformaNaveDto);
        }

        public TipoPlataformaNaveDTO BuscarTipoPlataformaNaveID(int Codigo)
        {
            return tipoPlataformaNaveDAO.BuscarTipoPlataformaNaveID(Codigo);
        }

        public string ActualizarTipoPlataformaNave(TipoPlataformaNaveDTO tipoPlataformaNaveDto)
        {
            return tipoPlataformaNaveDAO.ActualizarTipoPlataformaNave(tipoPlataformaNaveDto);
        }

        public string EliminarTipoPlataformaNave(TipoPlataformaNaveDTO tipoPlataformaNaveDto)
        {
            return tipoPlataformaNaveDAO.EliminarTipoPlataformaNave(tipoPlataformaNaveDto);
        }

    }
}
