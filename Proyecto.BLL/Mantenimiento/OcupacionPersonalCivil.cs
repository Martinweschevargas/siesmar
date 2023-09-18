using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class OcupacionPersonalCivil
    {
        readonly OcupacionPersonalCivilDAO ocupacionPersonalCivilDAO = new();

        public List<OcupacionPersonalCivilDTO> ObtenerOcupacionPersonalCivils()
        {
            return ocupacionPersonalCivilDAO.ObtenerOcupacionPersonalCivils();
        }

        public string AgregarOcupacionPersonalCivil(OcupacionPersonalCivilDTO ocupacionPersonalCivilDto)
        {
            return ocupacionPersonalCivilDAO.AgregarOcupacionPersonalCivil(ocupacionPersonalCivilDto);
        }

        public OcupacionPersonalCivilDTO BuscarOcupacionPersonalCivilID(int Codigo)
        {
            return ocupacionPersonalCivilDAO.BuscarOcupacionPersonalCivilID(Codigo);
        }

        public string ActualizarOcupacionPersonalCivil(OcupacionPersonalCivilDTO ocupacionPersonalCivilDTO)
        {
            return ocupacionPersonalCivilDAO.ActualizarOcupacionPersonalCivil(ocupacionPersonalCivilDTO);
        }

        public bool EliminarOcupacionPersonalCivil(int Codigo)
        {
            return ocupacionPersonalCivilDAO.EliminarOcupacionPersonalCivil(Codigo);
        }

    }
}
