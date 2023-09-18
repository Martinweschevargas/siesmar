using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoCombustibleLubricante
    {
        readonly AlistamientoCombustibleLubricanteDAO alistamientoCombustibleLubricanteDAO = new();

        public List<AlistamientoCombustibleLubricanteDTO> ObtenerAlistamientoCombustibleLubricantes()
        {
            return alistamientoCombustibleLubricanteDAO.ObtenerAlistamientoCombustibleLubricantes();
        }

        public string AgregarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO alistamientoCombustibleLubricanteDto)
        {
            return alistamientoCombustibleLubricanteDAO.AgregarAlistamientoCombustibleLubricante(alistamientoCombustibleLubricanteDto);
        }

        public AlistamientoCombustibleLubricanteDTO BuscarAlistamientoCombustibleLubricanteID(int Codigo)
        {
            return alistamientoCombustibleLubricanteDAO.BuscarAlistamientoCombustibleLubricanteID(Codigo);
        }

        public string ActualizarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO alistamientoCombustibleLubricanteDto)
        {
            return alistamientoCombustibleLubricanteDAO.ActualizarAlistamientoCombustibleLubricante(alistamientoCombustibleLubricanteDto);
        }

        public string EliminarAlistamientoCombustibleLubricante(AlistamientoCombustibleLubricanteDTO alistamientoCombustibleLubricanteDto)
        {
            return alistamientoCombustibleLubricanteDAO.EliminarAlistamientoCombustibleLubricante(alistamientoCombustibleLubricanteDto);
        }

    }
}
