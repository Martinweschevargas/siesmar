using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SituacionLegal
    {
        readonly SituacionLegalDAO situacionLegalDAO = new();

        public List<SituacionLegalDTO> ObtenerSituacionLegals()
        {
            return situacionLegalDAO.ObtenerSituacionLegals();
        }

        public string AgregarSituacionLegal(SituacionLegalDTO situacionLegalDto)
        {
            return situacionLegalDAO.AgregarSituacionLegal(situacionLegalDto);
        }

        public SituacionLegalDTO BuscarSituacionLegalID(int Codigo)
        {
            return situacionLegalDAO.BuscarSituacionLegalID(Codigo);
        }

        public string ActualizarSituacionLegal(SituacionLegalDTO situacionLegalDTO)
        {
            return situacionLegalDAO.ActualizarSituacionLegal(situacionLegalDTO);
        }

        public bool EliminarSituacionLegal(SituacionLegalDTO situacionLegalDTO)
        {
            return situacionLegalDAO.EliminarSituacionLegal(situacionLegalDTO);
        }

    }
}
