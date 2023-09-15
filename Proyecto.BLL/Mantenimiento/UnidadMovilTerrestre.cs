using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadMovilTerrestre
    {
        readonly UnidadMovilTerrestreDAO unidadMovilTerrestreDAO = new();

        public List<UnidadMovilTerrestreDTO> ObtenerUnidadMovilTerrestres()
        {
            return unidadMovilTerrestreDAO.ObtenerUnidadMovilTerrestres();
        }

        public string AgregarUnidadMovilTerrestre(UnidadMovilTerrestreDTO unidadMovilTerrestreDTO)
        {
            return unidadMovilTerrestreDAO.AgregarUnidadMovilTerrestre(unidadMovilTerrestreDTO);
        }

        public UnidadMovilTerrestreDTO BuscarUnidadMovilTerrestreID(int Codigo)
        {
            return unidadMovilTerrestreDAO.BuscarUnidadMovilTerrestreID(Codigo);
        }

        public string ActualizarUnidadMovilTerrestre(UnidadMovilTerrestreDTO unidadMovilTerrestreDTO)
        {
            return unidadMovilTerrestreDAO.ActualizarUnidadMovilTerrestre(unidadMovilTerrestreDTO);
        }

        public string EliminarUnidadMovilTerrestre(UnidadMovilTerrestreDTO unidadMovilTerrestreDTO)
        {
            return unidadMovilTerrestreDAO.EliminarUnidadMovilTerrestre(unidadMovilTerrestreDTO);
        }

    }
}