using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    internal class UnidadComescuama
    {
        readonly UnidadComescuamaDAO unidadComescuamaDAO = new();

        public List<UnidadComescuamaDTO> ObtenerUnidadComescuamas()
        {
            return unidadComescuamaDAO.ObtenerUnidadComescuamas();
        }

        public string AgregarUnidadComescuama(UnidadComescuamaDTO unidadComescuamaDTO)
        {
            return unidadComescuamaDAO.AgregarUnidadComescuama(unidadComescuamaDTO);
        }

        public UnidadComescuamaDTO BuscarUnidadComescuama(int Codigo)
        {
            return unidadComescuamaDAO.BuscarUnidadComescuama(Codigo);
        }

        public string ActualizarUnidadComescuama(UnidadComescuamaDTO unidadComescuamaDTO)
        {
            return unidadComescuamaDAO.ActualizarUnidadComescuama(unidadComescuamaDTO);
        }

        public string EliminarUnidadComescuama(UnidadComescuamaDTO unidadComescuamaDTO)
        {
            return unidadComescuamaDAO.EliminarUnidadComescuama(unidadComescuamaDTO);
        }
    }
}

