using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MotivoViaje
    {
        readonly MotivoViajeDAO motivoViajeDAO = new();

        public List<MotivoViajeDTO> ObtenerMotivoViajes()
        {
            return motivoViajeDAO.ObtenerMotivoViajes();
        }

        public string AgregarMotivoViaje(MotivoViajeDTO motivoViajeDto)
        {
            return motivoViajeDAO.AgregarMotivoViaje(motivoViajeDto);
        }

        public MotivoViajeDTO BuscarMotivoViajeID(int Codigo)
        {
            return motivoViajeDAO.BuscarMotivoViajeID(Codigo);
        }

        public string ActualizarMotivoViaje(MotivoViajeDTO motivoViajeDTO)
        {
            return motivoViajeDAO.ActualizarMotivoViaje(motivoViajeDTO);
        }

        public bool EliminarMotivoViaje(int Codigo)
        {
            return motivoViajeDAO.EliminarMotivoViaje(Codigo);
        }

    }
}
