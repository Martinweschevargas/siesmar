using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SituacionOperatividadNave
    {
        readonly SituacionOperatividadNaveDAO situacionOperatividadNaveDAO = new();

        public List<SituacionOperatividadNaveDTO> ObtenerSituacionOperatividadNaves()
        {
            return situacionOperatividadNaveDAO.ObtenerSituacionOperatividadNaves();
        }

        public string AgregarSituacionOperatividadNave(SituacionOperatividadNaveDTO situacionOperatividadNaveDto)
        {
            return situacionOperatividadNaveDAO.AgregarSituacionOperatividadNave(situacionOperatividadNaveDto);
        }

        public SituacionOperatividadNaveDTO BuscarSituacionOperatividadNaveID(int Codigo)
        {
            return situacionOperatividadNaveDAO.BuscarSituacionOperatividadNaveID(Codigo);
        }

        public string ActualizarSituacionOperatividadNave(SituacionOperatividadNaveDTO situacionOperatividadNaveDto)
        {
            return situacionOperatividadNaveDAO.ActualizarSituacionOperatividadNave(situacionOperatividadNaveDto);
        }

        public string EliminarSituacionOperatividadNave(SituacionOperatividadNaveDTO situacionOperatividadNaveDto)
        {
            return situacionOperatividadNaveDAO.EliminarSituacionOperatividadNave(situacionOperatividadNaveDto);
        }

    }
}
