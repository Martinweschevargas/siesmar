using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecialidadGenericaPersonal
    {
        readonly EspecialidadGenericaPersonalDAO especialidadGenericaPersonalDAO = new();

        public List<EspecialidadGenericaPersonalDTO> ObtenerEspecialidadGenericaPersonals()
        {
            return especialidadGenericaPersonalDAO.ObtenerEspecialidadGenericaPersonals();
        }

        public string AgregarEspecialidadGenericaPersonal(EspecialidadGenericaPersonalDTO especialidadGenericaPersonalDto)
        {
            return especialidadGenericaPersonalDAO.AgregarEspecialidadGenericaPersonal(especialidadGenericaPersonalDto);
        }

        public EspecialidadGenericaPersonalDTO BuscarEspecialidadGenericaPersonalID(int Codigo)
        {
            return especialidadGenericaPersonalDAO.BuscarEspecialidadGenericaPersonalID(Codigo);
        }

        public string ActualizarEspecialidadGenericaPersonal(EspecialidadGenericaPersonalDTO especialidadGenericaPersonalDTO)
        {
            return especialidadGenericaPersonalDAO.ActualizarEspecialidadGenericaPersonal(especialidadGenericaPersonalDTO);
        }

        public string EliminarEspecialidadGenericaPersonal(EspecialidadGenericaPersonalDTO especialidadGenericaPersonalDTO)
        {
            return especialidadGenericaPersonalDAO.EliminarEspecialidadGenericaPersonal(especialidadGenericaPersonalDTO);
        }

    }
}