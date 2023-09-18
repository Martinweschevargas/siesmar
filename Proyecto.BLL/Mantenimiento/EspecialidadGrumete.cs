using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecialidadGrumete
    {
        readonly EspecialidadGrumeteDAO especialidadGrumeteDAO = new();

        public List<EspecialidadGrumeteDTO> ObtenerEspecialidadGrumetes()
        {
            return especialidadGrumeteDAO.ObtenerEspecialidadGrumetes();
        }

        public string AgregarEspecialidadGrumete(EspecialidadGrumeteDTO especialidadGrumeteDto)
        {
            return especialidadGrumeteDAO.AgregarEspecialidadGrumete(especialidadGrumeteDto);
        }

        public EspecialidadGrumeteDTO BuscarEspecialidadGrumeteID(int Codigo)
        {
            return especialidadGrumeteDAO.BuscarEspecialidadGrumeteID(Codigo);
        }

        public string ActualizarEspecialidadGrumete(EspecialidadGrumeteDTO especialidadGrumeteDTO)
        {
            return especialidadGrumeteDAO.ActualizarEspecialidadGrumete(especialidadGrumeteDTO);
        }

        public string EliminarEspecialidadGrumete(EspecialidadGrumeteDTO especialidadGrumeteDTO)
        {
            return especialidadGrumeteDAO.EliminarEspecialidadGrumete(especialidadGrumeteDTO);
        }

    }
}
