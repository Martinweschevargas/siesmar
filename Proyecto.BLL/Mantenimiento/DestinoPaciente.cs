using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DestinoPaciente
    {
        readonly DestinoPacienteDAO destinoPacienteDAO = new();

        public List<DestinoPacienteDTO> ObtenerDestinoPacientes()
        {
            return destinoPacienteDAO.ObtenerDestinoPacientes();
        }

        public string AgregarDestinoPaciente(DestinoPacienteDTO destinoPacienteDto)
        {
            return destinoPacienteDAO.AgregarDestinoPaciente(destinoPacienteDto);
        }

        public DestinoPacienteDTO BuscarDestinoPacienteID(int Codigo)
        {
            return destinoPacienteDAO.BuscarDestinoPacienteID(Codigo);
        }

        public string ActualizarDestinoPaciente(DestinoPacienteDTO destinoPacienteDto)
        {
            return destinoPacienteDAO.ActualizarDestinoPaciente(destinoPacienteDto);
        }

        public string EliminarDestinoPaciente(DestinoPacienteDTO destinoPacienteDto)
        {
            return destinoPacienteDAO.EliminarDestinoPaciente(destinoPacienteDto);
        }

    }
}
