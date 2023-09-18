using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InstitucionEducativaSuperior
    {
        readonly InstitucionEducativaSuperiorDAO institucionEducativaSuperiorDAO = new();

        public List<InstitucionEducativaSuperiorDTO> ObtenerInstitucionEducativaSuperiors()
        {
            return institucionEducativaSuperiorDAO.ObtenerInstitucionEducativaSuperiors();
        }

        public string AgregarInstitucionEducativaSuperior(InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDto)
        {
            return institucionEducativaSuperiorDAO.AgregarInstitucionEducativaSuperior(institucionEducativaSuperiorDto);
        }

        public InstitucionEducativaSuperiorDTO BuscarInstitucionEducativaSuperiorID(int Codigo)
        {
            return institucionEducativaSuperiorDAO.BuscarInstitucionEducativaSuperiorID(Codigo);
        }

        public string ActualizarInstitucionEducativaSuperior(InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDto)
        {
            return institucionEducativaSuperiorDAO.ActualizarInstitucionEducativaSuperior(institucionEducativaSuperiorDto);
        }

        public string EliminarInstitucionEducativaSuperior(InstitucionEducativaSuperiorDTO institucionEducativaSuperiorDto)
        {
            return institucionEducativaSuperiorDAO.EliminarInstitucionEducativaSuperior(institucionEducativaSuperiorDto);
        }

    }
}
