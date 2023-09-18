using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClaseCombustible
    {
        readonly ClaseCombustibleDAO claseCombustibleDAO = new();

        public List<ClaseCombustibleDTO> ObtenerClaseCombustibles()
        {
            return claseCombustibleDAO.ObtenerClaseCombustibles();
        }

        public string AgregarClaseCombustible(ClaseCombustibleDTO claseCombustibleDto)
        {
            return claseCombustibleDAO.AgregarClaseCombustible(claseCombustibleDto);
        }

        public ClaseCombustibleDTO BuscarClaseCombustibleID(int Codigo)
        {
            return claseCombustibleDAO.BuscarClaseCombustibleID(Codigo);
        }

        public string ActualizarClaseCombustible(ClaseCombustibleDTO claseCombustibleDto)
        {
            return claseCombustibleDAO.ActualizarClaseCombustible(claseCombustibleDto);
        }

        public string EliminarClaseCombustible(ClaseCombustibleDTO claseCombustibleDto)
        {
            return claseCombustibleDAO.EliminarClaseCombustible(claseCombustibleDto);
        }

    }
}
