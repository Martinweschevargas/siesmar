using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionSancionDisciplinaria
    {
        readonly ClasificacionSancionDisciplinariaDAO clasificacionSancionDisciplinariaDAO = new();

        public List<ClasificacionSancionDisciplinariaDTO> ObtenerClasificacionSancionDisciplinarias()
        {
            return clasificacionSancionDisciplinariaDAO.ObtenerClasificacionSancionDisciplinarias();
        }

        public string AgregarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO clasificacionSancionDisciplinariaDto)
        {
            return clasificacionSancionDisciplinariaDAO.AgregarClasificacionSancionDisciplinaria(clasificacionSancionDisciplinariaDto);
        }

        public ClasificacionSancionDisciplinariaDTO BuscarClasificacionSancionDisciplinariaID(int Codigo)
        {
            return clasificacionSancionDisciplinariaDAO.BuscarClasificacionSancionDisciplinariaID(Codigo);
        }

        public string ActualizarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO clasificacionSancionDisciplinariaDto)
        {
            return clasificacionSancionDisciplinariaDAO.ActualizarClasificacionSancionDisciplinaria(clasificacionSancionDisciplinariaDto);
        }

        public string EliminarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO clasificacionSancionDisciplinariaDto)
        {
            return clasificacionSancionDisciplinariaDAO.EliminarClasificacionSancionDisciplinaria(clasificacionSancionDisciplinariaDto);
        }

    }
}
