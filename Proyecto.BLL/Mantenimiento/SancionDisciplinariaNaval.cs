using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SancionDisciplinariaNaval
    {
        readonly SancionDisciplinariaNavalDAO sancionDisciplinariaNavalDAO = new();

        public List<SancionDisciplinariaNavalDTO> ObtenerSancionDisciplinariaNavals()
        {
            return sancionDisciplinariaNavalDAO.ObtenerSancionDisciplinariaNavals();
        }

        public string AgregarSancionDisciplinariaNaval(SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDto)
        {
            return sancionDisciplinariaNavalDAO.AgregarSancionDisciplinariaNaval(sancionDisciplinariaNavalDto);
        }

        public SancionDisciplinariaNavalDTO BuscarSancionDisciplinariaNavalID(int Codigo)
        {
            return sancionDisciplinariaNavalDAO.BuscarSancionDisciplinariaNavalID(Codigo);
        }

        public string ActualizarSancionDisciplinariaNaval(SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO)
        {
            return sancionDisciplinariaNavalDAO.ActualizarSancionDisciplinariaNaval(sancionDisciplinariaNavalDTO);
        }

        public bool EliminarSancionDisciplinariaNaval(SancionDisciplinariaNavalDTO sancionDisciplinariaNavalDTO)
        {
            return sancionDisciplinariaNavalDAO.EliminarSancionDisciplinariaNaval(sancionDisciplinariaNavalDTO);
        }

    }
}
