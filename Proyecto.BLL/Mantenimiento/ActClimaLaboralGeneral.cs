using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ActClimaLaboralGeneral
    {
        readonly ActClimaLaboralGeneralDAO actClimaLaboralGeneralDAO = new();

        public List<ActClimaLaboralGeneralDTO> ObtenerActClimaLaboralGenerals()
        {
            return actClimaLaboralGeneralDAO.ObtenerActClimaLaboralGenerales();
        }

        public string AgregarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO actClimaLaboralGeneralDto)
        {
            return actClimaLaboralGeneralDAO.AgregarActClimaLaboralGeneral(actClimaLaboralGeneralDto);
        }

        public ActClimaLaboralGeneralDTO BuscarActClimaLaboralGeneralID(int Codigo)
        {
            return actClimaLaboralGeneralDAO.BuscarActClimaLaboralGeneralID(Codigo);
        }

        public string ActualizarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO actClimaLaboralGeneralDto)
        {
            return actClimaLaboralGeneralDAO.ActualizarActClimaLaboralGeneral(actClimaLaboralGeneralDto);
        }

        public string EliminarActClimaLaboralGeneral(ActClimaLaboralGeneralDTO actClimaLaboralGeneralDto)
        {
            return actClimaLaboralGeneralDAO.EliminarActClimaLaboralGeneral(actClimaLaboralGeneralDto);
        }

    }
}
