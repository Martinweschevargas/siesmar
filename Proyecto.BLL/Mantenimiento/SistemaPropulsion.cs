using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SistemaPropulsion
    {
        readonly SistemaPropulsionDAO sistemaPropulsionDAO = new();

        public List<SistemaPropulsionDTO> ObtenerSistemaPropulsions()
        {
            return sistemaPropulsionDAO.ObtenerSistemaPropulsions();
        }

        public string AgregarSistemaPropulsion(SistemaPropulsionDTO sistemaPropulsionDto)
        {
            return sistemaPropulsionDAO.AgregarSistemaPropulsion(sistemaPropulsionDto);
        }

        public SistemaPropulsionDTO BuscarSistemaPropulsionID(int Codigo)
        {
            return sistemaPropulsionDAO.BuscarSistemaPropulsionID(Codigo);
        }

        public string ActualizarSistemaPropulsion(SistemaPropulsionDTO sistemaPropulsionDto)
        {
            return sistemaPropulsionDAO.ActualizarSistemaPropulsion(sistemaPropulsionDto);
        }

        public string EliminarSistemaPropulsion(SistemaPropulsionDTO sistemaPropulsionDto)
        {
            return sistemaPropulsionDAO.EliminarSistemaPropulsion(sistemaPropulsionDto);
        }

    }
}
