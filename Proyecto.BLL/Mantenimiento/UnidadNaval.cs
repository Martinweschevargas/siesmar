using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadNaval
    {
        readonly UnidadNavalDAO unidadNavalDAO = new();

        public List<UnidadNavalDTO> ObtenerUnidadNavals()
        {
            return unidadNavalDAO.ObtenerUnidadNavals();
        }

        public string AgregarUnidadNaval(UnidadNavalDTO unidadNavalDto)
        {
            return unidadNavalDAO.AgregarUnidadNaval(unidadNavalDto);
        }

        public UnidadNavalDTO BuscarUnidadNavalID(int Codigo)
        {
            return unidadNavalDAO.BuscarUnidadNavalID(Codigo);
        }

        public string ActualizarUnidadNaval(UnidadNavalDTO unidadNavalDto)
        {
            return unidadNavalDAO.ActualizarUnidadNaval(unidadNavalDto);
        }

        public string EliminarUnidadNaval(UnidadNavalDTO unidadNavalDto)
        {
            return unidadNavalDAO.EliminarUnidadNaval(unidadNavalDto);
        }

    }
}
