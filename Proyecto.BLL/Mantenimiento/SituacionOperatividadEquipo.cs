using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SituacionOperatividadEquipo
    {
        readonly SituacionOperatividadEquipoDAO situacionOperatividadEquipoDAO = new();

        public List<SituacionOperatividadEquipoDTO> ObtenerSituacionOperatividadEquipos()
        {
            return situacionOperatividadEquipoDAO.ObtenerSituacionOperatividadEquipos();
        }

        public string AgregarSituacionOperatividadEquipo(SituacionOperatividadEquipoDTO situacionOperatividadEquipoDto)
        {
            return situacionOperatividadEquipoDAO.AgregarSituacionOperatividadEquipo(situacionOperatividadEquipoDto);
        }

        public SituacionOperatividadEquipoDTO BuscarSituacionOperatividadEquipoID(int Codigo)
        {
            return situacionOperatividadEquipoDAO.BuscarSituacionOperatividadEquipoID(Codigo);
        }

        public string ActualizarSituacionOperatividadEquipo(SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO)
        {
            return situacionOperatividadEquipoDAO.ActualizarSituacionOperatividadEquipo(situacionOperatividadEquipoDTO);
        }

        public bool EliminarSituacionOperatividadEquipo(SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO)
        {
            return situacionOperatividadEquipoDAO.EliminarSituacionOperatividadEquipo(situacionOperatividadEquipoDTO);
        }

    }
}
