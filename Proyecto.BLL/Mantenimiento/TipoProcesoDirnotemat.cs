using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoProcesoDirnotemat
    {
        readonly TipoProcesoDirnotematDAO tipoProcesoDirnotematDAO = new();

        public List<TipoProcesoDirnotematDTO> ObtenerTipoProcesoDirnotemats()
        {
            return tipoProcesoDirnotematDAO.ObtenerTipoProcesoDirnotemats();
        }

        public string AgregarTipoProcesoDirnotemat(TipoProcesoDirnotematDTO tipoProcesoDirnotematDto)
        {
            return tipoProcesoDirnotematDAO.AgregarTipoProcesoDirnotemat(tipoProcesoDirnotematDto);
        }

        public TipoProcesoDirnotematDTO BuscarTipoProcesoDirnotematID(int Codigo)
        {
            return tipoProcesoDirnotematDAO.BuscarTipoProcesoDirnotematID(Codigo);
        }

        public string ActualizarTipoProcesoDirnotemat(TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO)
        {
            return tipoProcesoDirnotematDAO.ActualizarTipoProcesoDirnotemat(tipoProcesoDirnotematDTO);
        }

        public bool EliminarTipoProcesoDirnotemat(TipoProcesoDirnotematDTO tipoProcesoDirnotematDTO)
        {
            return tipoProcesoDirnotematDAO.EliminarTipoProcesoDirnotemat(tipoProcesoDirnotematDTO);
        }

    }
}
