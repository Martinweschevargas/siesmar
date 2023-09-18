using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class NivelAlistamiento
    {
        readonly NivelAlistamientoDAO nivelAlistamientoDAO = new();

        public List<NivelAlistamientoDTO> ObtenerNivelAlistamientos()
        {
            return nivelAlistamientoDAO.ObtenerNivelAlistamientos();
        }

        public string AgregarNivelAlistamiento(NivelAlistamientoDTO nivelAlistamientoDto)
        {
            return nivelAlistamientoDAO.AgregarNivelAlistamiento(nivelAlistamientoDto);
        }

        public NivelAlistamientoDTO BuscarNivelAlistamientoID(int Codigo)
        {
            return nivelAlistamientoDAO.BuscarNivelAlistamientoID(Codigo);
        }

        public string ActualizarNivelAlistamiento(NivelAlistamientoDTO nivelAlistamientoDTO)
        {
            return nivelAlistamientoDAO.ActualizarNivelAlistamiento(nivelAlistamientoDTO);
        }

        public bool EliminarNivelAlistamiento(int Codigo)
        {
            return nivelAlistamientoDAO.EliminarNivelAlistamiento(Codigo);
        }

    }
}
