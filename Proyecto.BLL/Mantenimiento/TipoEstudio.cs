using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEstudio
    {
        readonly TipoEstudioDAO tipoEstudioDAO = new();

        public List<TipoEstudioDTO> ObtenerTipoEstudios()
        {
            return tipoEstudioDAO.ObtenerTipoEstudios();
        }

        public string AgregarTipoEstudio(TipoEstudioDTO tipoEstudioDto)
        {
            return tipoEstudioDAO.AgregarTipoEstudio(tipoEstudioDto);
        }

        public TipoEstudioDTO BuscarTipoEstudioID(int Codigo)
        {
            return tipoEstudioDAO.BuscarTipoEstudioID(Codigo);
        }

        public string ActualizarTipoEstudio(TipoEstudioDTO tipoEstudioDto)
        {
            return tipoEstudioDAO.ActualizarTipoEstudio(tipoEstudioDto);
        }

        public string EliminarTipoEstudio(TipoEstudioDTO tipoEstudioDto)
        {
            return tipoEstudioDAO.EliminarTipoEstudio(tipoEstudioDto);
        }

    }
}
