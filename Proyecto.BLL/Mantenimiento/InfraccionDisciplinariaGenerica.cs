using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InfraccionDisciplinariaGenerica
    {
        readonly InfraccionDisciplinariaGenericaDAO infraccionDisciplinariaGenericaDAO = new();

        public List<InfraccionDisciplinariaGenericaDTO> ObtenerInfraccionDisciplinariaGenericas()
        {
            return infraccionDisciplinariaGenericaDAO.ObtenerInfraccionDisciplinariaGenericas();
        }

        public string AgregarInfraccionDisciplinariaGenerica(InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDto)
        {
            return infraccionDisciplinariaGenericaDAO.AgregarInfraccionDisciplinariaGenerica(infraccionDisciplinariaGenericaDto);
        }

        public InfraccionDisciplinariaGenericaDTO BuscarInfraccionDisciplinariaGenericaID(int Codigo)
        {
            return infraccionDisciplinariaGenericaDAO.BuscarInfraccionDisciplinariaGenericaID(Codigo);
        }

        public string ActualizarInfraccionDisciplinariaGenerica(InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDto)
        {
            return infraccionDisciplinariaGenericaDAO.ActualizarInfraccionDisciplinariaGenerica(infraccionDisciplinariaGenericaDto);
        }

        public string EliminarInfraccionDisciplinariaGenerica(InfraccionDisciplinariaGenericaDTO infraccionDisciplinariaGenericaDto)
        {
            return infraccionDisciplinariaGenericaDAO.EliminarInfraccionDisciplinariaGenerica(infraccionDisciplinariaGenericaDto);
        }

    }
}
