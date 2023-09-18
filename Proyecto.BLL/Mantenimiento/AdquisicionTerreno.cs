using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AdquisicionTerreno
    {
        readonly AdquisicionTerrenoDAO adquisicionTerrenoDAO = new();

        public List<AdquisicionTerrenoDTO> ObtenerAdquisicionTerrenos()
        {
            return adquisicionTerrenoDAO.ObtenerAdquisicionTerrenos();
        }

        public string AgregarAdquisicionTerreno(AdquisicionTerrenoDTO adquisicionTerrenoDto)
        {
            return adquisicionTerrenoDAO.AgregarAdquisicionTerreno(adquisicionTerrenoDto);
        }

        public AdquisicionTerrenoDTO BuscarAdquisicionTerrenoID(int Codigo)
        {
            return adquisicionTerrenoDAO.BuscarAdquisicionTerrenoID(Codigo);
        }

        public string ActualizarAdquisicionTerreno(AdquisicionTerrenoDTO adquisicionTerrenoDto)
        {
            return adquisicionTerrenoDAO.ActualizarAdquisicionTerreno(adquisicionTerrenoDto);
        }

        public string EliminarAdquisicionTerreno(AdquisicionTerrenoDTO adquisicionTerrenoDto)
        {
            return adquisicionTerrenoDAO.EliminarAdquisicionTerreno(adquisicionTerrenoDto);
        }

    }
}
