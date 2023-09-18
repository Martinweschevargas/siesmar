using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FormacionAcademica
    {
        readonly FormacionAcademicaDAO formacionAcademicaDAO = new();

        public List<FormacionAcademicaDTO> ObtenerFormacionAcademicas()
        {
            return formacionAcademicaDAO.ObtenerFormacionAcademicas();
        }

        public string AgregarFormacionAcademica(FormacionAcademicaDTO formacionAcademicaDto)
        {
            return formacionAcademicaDAO.AgregarFormacionAcademica(formacionAcademicaDto);
        }

        public FormacionAcademicaDTO BuscarFormacionAcademicaID(int Codigo)
        {
            return formacionAcademicaDAO.BuscarFormacionAcademicaID(Codigo);
        }

        public string ActualizarFormacionAcademica(FormacionAcademicaDTO formacionAcademicaDTO)
        {
            return formacionAcademicaDAO.ActualizarFormacionAcademica(formacionAcademicaDTO);
        }

        public bool EliminarFormacionAcademica(FormacionAcademicaDTO formacionAcademicaDTO)
        {
            return formacionAcademicaDAO.EliminarFormacionAcademica(formacionAcademicaDTO);
        }

    }
}
