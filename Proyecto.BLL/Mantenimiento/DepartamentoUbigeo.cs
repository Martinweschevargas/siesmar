using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DepartamentoUbigeo
    {
        readonly DepartamentoUbigeoDAO departamentoUbigeoDAO = new();

        public List<DepartamentoUbigeoDTO> ObtenerDepartamentoUbigeos()
        {
            return departamentoUbigeoDAO.ObtenerDepartamentoUbigeos();
        }

        public string AgregarDepartamentoUbigeo(DepartamentoUbigeoDTO departamentoUbigeoDto)
        {
            return departamentoUbigeoDAO.AgregarDepartamentoUbigeo(departamentoUbigeoDto);
        }

        public DepartamentoUbigeoDTO BuscarDepartamentoUbigeoID(int Codigo)
        {
            return departamentoUbigeoDAO.BuscarDepartamentoUbigeoID(Codigo);
        }

        public string ActualizarDepartamentoUbigeo(DepartamentoUbigeoDTO departamentoUbigeoDTO)
        {
            return departamentoUbigeoDAO.ActualizarDepartamentoUbigeo(departamentoUbigeoDTO);
        }

        public bool EliminarDepartamentoUbigeo(DepartamentoUbigeoDTO departamentoUbigeoDTO)
        {
            return departamentoUbigeoDAO.EliminarDepartamentoUbigeo(departamentoUbigeoDTO);
        }

    }
}