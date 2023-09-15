using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClaseFlota
    {
        readonly ClaseFlotaDAO claseFlotaDAO = new();

        public List<ClaseFlotaDTO> ObtenerClaseFlotas()
        {
            return claseFlotaDAO.ObtenerClaseFlotas();
        }

        public string AgregarClaseFlota(ClaseFlotaDTO claseFlotaDto)
        {
            return claseFlotaDAO.AgregarClaseFlota(claseFlotaDto);
        }

        public ClaseFlotaDTO BuscarClaseFlotaID(int Codigo)
        {
            return claseFlotaDAO.BuscarClaseFlotaID(Codigo);
        }

        public string ActualizarClaseFlota(ClaseFlotaDTO claseFlotaDto)
        {
            return claseFlotaDAO.ActualizarClaseFlota(claseFlotaDto);
        }

        public string EliminarClaseFlota(ClaseFlotaDTO claseFlotaDto)
        {
            return claseFlotaDAO.EliminarClaseFlota(claseFlotaDto);
        }

    }
}
