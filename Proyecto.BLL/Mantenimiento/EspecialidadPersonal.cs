using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecialidadPersonal
    {
        readonly EspecialidadPersonalDAO especialidadPersonalDAO = new();

        public List<EspecialidadPersonalDTO> ObtenerEspecialidadPersonals()
        {
            return especialidadPersonalDAO.ObtenerEspecialidadPersonals();
        }

        public string AgregarEspecialidadPersonal(EspecialidadPersonalDTO especialidadPersonalDto)
        {
            return especialidadPersonalDAO.AgregarEspecialidadPersonal(especialidadPersonalDto);
        }

        public EspecialidadPersonalDTO BuscarEspecialidadPersonalID(int Codigo)
        {
            return especialidadPersonalDAO.BuscarEspecialidadPersonalID(Codigo);
        }

        public string ActualizarEspecialidadPersonal(EspecialidadPersonalDTO especialidadPersonalDTO)
        {
            return especialidadPersonalDAO.ActualizarEspecialidadPersonal(especialidadPersonalDTO);
        }

        public string EliminarEspecialidadPersonal(EspecialidadPersonalDTO especialidadPersonalDTO)
        {
            return especialidadPersonalDAO.EliminarEspecialidadPersonal(especialidadPersonalDTO);
        }

    }
}
