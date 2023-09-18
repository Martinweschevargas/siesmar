using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AreaCT
    {
        readonly AreaCTDAO areaCTDAO = new();

        public List<AreaCTDTO> ObtenerAreaCTs()
        {
            return areaCTDAO.ObtenerAreaCTs();
        }

        public string AgregarAreaCT(AreaCTDTO areaCTDto)
        {
            return areaCTDAO.AgregarAreaCT(areaCTDto);
        }

        public AreaCTDTO BuscarAreaCTID(int Codigo)
        {
            return areaCTDAO.BuscarAreaCTID(Codigo);
        }

        public string ActualizarAreaCT(AreaCTDTO areaCTDTO)
        {
            return areaCTDAO.ActualizarAreaCT(areaCTDTO);
        }

        public bool EliminarAreaCT(AreaCTDTO areaCTDTO)
        {
            return areaCTDAO.EliminarAreaCT(areaCTDTO);
        }

    }
}
