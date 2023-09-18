using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Unidad
    {
        readonly UnidadDAO unidadDAO = new();

        public List<UnidadDTO> ObtenerUnidads()
        {
            return unidadDAO.ObtenerUnidads();
        }

        public string AgregarUnidad(UnidadDTO unidadDto)
        {
            return unidadDAO.AgregarUnidad(unidadDto);
        }

        public UnidadDTO BuscarUnidadID(int Codigo)
        {
            return unidadDAO.BuscarUnidadID(Codigo);
        }

        public string ActualizarUnidad(UnidadDTO unidadDto)
        {
            return unidadDAO.ActualizarUnidad(unidadDto);
        }

        public string EliminarUnidad(UnidadDTO unidadDto)
        {
            return unidadDAO.EliminarUnidad(unidadDto);
        }

    }
}
