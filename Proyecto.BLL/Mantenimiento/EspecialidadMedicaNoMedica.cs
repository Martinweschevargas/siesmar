using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecialidadMedicaNoMedica
    {
        readonly EspecialidadMedicaNoMedicaDAO especialidadMedicaNoMedicaDAO = new();

        public List<EspecialidadMedicaNoMedicaDTO> ObtenerEspecialidadMedicaNoMedicas()
        {
            return especialidadMedicaNoMedicaDAO.ObtenerEspecialidadMedicaNoMedicas();
        }

        public string AgregarEspecialidadMedicaNoMedica(EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDto)
        {
            return especialidadMedicaNoMedicaDAO.AgregarEspecialidadMedicaNoMedica(especialidadMedicaNoMedicaDto);
        }

        public EspecialidadMedicaNoMedicaDTO BuscarEspecialidadMedicaNoMedicaID(int Codigo)
        {
            return especialidadMedicaNoMedicaDAO.BuscarEspecialidadMedicaNoMedicaID(Codigo);
        }

        public string ActualizarEspecialidadMedicaNoMedica(EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDto)
        {
            return especialidadMedicaNoMedicaDAO.ActualizarEspecialidadMedicaNoMedica(especialidadMedicaNoMedicaDto);
        }

        public string EliminarEspecialidadMedicaNoMedica(EspecialidadMedicaNoMedicaDTO especialidadMedicaNoMedicaDto)
        {
            return especialidadMedicaNoMedicaDAO.EliminarEspecialidadMedicaNoMedica(especialidadMedicaNoMedicaDto);
        }

    }
}
