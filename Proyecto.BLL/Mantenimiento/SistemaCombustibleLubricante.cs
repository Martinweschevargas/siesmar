using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SistemaCombustibleLubricante
    {
        readonly SistemaCombustibleLubricanteDAO sistemaCombustibleLubricanteDAO = new();

        public List<SistemaCombustibleLubricanteDTO> ObtenerSistemaCombustibleLubricantes()
        {
            return sistemaCombustibleLubricanteDAO.ObtenerSistemaCombustibleLubricantes();
        }

        public string AgregarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO)
        {
            return sistemaCombustibleLubricanteDAO.AgregarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDTO);
        }

        public SistemaCombustibleLubricanteDTO BuscarSistemaCombustibleLubricanteID(int Codigo)
        {
            return sistemaCombustibleLubricanteDAO.BuscarSistemaCombustibleLubricanteID(Codigo);
        }

        public string ActualizarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO)
        {
            return sistemaCombustibleLubricanteDAO.ActualizarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDTO);
        }

        public string EliminarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDTO)
        {
            return sistemaCombustibleLubricanteDAO.EliminarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDTO);
        }

    }
}
