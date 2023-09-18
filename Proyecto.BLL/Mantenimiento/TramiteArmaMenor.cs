using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TramiteArmaMenor
    {
        readonly TramiteArmaMenorDAO tramiteArmaMenorDAO = new();

        public List<TramiteArmaMenorDTO> ObtenerTramiteArmaMenors()
        {
            return tramiteArmaMenorDAO.ObtenerTramiteArmaMenors();
        }

        public string AgregarTramiteArmaMenor(TramiteArmaMenorDTO tramiteArmaMenorDto)
        {
            return tramiteArmaMenorDAO.AgregarTramiteArmaMenor(tramiteArmaMenorDto);
        }

        public TramiteArmaMenorDTO BuscarTramiteArmaMenorID(int Codigo)
        {
            return tramiteArmaMenorDAO.BuscarTramiteArmaMenorID(Codigo);
        }

        public string ActualizarTramiteArmaMenor(TramiteArmaMenorDTO tramiteArmaMenorDTO)
        {
            return tramiteArmaMenorDAO.ActualizarTramiteArmaMenor(tramiteArmaMenorDTO);
        }

        public bool EliminarTramiteArmaMenor(TramiteArmaMenorDTO tramiteArmaMenorDTO)
        {
            return tramiteArmaMenorDAO.EliminarTramiteArmaMenor(tramiteArmaMenorDTO);
        }

    }
}