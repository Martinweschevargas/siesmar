using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoComunicacionDirtel
    {
        readonly TipoComunicacionDirtelDAO tipoComunicacionDirtelDAO = new();

        public List<TipoComunicacionDirtelDTO> ObtenerTipoComunicacionDirtels()
        {
            return tipoComunicacionDirtelDAO.ObtenerTipoComunicacionDirtels();
        }

        public string AgregarTipoComunicacionDirtel(TipoComunicacionDirtelDTO tipoComunicacionDirtelDto)
        {
            return tipoComunicacionDirtelDAO.AgregarTipoComunicacionDirtel(tipoComunicacionDirtelDto);
        }

        public TipoComunicacionDirtelDTO BuscarTipoComunicacionDirtelID(int Codigo)
        {
            return tipoComunicacionDirtelDAO.BuscarTipoComunicacionDirtelID(Codigo);
        }

        public string ActualizarTipoComunicacionDirtel(TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO)
        {
            return tipoComunicacionDirtelDAO.ActualizarTipoComunicacionDirtel(tipoComunicacionDirtelDTO);
        }

        public string EliminarTipoComunicacionDirtel(TipoComunicacionDirtelDTO tipoComunicacionDirtelDTO)
        {
            return tipoComunicacionDirtelDAO.EliminarTipoComunicacionDirtel(tipoComunicacionDirtelDTO);
        }

    }
}
