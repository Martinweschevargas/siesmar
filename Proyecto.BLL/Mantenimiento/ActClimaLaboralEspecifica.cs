using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ActClimaLaboralEspecifica
    {
        readonly ActClimaLaboralEspecificaDAO actClimaLaboralEspecificaDAO = new();

        public List<ActClimaLaboralEspecificaDTO> ObtenerActClimaLaboralEspecificas()
        {
            return actClimaLaboralEspecificaDAO.ObtenerActClimaLaboralEspecificas();
        }

        public string AgregarActClimaLaboralEspecifica(ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDto)
        {
            return actClimaLaboralEspecificaDAO.AgregarActClimaLaboralEspecifica(actClimaLaboralEspecificaDto);
        }

        public ActClimaLaboralEspecificaDTO BuscarActClimaLaboralEspecificaID(int Codigo)
        {
            return actClimaLaboralEspecificaDAO.BuscarActClimaLaboralEspecificaID(Codigo);
        }

        public string ActualizarActClimaLaboralEspecifica(ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDto)
        {
            return actClimaLaboralEspecificaDAO.ActualizarActClimaLaboralEspecifica(actClimaLaboralEspecificaDto);
        }

        public string EliminarActClimaLaboralEspecifica(ActClimaLaboralEspecificaDTO actClimaLaboralEspecificaDto)
        {
            return actClimaLaboralEspecificaDAO.EliminarActClimaLaboralEspecifica(actClimaLaboralEspecificaDto);
        }

    }
}
