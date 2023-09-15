using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SistemaMunicion
    {
        readonly SistemaMunicionDAO sistemaMunicionDAO = new();

        public List<SistemaMunicionDTO> ObtenerSistemaMunicions()
        {
            return sistemaMunicionDAO.ObtenerSistemaMunicions();
        }

        public string AgregarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDto)
        {
            return sistemaMunicionDAO.AgregarSistemaMunicion(sistemaMunicionDto);
        }

        public SistemaMunicionDTO BuscarSistemaMunicionID(int Codigo)
        {
            return sistemaMunicionDAO.BuscarSistemaMunicionID(Codigo);
        }

        public string ActualizarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDto)
        {
            return sistemaMunicionDAO.ActualizarSistemaMunicion(sistemaMunicionDto);
        }

        public string EliminarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDto)
        {
            return sistemaMunicionDAO.EliminarSistemaMunicion(sistemaMunicionDto);
        }

    }
}
