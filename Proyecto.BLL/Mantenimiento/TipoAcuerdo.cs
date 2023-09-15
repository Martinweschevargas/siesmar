using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAcuerdo
    {
        readonly TipoAcuerdoDAO tipoAcuerdoDAO = new();

        public List<TipoAcuerdoDTO> ObtenerTipoAcuerdos()
        {
            return tipoAcuerdoDAO.ObtenerTipoAcuerdos();
        }

        public string AgregarTipoAcuerdo(TipoAcuerdoDTO tipoAcuerdoDto)
        {
            return tipoAcuerdoDAO.AgregarTipoAcuerdo(tipoAcuerdoDto);
        }

        public TipoAcuerdoDTO BuscarTipoAcuerdoID(int Codigo)
        {
            return tipoAcuerdoDAO.BuscarTipoAcuerdoID(Codigo);
        }

        public string ActualizarTipoAcuerdo(TipoAcuerdoDTO tipoAcuerdoDto)
        {
            return tipoAcuerdoDAO.ActualizarTipoAcuerdo(tipoAcuerdoDto);
        }

        public string EliminarTipoAcuerdo(TipoAcuerdoDTO tipoAcuerdoDto)
        {
            return tipoAcuerdoDAO.EliminarTipoAcuerdo(tipoAcuerdoDto);
        }

    }
}
