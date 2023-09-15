using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadAeronave
    {
        readonly UnidadAeronaveDAO unidadAeronaveDAO = new();

        public List<UnidadAeronaveDTO> ObtenerUnidadAeronaves()
        {
            return unidadAeronaveDAO.ObtenerUnidadAeronaves();
        }

        public string AgregarUnidadAeronave(UnidadAeronaveDTO unidadAeronaveDto)
        {
            return unidadAeronaveDAO.AgregarUnidadAeronave(unidadAeronaveDto);
        }

        public UnidadAeronaveDTO BuscarUnidadAeronaveID(int Codigo)
        {
            return unidadAeronaveDAO.BuscarUnidadAeronaveID(Codigo);
        }

        public string ActualizarUnidadAeronave(UnidadAeronaveDTO unidadAeronaveDto)
        {
            return unidadAeronaveDAO.ActualizarUnidadAeronave(unidadAeronaveDto);
        }

        public string EliminarUnidadAeronave(UnidadAeronaveDTO unidadAeronaveDto)
        {
            return unidadAeronaveDAO.EliminarUnidadAeronave(unidadAeronaveDto);
        }

    }
}
