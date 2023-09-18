using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AreaDiperadmon
    {
        readonly AreaDiperadmonDAO AreaDiperadmonDAO = new();

        public List<AreaDiperadmonDTO> ObtenerAreaDiperadmons()
        {
            return AreaDiperadmonDAO.ObtenerAreaDiperadmons();
        }

        public string AgregarAreaDiperadmon(AreaDiperadmonDTO areaDiperadmonDto)
        {
            return AreaDiperadmonDAO.AgregarAreaDiperadmon(areaDiperadmonDto);
        }

        public AreaDiperadmonDTO BuscarAreaDiperadmonID(int Codigo)
        {
            return AreaDiperadmonDAO.BuscarAreaDiperadmonID(Codigo);
        }

        public string ActualizarAreaDiperadmon(AreaDiperadmonDTO areaDiperadmonDto)
        {
            return AreaDiperadmonDAO.ActualizarAreaDiperadmon(areaDiperadmonDto);
        }

        public string EliminarAreaDiperadmon(AreaDiperadmonDTO areaDiperadmonDto)
        {
            return AreaDiperadmonDAO.EliminarAreaDiperadmon(areaDiperadmonDto);
        }

    }
}
