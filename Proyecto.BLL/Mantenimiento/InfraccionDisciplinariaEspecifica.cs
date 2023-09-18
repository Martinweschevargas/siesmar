using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InfraccionDisciplinariaEspecifica
    {
        readonly InfraccionDisciplinariaEspecificaDAO infraccionDisciplinariaEspecificaDAO = new();

        public List<InfraccionDisciplinariaEspecificaDTO> ObtenerInfraccionDisciplinariaEspecificas()
        {
            return infraccionDisciplinariaEspecificaDAO.ObtenerInfraccionDisciplinariaEspecificas();
        }

        public string AgregarInfraccionDisciplinariaEspecifica(InfraccionDisciplinariaEspecificaDTO infraccionDisciplinariaEspecificaDto)
        {
            return infraccionDisciplinariaEspecificaDAO.AgregarInfraccionDisciplinariaEspecifica(infraccionDisciplinariaEspecificaDto);
        }

        public InfraccionDisciplinariaEspecificaDTO BuscarInfraccionDisciplinariaEspecificaID(int Codigo)
        {
            return infraccionDisciplinariaEspecificaDAO.BuscarInfraccionDisciplinariaEspecificaID(Codigo);
        }

        public string ActualizarInfraccionDisciplinariaEspecifica(InfraccionDisciplinariaEspecificaDTO infraccionDisciplinariaEspecificaDto)
        {
            return infraccionDisciplinariaEspecificaDAO.ActualizarInfraccionDisciplinariaEspecifica(infraccionDisciplinariaEspecificaDto);
        }

        public string EliminarInfraccionDisciplinariaEspecifica(InfraccionDisciplinariaEspecificaDTO infraccionDisciplinariaEspecificaDto)
        {
            return infraccionDisciplinariaEspecificaDAO.EliminarInfraccionDisciplinariaEspecifica(infraccionDisciplinariaEspecificaDto);
        }

    }
}
