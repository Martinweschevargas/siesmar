using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MotivoServicio
    {
        readonly MotivoServicioDAO motivoServicioDAO = new();

        public List<MotivoServicioDTO> ObtenerMotivoServicios()
        {
            return motivoServicioDAO.ObtenerMotivoServicios();
        }

        public string AgregarMotivoServicio(MotivoServicioDTO motivoServicioDto)
        {
            return motivoServicioDAO.AgregarMotivoServicio(motivoServicioDto);
        }

        public MotivoServicioDTO BuscarMotivoServicioID(int Codigo)
        {
            return motivoServicioDAO.BuscarMotivoServicioID(Codigo);
        }

        public string ActualizarMotivoServicio(MotivoServicioDTO motivoServicioDTO)
        {
            return motivoServicioDAO.ActualizarMotivoServicio(motivoServicioDTO);
        }

        public bool EliminarMotivoServicio(int Codigo)
        {
            return motivoServicioDAO.EliminarMotivoServicio(Codigo);
        }

    }
}
