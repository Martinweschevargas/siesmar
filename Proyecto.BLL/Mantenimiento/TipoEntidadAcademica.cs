using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEntidadAcademica
    {
        readonly TipoEntidadAcademicaDAO tipoEntidadAcademicaDAO = new();

        public List<TipoEntidadAcademicaDTO> ObtenerTipoEntidadAcademicas()
        {
            return tipoEntidadAcademicaDAO.ObtenerTipoEntidadAcademicas();
        }

        public string AgregarTipoEntidadAcademica(TipoEntidadAcademicaDTO tipoEntidadAcademicaDto)
        {
            return tipoEntidadAcademicaDAO.AgregarTipoEntidadAcademica(tipoEntidadAcademicaDto);
        }

        public TipoEntidadAcademicaDTO BuscarTipoEntidadAcademicaID(int Codigo)
        {
            return tipoEntidadAcademicaDAO.BuscarTipoEntidadAcademicaID(Codigo);
        }

        public string ActualizarTipoEntidadAcademica(TipoEntidadAcademicaDTO tipoEntidadAcademicaDto)
        {
            return tipoEntidadAcademicaDAO.ActualizarTipoEntidadAcademica(tipoEntidadAcademicaDto);
        }

        public string EliminarTipoEntidadAcademica(TipoEntidadAcademicaDTO tipoEntidadAcademicaDto)
        {
            return tipoEntidadAcademicaDAO.EliminarTipoEntidadAcademica(tipoEntidadAcademicaDto);
        }

    }
}
