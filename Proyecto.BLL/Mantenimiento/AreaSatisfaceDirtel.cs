using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AreaSatisfaceDirtel
    {
        readonly AreaSatisfaceDirtelDAO areaSatisfaceDirtelDAO = new();

        public List<AreaSatisfaceDirtelDTO> ObtenerAreaSatisfaceDirtels()
        {
            return areaSatisfaceDirtelDAO.ObtenerAreaSatisfaceDirtels();
        }

        public string AgregarAreaSatisfaceDirtel(AreaSatisfaceDirtelDTO areaSatisfaceDirtelDto)
        {
            return areaSatisfaceDirtelDAO.AgregarAreaSatisfaceDirtel(areaSatisfaceDirtelDto);
        }

        public AreaSatisfaceDirtelDTO BuscarAreaSatisfaceDirtelID(int Codigo)
        {
            return areaSatisfaceDirtelDAO.BuscarAreaSatisfaceDirtelID(Codigo);
        }

        public string ActualizarAreaSatisfaceDirtel(AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO)
        {
            return areaSatisfaceDirtelDAO.ActualizarAreaSatisfaceDirtel(areaSatisfaceDirtelDTO);
        }

        public string EliminarAreaSatisfaceDirtel(AreaSatisfaceDirtelDTO areaSatisfaceDirtelDTO)
        {
            return areaSatisfaceDirtelDAO.EliminarAreaSatisfaceDirtel(areaSatisfaceDirtelDTO);
        }

    }
}
