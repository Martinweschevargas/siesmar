using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AmbitoNave
    {
        readonly AmbitoNaveDAO AmbitoNaveDAO = new();

        public List<AmbitoNaveDTO> ObtenerCapintanias()
        {
            return AmbitoNaveDAO.ObtenerAmbitoNaves();
        }

        public string AgregarAmbitoNave(AmbitoNaveDTO ambitoNaveDto)
        {
            return AmbitoNaveDAO.AgregarAmbitoNave(ambitoNaveDto);
        }

        public AmbitoNaveDTO BuscarAmbitoNaveID(int Codigo)
        {
            return AmbitoNaveDAO.BuscarAmbitoNaveID(Codigo);
        }

        public string ActualizarAmbitoNave(AmbitoNaveDTO ambitoNaveDto)
        {
            return AmbitoNaveDAO.ActualizarAmbitoNave(ambitoNaveDto);
        }

        public string EliminarAmbitoNave(AmbitoNaveDTO ambitoNaveDto)
        {
            return AmbitoNaveDAO.EliminarAmbitoNave(ambitoNaveDto);
        }

    }
}
