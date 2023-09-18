using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EntidadFinanciera
    {
        readonly EntidadFinancieraDAO entidadFinancieraDAO = new();

        public List<EntidadFinancieraDTO> ObtenerEntidadFinancieras()
        {
            return entidadFinancieraDAO.ObtenerEntidadFinancieras();
        }

        public string AgregarEntidadFinanciera(EntidadFinancieraDTO entidadFinancieraDto)
        {
            return entidadFinancieraDAO.AgregarEntidadFinanciera(entidadFinancieraDto);
        }

        public EntidadFinancieraDTO BuscarEntidadFinancieraID(int Codigo)
        {
            return entidadFinancieraDAO.BuscarEntidadFinancieraID(Codigo);
        }

        public string ActualizarEntidadFinanciera(EntidadFinancieraDTO entidadFinancieraDto)
        {
            return entidadFinancieraDAO.ActualizarEntidadFinanciera(entidadFinancieraDto);
        }

        public string EliminarEntidadFinanciera(EntidadFinancieraDTO entidadFinancieraDto)
        {
            return entidadFinancieraDAO.EliminarEntidadFinanciera(entidadFinancieraDto);
        }

    }
}
