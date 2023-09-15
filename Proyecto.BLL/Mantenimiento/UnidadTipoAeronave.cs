using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadTipoAeronave
    {
        readonly UnidadTipoAeronaveDAO unidadTipoAeronaveDAO = new();

        public List<UnidadTipoAeronaveDTO> ObtenerUnidadTipoAeronaves()
        {
            return unidadTipoAeronaveDAO.ObtenerUnidadTipoAeronaves();
        }

        public string AgregarUnidadTipoAeronave(UnidadTipoAeronaveDTO unidadTipoAeronaveDto)
        {
            return unidadTipoAeronaveDAO.AgregarUnidadTipoAeronave(unidadTipoAeronaveDto);
        }

        public UnidadTipoAeronaveDTO BuscarUnidadTipoAeronaveID(int Codigo)
        {
            return unidadTipoAeronaveDAO.BuscarUnidadTipoAeronaveID(Codigo);
        }

        public string ActualizarUnidadTipoAeronave(UnidadTipoAeronaveDTO unidadTipoAeronaveDto)
        {
            return unidadTipoAeronaveDAO.ActualizarUnidadTipoAeronave(unidadTipoAeronaveDto);
        }

        public string EliminarUnidadTipoAeronave(UnidadTipoAeronaveDTO unidadTipoAeronaveDto)
        {
            return unidadTipoAeronaveDAO.EliminarUnidadTipoAeronave(unidadTipoAeronaveDto);
        }

    }
}
