using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class OrigenTerreno
    {
        readonly OrigenTerrenoDAO origenTerrenoDAO = new();

        public List<OrigenTerrenoDTO> ObtenerOrigenTerrenos()
        {
            return origenTerrenoDAO.ObtenerOrigenTerrenos();
        }

        public string AgregarOrigenTerreno(OrigenTerrenoDTO origenTerrenoDto)
        {
            return origenTerrenoDAO.AgregarOrigenTerreno(origenTerrenoDto);
        }

        public OrigenTerrenoDTO BuscarOrigenTerrenoID(int Codigo)
        {
            return origenTerrenoDAO.BuscarOrigenTerrenoID(Codigo);
        }

        public string ActualizarOrigenTerreno(OrigenTerrenoDTO origenTerrenoDTO)
        {
            return origenTerrenoDAO.ActualizarOrigenTerreno(origenTerrenoDTO);
        }

        public bool EliminarOrigenTerreno(int Codigo)
        {
            return origenTerrenoDAO.EliminarOrigenTerreno(Codigo);
        }

    }
}
