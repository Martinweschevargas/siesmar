using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecificacionNave
    {
        readonly EspecificacionNaveDAO especificacionNaveDAO = new();

        public List<EspecificacionNaveDTO> ObtenerEspecificacionNaves()
        {
            return especificacionNaveDAO.ObtenerEspecificacionNaves();
        }

        public string AgregarEspecificacionNave(EspecificacionNaveDTO especificacionNaveDto)
        {
            return especificacionNaveDAO.AgregarEspecificacionNave(especificacionNaveDto);
        }

        public EspecificacionNaveDTO BuscarEspecificacionNaveID(int Codigo)
        {
            return especificacionNaveDAO.BuscarEspecificacionNaveID(Codigo);
        }

        public string ActualizarEspecificacionNave(EspecificacionNaveDTO especificacionNaveDto)
        {
            return especificacionNaveDAO.ActualizarEspecificacionNave(especificacionNaveDto);
        }

        public string EliminarEspecificacionNave(EspecificacionNaveDTO especificacionNaveDto)
        {
            return especificacionNaveDAO.EliminarEspecificacionNave(especificacionNaveDto);
        }

    }
}
