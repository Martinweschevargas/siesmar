using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoArtefactoNaval
    {
        readonly TipoArtefactoNavalDAO tipoArtefactoNavalDAO = new();

        public List<TipoArtefactoNavalDTO> ObtenerTipoArtefactoNavals()
        {
            return tipoArtefactoNavalDAO.ObtenerTipoArtefactoNavals();
        }

        public string AgregarTipoArtefactoNaval(TipoArtefactoNavalDTO tipoArtefactoNavalDto)
        {
            return tipoArtefactoNavalDAO.AgregarTipoArtefactoNaval(tipoArtefactoNavalDto);
        }

        public TipoArtefactoNavalDTO BuscarTipoArtefactoNavalID(int Codigo)
        {
            return tipoArtefactoNavalDAO.BuscarTipoArtefactoNavalID(Codigo);
        }

        public string ActualizarTipoArtefactoNaval(TipoArtefactoNavalDTO tipoArtefactoNavalDto)
        {
            return tipoArtefactoNavalDAO.ActualizarTipoArtefactoNaval(tipoArtefactoNavalDto);
        }

        public string EliminarTipoArtefactoNaval(TipoArtefactoNavalDTO tipoArtefactoNavalDto)
        {
            return tipoArtefactoNavalDAO.EliminarTipoArtefactoNaval(tipoArtefactoNavalDto);
        }

    }
}
