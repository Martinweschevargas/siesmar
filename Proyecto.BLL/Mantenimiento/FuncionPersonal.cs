using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FuncionPersonal
    {
        readonly FuncionPersonalDAO funcionPersonalDAO = new();

        public List<FuncionPersonalDTO> ObtenerFuncionPersonals()
        {
            return funcionPersonalDAO.ObtenerFuncionPersonals();
        }

        public string AgregarFuncionPersonal(FuncionPersonalDTO funcionPersonalDto)
        {
            return funcionPersonalDAO.AgregarFuncionPersonal(funcionPersonalDto);
        }

        public FuncionPersonalDTO BuscarFuncionPersonalID(int Codigo)
        {
            return funcionPersonalDAO.BuscarFuncionPersonalID(Codigo);
        }

        public string ActualizarFuncionPersonal(FuncionPersonalDTO funcionPersonalDTO)
        {
            return funcionPersonalDAO.ActualizarFuncionPersonal(funcionPersonalDTO);
        }

        public bool EliminarFuncionPersonal(FuncionPersonalDTO funcionPersonalDTO)
        {
            return funcionPersonalDAO.EliminarFuncionPersonal(funcionPersonalDTO);
        }

    }
}
