using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoMaterialDestruido
    {
        readonly TipoMaterialDestruidoDAO TipoMaterialDestruidoDAO = new();

        public List<TipoMaterialDestruidoDTO> ObtenerCapintanias()
        {
            return TipoMaterialDestruidoDAO.ObtenerTipoMaterialDestruidos();
        }

        public string AgregarTipoMaterialDestruido(TipoMaterialDestruidoDTO tipoMaterialDestruidoDto)
        {
            return TipoMaterialDestruidoDAO.AgregarTipoMaterialDestruido(tipoMaterialDestruidoDto);
        }

        public TipoMaterialDestruidoDTO BuscarTipoMaterialDestruidoID(int Codigo)
        {
            return TipoMaterialDestruidoDAO.BuscarTipoMaterialDestruidoID(Codigo);
        }

        public string ActualizarTipoMaterialDestruido(TipoMaterialDestruidoDTO tipoMaterialDestruidoDto)
        {
            return TipoMaterialDestruidoDAO.ActualizarTipoMaterialDestruido(tipoMaterialDestruidoDto);
        }

        public string EliminarTipoMaterialDestruido(TipoMaterialDestruidoDTO tipoMaterialDestruidoDto)
        {
            return TipoMaterialDestruidoDAO.EliminarTipoMaterialDestruido(tipoMaterialDestruidoDto);
        }

    }
}
