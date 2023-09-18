using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DptoRiberaZocaloContinental
    {
        readonly DptoRiberaZocaloContinentalDAO dptoRiberaZocaloContinentalDAO = new();

        public List<DptoRiberaZocaloContinentalDTO> ObtenerDptoRiberaZocaloContinentals()
        {
            return dptoRiberaZocaloContinentalDAO.ObtenerDptoRiberaZocaloContinentals();
        }

        public string AgregarDptoRiberaZocaloContinental(DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDto)
        {
            return dptoRiberaZocaloContinentalDAO.AgregarDptoRiberaZocaloContinental(dptoRiberaZocaloContinentalDto);
        }

        public DptoRiberaZocaloContinentalDTO BuscarDptoRiberaZocaloContinentalID(int Codigo)
        {
            return dptoRiberaZocaloContinentalDAO.BuscarDptoRiberaZocaloContinentalID(Codigo);
        }

        public string ActualizarDptoRiberaZocaloContinental(DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO)
        {
            return dptoRiberaZocaloContinentalDAO.ActualizarDptoRiberaZocaloContinental(dptoRiberaZocaloContinentalDTO);
        }

        public bool EliminarDptoRiberaZocaloContinental(DptoRiberaZocaloContinentalDTO dptoRiberaZocaloContinentalDTO)
        {
            return dptoRiberaZocaloContinentalDAO.EliminarDptoRiberaZocaloContinental(dptoRiberaZocaloContinentalDTO);
        }

    }
}
