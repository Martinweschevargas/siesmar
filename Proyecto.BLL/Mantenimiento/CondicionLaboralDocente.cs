using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionLaboralDocente
    {
        readonly CondicionLaboralDocenteDAO condicionLaboralDocenteDAO = new();

        public List<CondicionLaboralDocenteDTO> ObtenerCondicionLaboralDocentes()
        {
            return condicionLaboralDocenteDAO.ObtenerCondicionLaboralDocentes();
        }

        public string AgregarCondicionLaboralDocente(CondicionLaboralDocenteDTO condicionLaboralDocenteDto)
        {
            return condicionLaboralDocenteDAO.AgregarCondicionLaboralDocente(condicionLaboralDocenteDto);
        }

        public CondicionLaboralDocenteDTO BuscarCondicionLaboralDocenteID(int Codigo)
        {
            return condicionLaboralDocenteDAO.BuscarCondicionLaboralDocenteID(Codigo);
        }

        public string ActualizarCondicionLaboralDocente(CondicionLaboralDocenteDTO condicionLaboralDocenteDto)
        {
            return condicionLaboralDocenteDAO.ActualizarCondicionLaboralDocente(condicionLaboralDocenteDto);
        }

        public string EliminarCondicionLaboralDocente(CondicionLaboralDocenteDTO condicionLaboralDocenteDto)
        {
            return condicionLaboralDocenteDAO.EliminarCondicionLaboralDocente(condicionLaboralDocenteDto);
        }

    }
}
