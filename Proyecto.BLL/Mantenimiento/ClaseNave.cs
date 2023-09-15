using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClaseNave
    {
        readonly ClaseNaveDAO claseNaveDAO = new();

        public List<ClaseNaveDTO> ObtenerClaseNaves()
        {
            return claseNaveDAO.ObtenerClaseNaves();
        }

        public string AgregarClaseNave(ClaseNaveDTO claseNaveDto)
        {
            return claseNaveDAO.AgregarClaseNave(claseNaveDto);
        }

        public ClaseNaveDTO BuscarClaseNaveID(int Codigo)
        {
            return claseNaveDAO.BuscarClaseNaveID(Codigo);
        }

        public string ActualizarClaseNave(ClaseNaveDTO claseNaveDto)
        {
            return claseNaveDAO.ActualizarClaseNave(claseNaveDto);
        }

        public string EliminarClaseNave(ClaseNaveDTO claseNaveDto)
        {
            return claseNaveDAO.EliminarClaseNave(claseNaveDto);
        }

    }
}
