using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SubSistemaPropulsion
    {
        readonly SubSistemaPropulsionDAO subSistemaPropulsionDAO = new();

        public List<SubSistemaPropulsionDTO> ObtenerSubSistemaPropulsions()
        {
            return subSistemaPropulsionDAO.ObtenerSubSistemaPropulsions();
        }

        public string AgregarSubSistemaPropulsion(SubSistemaPropulsionDTO subSistemaPropulsionDto)
        {
            return subSistemaPropulsionDAO.AgregarSubSistemaPropulsion(subSistemaPropulsionDto);
        }

        public SubSistemaPropulsionDTO BuscarSubSistemaPropulsionID(int Codigo)
        {
            return subSistemaPropulsionDAO.BuscarSubSistemaPropulsionID(Codigo);
        }

        public string ActualizarSubSistemaPropulsion(SubSistemaPropulsionDTO subSistemaPropulsionDto)
        {
            return subSistemaPropulsionDAO.ActualizarSubSistemaPropulsion(subSistemaPropulsionDto);
        }

        public string EliminarSubSistemaPropulsion(SubSistemaPropulsionDTO subSistemaPropulsionDto)
        {
            return subSistemaPropulsionDAO.EliminarSubSistemaPropulsion(subSistemaPropulsionDto);
        }

    }
}
