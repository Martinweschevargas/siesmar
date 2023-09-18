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

        public string AgregarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDto)
        {
            return sistemaCombustibleLubricanteDAO.AgregarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDto);
        }

        public SistemaCombustibleLubricanteDTO BuscarSistemaCombustibleLubricanteID(int Codigo)
        {
            return sistemaCombustibleLubricanteDAO.BuscarSistemaCombustibleLubricanteID(Codigo);
        }

        public string ActualizarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDto)
        {
            return sistemaCombustibleLubricanteDAO.ActualizarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDto);
        }

        public string EliminarSistemaCombustibleLubricante(SistemaCombustibleLubricanteDTO sistemaCombustibleLubricanteDto)
        {
            return sistemaCombustibleLubricanteDAO.EliminarSistemaCombustibleLubricante(sistemaCombustibleLubricanteDto);
        }

    }
}
