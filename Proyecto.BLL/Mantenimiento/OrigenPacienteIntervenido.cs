using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class OrigenPacienteIntervenido
    {
        readonly OrigenPacienteIntervenidoDAO origenPacienteIntervenidoDAO = new();

        public List<OrigenPacienteIntervenidoDTO> ObtenerOrigenPacienteIntervenidos()
        {
            return origenPacienteIntervenidoDAO.ObtenerOrigenPacienteIntervenidos();
        }

        public string AgregarOrigenPacienteIntervenido(OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDto)
        {
            return origenPacienteIntervenidoDAO.AgregarOrigenPacienteIntervenido(origenPacienteIntervenidoDto);
        }

        public OrigenPacienteIntervenidoDTO BuscarOrigenPacienteIntervenidoID(int Codigo)
        {
            return origenPacienteIntervenidoDAO.BuscarOrigenPacienteIntervenidoID(Codigo);
        }

        public string ActualizarOrigenPacienteIntervenido(OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDto)
        {
            return origenPacienteIntervenidoDAO.ActualizarOrigenPacienteIntervenido(origenPacienteIntervenidoDto);
        }

        public string EliminarOrigenPacienteIntervenido(OrigenPacienteIntervenidoDTO origenPacienteIntervenidoDto)
        {
            return origenPacienteIntervenidoDAO.EliminarOrigenPacienteIntervenido(origenPacienteIntervenidoDto);
        }

    }
}
