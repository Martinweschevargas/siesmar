using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SistemaPension
    {
        readonly SistemaPensionDAO sistemaPensionDAO = new();

        public List<SistemaPensionDTO> ObtenerSistemaPensions()
        {
            return sistemaPensionDAO.ObtenerSistemaPensions();
        }

        public string AgregarSistemaPension(SistemaPensionDTO sistemaPensionDto)
        {
            return sistemaPensionDAO.AgregarSistemaPension(sistemaPensionDto);
        }

        public SistemaPensionDTO BuscarSistemaPensionID(int Codigo)
        {
            return sistemaPensionDAO.BuscarSistemaPensionID(Codigo);
        }

        public string ActualizarSistemaPension(SistemaPensionDTO sistemaPensionDTO)
        {
            return sistemaPensionDAO.ActualizarSistemaPension(sistemaPensionDTO);
        }

        public string EliminarSistemaPension(SistemaPensionDTO sistemaPensionDTO)
        {
            return sistemaPensionDAO.EliminarSistemaPension(sistemaPensionDTO);
        }

    }
}
