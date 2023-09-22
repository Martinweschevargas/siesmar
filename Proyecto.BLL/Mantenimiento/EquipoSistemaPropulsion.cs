using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EquipoSistemaPropulsion
    {
        readonly EquipoSistemaPropulsionDAO equipoSistemaPropulsionDAO = new();

        public List<EquipoSistemaPropulsionDTO> ObtenerEquipoSistemaPropulsions()
        {
            return equipoSistemaPropulsionDAO.ObtenerEquipoSistemaPropulsions();
        }

        public string AgregarEquipoSistemaPropulsion(EquipoSistemaPropulsionDTO equipoSistemaPropulsionDto)
        {
            return equipoSistemaPropulsionDAO.AgregarEquipoSistemaPropulsion(equipoSistemaPropulsionDto);
        }

        public EquipoSistemaPropulsionDTO EditarMantenimiento(int Codigo)
        {
            return equipoSistemaPropulsionDAO.BuscarEquipoSistemaPropulsionID(Codigo);
        }

        public string ActualizarEquipoSistemaPropulsion(EquipoSistemaPropulsionDTO equipoSistemaPropulsionDto)
        {
            return equipoSistemaPropulsionDAO.ActualizaEquipoSistemaPropulsion(equipoSistemaPropulsionDto);
        }

        public string EliminarEquipoSistemaPropulsion(EquipoSistemaPropulsionDTO equipoSistemaPropulsionDto)
        {
            return equipoSistemaPropulsionDAO.EliminarEquipoSistemaPropulsion(equipoSistemaPropulsionDto);
        }

    }
}
