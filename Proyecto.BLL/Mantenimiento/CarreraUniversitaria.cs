using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;


namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CarreraUniversitaria
    {
        CarreraUniversitariaDAO carreraUniversitariaDAO = new CarreraUniversitariaDAO();

        public List<CarreraUniversitariaDTO> ObtenerCarreraUniversitarias()
        {
            return carreraUniversitariaDAO.ObtenerCarreraUniversitarias();
        }

        public string AgregarCarreraUniversitaria(CarreraUniversitariaDTO CarreraUniversitariaDto)
        {
            return carreraUniversitariaDAO.AgregarCarreraUniversitaria(CarreraUniversitariaDto);
        }

        public CarreraUniversitariaDTO EditarCarreraUniversitaria(int Codigo)
        {
            return carreraUniversitariaDAO.BuscarCarreraUniversitariaID(Codigo);
        }

        public string ActualizaCarreraUniversitaria(CarreraUniversitariaDTO CarreraUniversitariaDto)
        {
            return carreraUniversitariaDAO.ActualizarCarreraUniversitaria(CarreraUniversitariaDto);
        }

        public string EliminarCarreraUniversitaria(CarreraUniversitariaDTO CarreraUniversitariaDto)
        {
            return carreraUniversitariaDAO.EliminarCarreraUniversitaria(CarreraUniversitariaDto);
        }

    }
}
