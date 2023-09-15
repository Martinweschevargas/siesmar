using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EspecialidadGenerica
    {
        readonly EspecialidadGenericaDAO EspecialidadGenericaDAO = new();

        public List<EspecialidadGenericaDTO> ObtenerEspecialidadGenericas()
        {
            return EspecialidadGenericaDAO.ObtenerEspecialidadGenericas();
        }

        public string AgregarEspecialidadGenerica(EspecialidadGenericaDTO especialidadGenericaDto)
        {
            return EspecialidadGenericaDAO.AgregarEspecialidadGenerica(especialidadGenericaDto);
        }

        public EspecialidadGenericaDTO BuscarEspecialidadGenericaID(int Codigo)
        {
            return EspecialidadGenericaDAO.BuscarEspecialidadGenericaID(Codigo);
        }

        public string ActualizarEspecialidadGenerica(EspecialidadGenericaDTO especialidadGenericaDto)
        {
            return EspecialidadGenericaDAO.ActualizarEspecialidadGenerica(especialidadGenericaDto);
        }

        public string EliminarEspecialidadGenerica(EspecialidadGenericaDTO especialidadGenericaDto)
        {
            return EspecialidadGenericaDAO.EliminarEspecialidadGenerica(especialidadGenericaDto);
        }

    }
}
