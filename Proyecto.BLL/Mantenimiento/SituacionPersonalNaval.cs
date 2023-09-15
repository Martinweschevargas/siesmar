using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SituacionPersonalNaval
    {
        readonly SituacionPersonalNavalDAO situacionPersonalNavalDAO = new();

        public List<SituacionPersonalNavalDTO> ObtenerSituacionPersonalNavals()
        {
            return situacionPersonalNavalDAO.ObtenerSituacionPersonalNavals();
        }

        public string AgregarSituacionPersonalNaval(SituacionPersonalNavalDTO situacionPersonalNavalDto)
        {
            return situacionPersonalNavalDAO.AgregarSituacionPersonalNaval(situacionPersonalNavalDto);
        }

        public SituacionPersonalNavalDTO BuscarSituacionPersonalNavalID(int Codigo)

        {
            return situacionPersonalNavalDAO.BuscarSituacionPersonalNavalID(Codigo);
        }

        public string ActualizarSituacionPersonalNaval(SituacionPersonalNavalDTO situacionPersonalNavalDTO)
        {
            return situacionPersonalNavalDAO.ActualizarSituacionPersonalNaval(situacionPersonalNavalDTO);
        }

        public bool EliminarSituacionPersonalNaval(SituacionPersonalNavalDTO situacionPersonalNavalDTO)
        {
            return situacionPersonalNavalDAO.EliminarSituacionPersonalNaval(situacionPersonalNavalDTO);
        }

    }
}
