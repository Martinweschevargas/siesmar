using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoContraInteligencia
    {
        readonly TipoContraInteligenciaDAO tipoContraInteligenciaDAO = new();

        public List<TipoContraInteligenciaDTO> ObtenerTipoContraInteligencias()
        {
            return tipoContraInteligenciaDAO.ObtenerTipoContraInteligencias();
        }

        public string AgregarTipoContraInteligencia(TipoContraInteligenciaDTO tipoContraInteligenciaDto)
        {
            return tipoContraInteligenciaDAO.AgregarTipoContraInteligencia(tipoContraInteligenciaDto);
        }

        public TipoContraInteligenciaDTO BuscarTipoContraInteligenciaID(int Codigo)
        {
            return tipoContraInteligenciaDAO.BuscarTipoContraInteligenciaID(Codigo);
        }

        public string ActualizarTipoContraInteligencia(TipoContraInteligenciaDTO tipoContraInteligenciaDTO)
        {
            return tipoContraInteligenciaDAO.ActualizarTipoContraInteligencia(tipoContraInteligenciaDTO);
        }

        public string EliminarTipoContraInteligencia(TipoContraInteligenciaDTO tipoContraInteligenciaDTO)
        {
            return tipoContraInteligenciaDAO.EliminarTipoContraInteligencia(tipoContraInteligenciaDTO);
        }

    }
}
