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

        public string AgregarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDTO)
        {
            return sistemaMunicionDAO.AgregarSistemaMunicion(sistemaMunicionDTO);
        }

        public SistemaMunicionDTO BuscarSistemaMunicionID(int Codigo)
        {
            return sistemaMunicionDAO.BuscarSistemaMunicionID(Codigo);
        }

        public string ActualizarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDTO)
        {
            return sistemaMunicionDAO.ActualizarSistemaMunicion(sistemaMunicionDTO);
        }

        public string EliminarSistemaMunicion(SistemaMunicionDTO sistemaMunicionDTO)
        {
            return sistemaMunicionDAO.EliminarSistemaMunicion(sistemaMunicionDTO);
        }

    }
}
