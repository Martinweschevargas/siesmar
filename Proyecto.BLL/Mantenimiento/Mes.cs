using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Mes
    {
        readonly MesDAO mesDAO = new();

        public List<MesDTO> ObtenerMess()
        {
            return mesDAO.ObtenerMess();
        }

        public string AgregarMes(MesDTO mesDto)
        {
            return mesDAO.AgregarMes(mesDto);
        }

        public MesDTO BuscarMesID(int Codigo)
        {
            return mesDAO.BuscarMesID(Codigo);
        }

        public string ActualizarMes(MesDTO mesDTO)
        {
            return mesDAO.ActualizarMes(mesDTO);
        }

        public string EliminarMes(MesDTO mesDTO)
        {
            return mesDAO.EliminarMes(mesDTO);
        }

    }
}