using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEstudioContraInteligencia
    {
        readonly TipoEstudioContraInteligenciaDAO tipoEstudioContraInteligenciaDAO = new();

        public List<TipoEstudioContraInteligenciaDTO> ObtenerTipoEstudioContraInteligencias()
        {
            return tipoEstudioContraInteligenciaDAO.ObtenerTipoEstudioContraInteligencias();
        }

        public string AgregarTipoEstudioContraInteligencia(TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDto)
        {
            return tipoEstudioContraInteligenciaDAO.AgregarTipoEstudioContraInteligencia(tipoEstudioContraInteligenciaDto);
        }

        public TipoEstudioContraInteligenciaDTO BuscarTipoEstudioContraInteligenciaID(int Codigo)
        {
            return tipoEstudioContraInteligenciaDAO.BuscarTipoEstudioContraInteligenciaID(Codigo);
        }

        public string ActualizarTipoEstudioContraInteligencia(TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO)
        {
            return tipoEstudioContraInteligenciaDAO.ActualizarTipoEstudioContraInteligencia(tipoEstudioContraInteligenciaDTO);
        }

        public string EliminarTipoEstudioContraInteligencia(TipoEstudioContraInteligenciaDTO tipoEstudioContraInteligenciaDTO)
        {
            return tipoEstudioContraInteligenciaDAO.EliminarTipoEstudioContraInteligencia(tipoEstudioContraInteligenciaDTO);
        }

    }
}
