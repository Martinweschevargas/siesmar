using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SubsistemaRepuestoCritico
    {
        readonly SubsistemaRepuestoCriticoDAO subsistemaRepuestoCriticoDAO = new();

        public List<SubsistemaRepuestoCriticoDTO> ObtenerSubsistemaRepuestoCriticos()
        {
            return subsistemaRepuestoCriticoDAO.ObtenerSubsistemaRepuestoCriticos();
        }

        public string AgregarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO subsistemaRepuestoCriticoDto)
        {
            return subsistemaRepuestoCriticoDAO.AgregarSubsistemaRepuestoCritico(subsistemaRepuestoCriticoDto);
        }

        public SubsistemaRepuestoCriticoDTO BuscarSubsistemaRepuestoCriticoID(int Codigo)
        {
            return subsistemaRepuestoCriticoDAO.BuscarSubsistemaRepuestoCriticoID(Codigo);
        }

        public string ActualizarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO subsistemaRepuestoCriticoDto)
        {
            return subsistemaRepuestoCriticoDAO.ActualizarSubsistemaRepuestoCritico(subsistemaRepuestoCriticoDto);
        }

        public string EliminarSubsistemaRepuestoCritico(SubsistemaRepuestoCriticoDTO subsistemaRepuestoCriticoDto)
        {
            return subsistemaRepuestoCriticoDAO.EliminarSubsistemaRepuestoCritico(subsistemaRepuestoCriticoDto);
        }

    }
}
