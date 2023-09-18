using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InstitucionEducativa
    {
        readonly InstitucionEducativaDAO institucionEducativaDAO = new();

        public List<InstitucionEducativaDTO> ObtenerInstitucionEducativas()
        {
            return institucionEducativaDAO.ObtenerInstitucionEducativas();
        }

        public string AgregarInstitucionEducativa(InstitucionEducativaDTO institucionEducativaDto)
        {
            return institucionEducativaDAO.AgregarInstitucionEducativa(institucionEducativaDto);
        }

        public InstitucionEducativaDTO BuscarInstitucionEducativaID(int Codigo)
        {
            return institucionEducativaDAO.BuscarInstitucionEducativaID(Codigo);
        }

        public string ActualizarInstitucionEducativa(InstitucionEducativaDTO institucionEducativaDto)
        {
            return institucionEducativaDAO.ActualizarInstitucionEducativa(institucionEducativaDto);
        }

        public string EliminarInstitucionEducativa(InstitucionEducativaDTO institucionEducativaDto)
        {
            return institucionEducativaDAO.EliminarInstitucionEducativa(institucionEducativaDto);
        }

    }
}
