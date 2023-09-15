using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SistemaRepuestoCritico
    {
        readonly SistemaRepuestoCriticoDAO sistemaRepuestoCriticoDAO = new();

        public List<SistemaRepuestoCriticoDTO> ObtenerSistemaRepuestoCriticos()
        {
            return sistemaRepuestoCriticoDAO.ObtenerSistemaRepuestoCriticos();
        }

        public string AgregarSistemaRepuestoCritico(SistemaRepuestoCriticoDTO sistemaRepuestoCriticoDto)
        {
            return sistemaRepuestoCriticoDAO.AgregarSistemaRepuestoCritico(sistemaRepuestoCriticoDto);
        }

        public SistemaRepuestoCriticoDTO BuscarSistemaRepuestoCriticoID(int Codigo)
        {
            return sistemaRepuestoCriticoDAO.BuscarSistemaRepuestoCriticoID(Codigo);
        }

        public string ActualizarSistemaRepuestoCritico(SistemaRepuestoCriticoDTO sistemaRepuestoCriticoDto)
        {
            return sistemaRepuestoCriticoDAO.ActualizarSistemaRepuestoCritico(sistemaRepuestoCriticoDto);
        }

        public string EliminarSistemaRepuestoCritico(SistemaRepuestoCriticoDTO sistemaRepuestoCriticoDto)
        {
            return sistemaRepuestoCriticoDAO.EliminarSistemaRepuestoCritico(sistemaRepuestoCriticoDto);
        }

    }
}
