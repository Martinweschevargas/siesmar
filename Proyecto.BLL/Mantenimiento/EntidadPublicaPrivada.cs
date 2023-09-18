using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EntidadPublicaPrivada
    {
        readonly EntidadPublicaPrivadaDAO entidadPublicaPrivadaDAO = new();

        public List<EntidadPublicaPrivadaDTO> ObtenerEntidadPublicaPrivadas()
        {
            return entidadPublicaPrivadaDAO.ObtenerEntidadPublicaPrivadas();
        }

        public string AgregarEntidadPublicaPrivada(EntidadPublicaPrivadaDTO entidadPublicaPrivadaDto)
        {
            return entidadPublicaPrivadaDAO.AgregarEntidadPublicaPrivada(entidadPublicaPrivadaDto);
        }

        public EntidadPublicaPrivadaDTO BuscarEntidadPublicaPrivadaID(int Codigo)
        {
            return entidadPublicaPrivadaDAO.BuscarEntidadPublicaPrivadaID(Codigo);
        }

        public string ActualizarEntidadPublicaPrivada(EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO)
        {
            return entidadPublicaPrivadaDAO.ActualizarEntidadPublicaPrivada(entidadPublicaPrivadaDTO);
        }

        public bool EliminarEntidadPublicaPrivada(EntidadPublicaPrivadaDTO entidadPublicaPrivadaDTO)
        {
            return entidadPublicaPrivadaDAO.EliminarEntidadPublicaPrivada(entidadPublicaPrivadaDTO);
        }

    }
}
