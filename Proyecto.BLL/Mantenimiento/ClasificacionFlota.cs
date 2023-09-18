using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionFlota
    {
        readonly ClasificacionFlotaDAO clasificacionFlotaDAO = new();

        public List<ClasificacionFlotaDTO> ObtenerClasificacionFlotas()
        {
            return clasificacionFlotaDAO.ObtenerClasificacionFlotas();
        }

        public string AgregarClasificacionFlota(ClasificacionFlotaDTO clasificacionFlotaDto)
        {
            return clasificacionFlotaDAO.AgregarClasificacionFlota(clasificacionFlotaDto);
        }

        public ClasificacionFlotaDTO BuscarClasificacionFlotaID(int Codigo)
        {
            return clasificacionFlotaDAO.BuscarClasificacionFlotaID(Codigo);
        }

        public string ActualizarClasificacionFlota(ClasificacionFlotaDTO clasificacionFlotaDto)
        {
            return clasificacionFlotaDAO.ActualizarClasificacionFlota(clasificacionFlotaDto);
        }

        public string EliminarClasificacionFlota(ClasificacionFlotaDTO clasificacionFlotaDto)
        {
            return clasificacionFlotaDAO.EliminarClasificacionFlota(clasificacionFlotaDto);
        }

    }
}
