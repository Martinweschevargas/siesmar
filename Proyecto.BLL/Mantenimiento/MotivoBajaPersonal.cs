using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MotivoBajaPersonal
    {
        readonly MotivoBajaPersonalDAO motivoBajaPersonalDAO = new();

        public List<MotivoBajaPersonalDTO> ObtenerMotivoBajaPersonals()
        {
            return motivoBajaPersonalDAO.ObtenerMotivoBajaPersonals();
        }

        public string AgregarMotivoBajaPersonal(MotivoBajaPersonalDTO motivoBajaPersonalDto)
        {
            return motivoBajaPersonalDAO.AgregarMotivoBajaPersonal(motivoBajaPersonalDto);
        }

        public MotivoBajaPersonalDTO BuscarMotivoBajaPersonalID(int Codigo)
        {
            return motivoBajaPersonalDAO.BuscarMotivoBajaPersonalID(Codigo);
        }

        public string ActualizarMotivoBajaPersonal(MotivoBajaPersonalDTO motivoBajaPersonalDTO)
        {
            return motivoBajaPersonalDAO.ActualizarMotivoBajaPersonal(motivoBajaPersonalDTO);
        }

        public string EliminarMotivoBajaPersonal(MotivoBajaPersonalDTO motivoBajaPersonalDTO)
        {
            return motivoBajaPersonalDAO.EliminarMotivoBajaPersonal(motivoBajaPersonalDTO);
        }

    }
}
