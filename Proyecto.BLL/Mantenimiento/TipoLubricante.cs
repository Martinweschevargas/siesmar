using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoLubricante
    {
        readonly TipoLubricanteDAO tipoLubricanteDAO = new();

        public List<TipoLubricanteDTO> ObtenerTipoLubricantes()
        {
            return tipoLubricanteDAO.ObtenerTipoLubricantes();
        }

        public string AgregarTipoLubricante(TipoLubricanteDTO tipoLubricanteDto)
        {
            return tipoLubricanteDAO.AgregarTipoLubricante(tipoLubricanteDto);
        }

        public TipoLubricanteDTO BuscarTipoLubricanteID(int Codigo)
        {
            return tipoLubricanteDAO.BuscarTipoLubricanteID(Codigo);
        }

        public string ActualizarTipoLubricante(TipoLubricanteDTO tipoLubricanteDTO)
        {
            return tipoLubricanteDAO.ActualizarTipoLubricante(tipoLubricanteDTO);
        }

        public bool EliminarTipoLubricante(TipoLubricanteDTO tipoLubricanteDTO)
        {
            return tipoLubricanteDAO.EliminarTipoLubricante(tipoLubricanteDTO);
        }

    }
}
