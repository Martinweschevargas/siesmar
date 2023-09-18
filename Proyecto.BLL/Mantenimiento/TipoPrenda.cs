using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPrenda
    {
        readonly TipoPrendaDAO tipoPrendaDAO = new();

        public List<TipoPrendaDTO> ObtenerTipoPrendas()
        {
            return tipoPrendaDAO.ObtenerTipoPrendas();
        }

        public string AgregarTipoPrenda(TipoPrendaDTO tipoPrendaDto)
        {
            return tipoPrendaDAO.AgregarTipoPrenda(tipoPrendaDto);
        }

        public TipoPrendaDTO BuscarTipoPrendaID(int Codigo)
        {
            return tipoPrendaDAO.BuscarTipoPrendaID(Codigo);
        }

        public string ActualizarTipoPrenda(TipoPrendaDTO tipoPrendaDTO)
        {
            return tipoPrendaDAO.ActualizarTipoPrenda(tipoPrendaDTO);
        }

        public bool EliminarTipoPrenda(TipoPrendaDTO tipoPrendaDTO)
        {
            return tipoPrendaDAO.EliminarTipoPrenda(tipoPrendaDTO);
        }

    }
}
