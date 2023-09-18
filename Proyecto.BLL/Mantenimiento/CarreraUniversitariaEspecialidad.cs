using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CarreraUniversitariaEspecialidad
    {
        readonly CarreraUniversitariaEspecialidadDAO carreraUniversitariaEspecialidadDAO = new();

        public List<CarreraUniversitariaEspecialidadDTO> ObtenerCarreraUniversitariaEspecialidads()
        {
            return carreraUniversitariaEspecialidadDAO.ObtenerCarreraUniversitariaEspecialidads();
        }

        public string AgregarCarreraUniversitariaEspecialidad(CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDto)
        {
            return carreraUniversitariaEspecialidadDAO.AgregarCarreraUniversitariaEspecialidad(carreraUniversitariaEspecialidadDto);
        }

        public CarreraUniversitariaEspecialidadDTO BuscarCarreraUniversitariaEspecialidadID(int Codigo)
        {
            return carreraUniversitariaEspecialidadDAO.BuscarCarreraUniversitariaEspecialidadID(Codigo);
        }

        public string ActualizarCarreraUniversitariaEspecialidad(CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO)
        {
            return carreraUniversitariaEspecialidadDAO.ActualizarCarreraUniversitariaEspecialidad(carreraUniversitariaEspecialidadDTO);
        }

        public string EliminarCarreraUniversitariaEspecialidad(CarreraUniversitariaEspecialidadDTO carreraUniversitariaEspecialidadDTO)
        {
            return carreraUniversitariaEspecialidadDAO.EliminarCarreraUniversitariaEspecialidad(carreraUniversitariaEspecialidadDTO);
        }

    }
}
