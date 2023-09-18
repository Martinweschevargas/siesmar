using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class NivelEstudio
    {
        readonly NivelEstudioDAO nivelEstudioDAO = new();

        public List<NivelEstudioDTO> ObtenerNivelEstudios()
        {
            return nivelEstudioDAO.ObtenerNivelEstudios();
        }

        public string AgregarNivelEstudio(NivelEstudioDTO nivelEstudioDto)
        {
            return nivelEstudioDAO.AgregarNivelEstudio(nivelEstudioDto);
        }

        public NivelEstudioDTO BuscarNivelEstudioID(int Codigo)
        {
            return nivelEstudioDAO.BuscarNivelEstudioID(Codigo);
        }

        public string ActualizarNivelEstudio(NivelEstudioDTO nivelEstudioDto)
        {
            return nivelEstudioDAO.ActualizarNivelEstudio(nivelEstudioDto);
        }

        public string EliminarNivelEstudio(NivelEstudioDTO nivelEstudioDto)
        {
            return nivelEstudioDAO.EliminarNivelEstudio(nivelEstudioDto);
        }

    }
}
