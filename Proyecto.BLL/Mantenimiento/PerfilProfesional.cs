using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PerfilProfesional
    {
        readonly PerfilProfesionalDAO perfilProfesionalDAO = new();

        public List<PerfilProfesionalDTO> ObtenerPerfilProfesionals()
        {
            return perfilProfesionalDAO.ObtenerPerfilProfesionals();
        }

        public string AgregarPerfilProfesional(PerfilProfesionalDTO perfilProfesionalDto)
        {
            return perfilProfesionalDAO.AgregarPerfilProfesional(perfilProfesionalDto);
        }

        public PerfilProfesionalDTO BuscarPerfilProfesionalID(int Codigo)
        {
            return perfilProfesionalDAO.BuscarPerfilProfesionalID(Codigo);
        }

        public string ActualizarPerfilProfesional(PerfilProfesionalDTO perfilProfesionalDTO)
        {
            return perfilProfesionalDAO.ActualizarPerfilProfesional(perfilProfesionalDTO);
        }

        public bool EliminarPerfilProfesional(int Codigo)
        {
            return perfilProfesionalDAO.EliminarPerfilProfesional(Codigo);
        }

    }
}
