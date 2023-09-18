using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UsuarioCentroEsparcimiento
    {
        readonly UsuarioCentroEsparcimientoDAO UsuarioCentroEsparcimientoDAO = new();

        public List<UsuarioCentroEsparcimientoDTO> ObtenerUsuarioCentroEsparcimientos()
        {
            return UsuarioCentroEsparcimientoDAO.ObtenerUsuarioCentroEsparcimientos();
        }

        public string AgregarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO usuarioCentroEsparcimientoDto)
        {
            return UsuarioCentroEsparcimientoDAO.AgregarUsuarioCentroEsparcimiento(usuarioCentroEsparcimientoDto);
        }

        public UsuarioCentroEsparcimientoDTO BuscarUsuarioCentroEsparcimientoID(int Codigo)
        {
            return UsuarioCentroEsparcimientoDAO.BuscarUsuarioCentroEsparcimientoID(Codigo);
        }

        public string ActualizarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO usuarioCentroEsparcimientoDto)
        {
            return UsuarioCentroEsparcimientoDAO.ActualizarUsuarioCentroEsparcimiento(usuarioCentroEsparcimientoDto);
        }

        public string EliminarUsuarioCentroEsparcimiento(UsuarioCentroEsparcimientoDTO usuarioCentroEsparcimientoDto)
        {
            return UsuarioCentroEsparcimientoDAO.EliminarUsuarioCentroEsparcimiento(usuarioCentroEsparcimientoDto);
        }

    }
}
