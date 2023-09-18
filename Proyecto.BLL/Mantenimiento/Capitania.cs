using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Capitania
    {
        readonly CapitaniaDAO capitaniaDAO = new();

        public List<CapitaniaDTO> ObtenerCapitanias()
        {
            return capitaniaDAO.ObtenerCapitanias();
        }

        public string AgregarCapitania(CapitaniaDTO capitaniaDto)
        {
            return capitaniaDAO.AgregarCapitania(capitaniaDto);
        }

        public CapitaniaDTO BuscarCapitaniaID(int Codigo)
        {
            return capitaniaDAO.BuscarCapitaniaID(Codigo);
        }

        public string ActualizarCapitania(CapitaniaDTO capitaniaDto)
        {
            return capitaniaDAO.ActualizarCapitania(capitaniaDto);
        }

        public string EliminarCapitania(CapitaniaDTO capitaniaDto)
        {
            return capitaniaDAO.EliminarCapitania(capitaniaDto);
        }

    }
}
