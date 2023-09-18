using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UsuarioAlquilerCentroEsparcimiento
    {
        readonly UsuarioAlquilerCentroEsparcimientoDAO UsuarioAlquilerCentroEsparcimientoDAO = new();

        public List<UsuarioAlquilerCentroEsparcimientoDTO> ObtenerUsuarioAlquilerCentroEsparcimientos()
        {
            return UsuarioAlquilerCentroEsparcimientoDAO.ObtenerUsuarioAlquilerCentroEsparcimientos();
        }

        public string AgregarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO usuarioAlquilerCentroEsparcimientoDto)
        {
            return UsuarioAlquilerCentroEsparcimientoDAO.AgregarUsuarioAlquilerCentroEsparcimiento(usuarioAlquilerCentroEsparcimientoDto);
        }

        public UsuarioAlquilerCentroEsparcimientoDTO BuscarUsuarioAlquilerCentroEsparcimientoID(int Codigo)
        {
            return UsuarioAlquilerCentroEsparcimientoDAO.BuscarUsuarioAlquilerCentroEsparcimientoID(Codigo);
        }

        public string ActualizarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO usuarioAlquilerCentroEsparcimientoDto)
        {
            return UsuarioAlquilerCentroEsparcimientoDAO.ActualizarUsuarioAlquilerCentroEsparcimiento(usuarioAlquilerCentroEsparcimientoDto);
        }

        public string EliminarUsuarioAlquilerCentroEsparcimiento(UsuarioAlquilerCentroEsparcimientoDTO usuarioAlquilerCentroEsparcimientoDto)
        {
            return UsuarioAlquilerCentroEsparcimientoDAO.EliminarUsuarioAlquilerCentroEsparcimiento(usuarioAlquilerCentroEsparcimientoDto);
        }

    }
}
