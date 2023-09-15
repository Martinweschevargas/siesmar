using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MuseoNaval
    {
        readonly MuseoNavalDAO museoNavalDAO = new();

        public List<MuseoNavalDTO> ObtenerMuseoNavals()
        {
            return museoNavalDAO.ObtenerMuseoNavals();
        }

        public string AgregarMuseoNaval(MuseoNavalDTO museoNavalDto)
        {
            return museoNavalDAO.AgregarMuseoNaval(museoNavalDto);
        }

        public MuseoNavalDTO BuscarMuseoNavalID(int Codigo)
        {
            return museoNavalDAO.BuscarMuseoNavalID(Codigo);
        }

        public string ActualizarMuseoNaval(MuseoNavalDTO museoNavalDTO)
        {
            return museoNavalDAO.ActualizarMuseoNaval(museoNavalDTO);
        }

        public bool EliminarMuseoNaval(MuseoNavalDTO museoNavalDTO)
        {
            return museoNavalDAO.EliminarMuseoNaval(museoNavalDTO);
        }

    }
}