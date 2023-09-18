using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InstalacionTerrestreAcuatica
    {
        readonly InstalacionTerrestreAcuaticaDAO instalacionTerrestreAcuaticaDAO = new();

        public List<InstalacionTerrestreAcuaticaDTO> ObtenerInstalacionTerrestreAcuaticas()
        {
            return instalacionTerrestreAcuaticaDAO.ObtenerInstalacionTerrestreAcuaticas();
        }

        public string AgregarInstalacionTerrestreAcuatica(InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDto)
        {
            return instalacionTerrestreAcuaticaDAO.AgregarInstalacionTerrestreAcuatica(instalacionTerrestreAcuaticaDto);
        }

        public InstalacionTerrestreAcuaticaDTO BuscarInstalacionTerrestreAcuaticaID(int Codigo)
        {
            return instalacionTerrestreAcuaticaDAO.BuscarInstalacionTerrestreAcuaticaID(Codigo);
        }

        public string ActualizarInstalacionTerrestreAcuatica(InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDto)
        {
            return instalacionTerrestreAcuaticaDAO.ActualizarInstalacionTerrestreAcuatica(instalacionTerrestreAcuaticaDto);
        }

        public string EliminarInstalacionTerrestreAcuatica(InstalacionTerrestreAcuaticaDTO instalacionTerrestreAcuaticaDto)
        {
            return instalacionTerrestreAcuaticaDAO.EliminarInstalacionTerrestreAcuatica(instalacionTerrestreAcuaticaDto);
        }

    }
}
