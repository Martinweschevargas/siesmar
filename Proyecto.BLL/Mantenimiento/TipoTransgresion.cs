using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoTransgresion
    {
        readonly TipoTransgresionDAO tipoTransgresionDAO = new();

        public List<TipoTransgresionDTO> ObtenerTipoTransgresions()
        {
            return tipoTransgresionDAO.ObtenerTipoTransgresions();
        }

        public string AgregarTipoTransgresion(TipoTransgresionDTO tipoTransgresionDto)
        {
            return tipoTransgresionDAO.AgregarTipoTransgresion(tipoTransgresionDto);
        }

        public TipoTransgresionDTO BuscarTipoTransgresionID(int Codigo)
        {
            return tipoTransgresionDAO.BuscarTipoTransgresionID(Codigo);
        }

        public string ActualizarTipoTransgresion(TipoTransgresionDTO tipoTransgresionDTO)
        {
            return tipoTransgresionDAO.ActualizarTipoTransgresion(tipoTransgresionDTO);
        }

        public string EliminarTipoTransgresion(TipoTransgresionDTO tipoTransgresionDTO)
        {
            return tipoTransgresionDAO.EliminarTipoTransgresion(tipoTransgresionDTO);
        }

    }
}
