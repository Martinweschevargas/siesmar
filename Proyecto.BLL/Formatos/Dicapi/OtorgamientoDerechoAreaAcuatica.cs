using Marina.Siesmar.AccesoDatos.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dicapi
{
    public class OtorgamientoDerechoAreaAcuatica
    {
        OtorgamientoDerechoAreaAcuaticaDAO otorgamientoDerechoAreaAcuaticaDAO = new();

        public List<OtorgamientoDerechoAreaAcuaticaDTO> ObtenerLista()
        {
            return otorgamientoDerechoAreaAcuaticaDAO.ObtenerLista();
        }

        public string AgregarRegistro(OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuatica)
        {
            return otorgamientoDerechoAreaAcuaticaDAO.AgregarRegistro(otorgamientoDerechoAreaAcuatica);
        }

        public OtorgamientoDerechoAreaAcuaticaDTO BuscarFormato(int Codigo)
        {
            return otorgamientoDerechoAreaAcuaticaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO)
        {
            return otorgamientoDerechoAreaAcuaticaDAO.ActualizaFormato(otorgamientoDerechoAreaAcuaticaDTO);
        }

        public bool EliminarFormato(OtorgamientoDerechoAreaAcuaticaDTO otorgamientoDerechoAreaAcuaticaDTO)
        {
            return otorgamientoDerechoAreaAcuaticaDAO.EliminarFormato( otorgamientoDerechoAreaAcuaticaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return otorgamientoDerechoAreaAcuaticaDAO.InsertarDatos(datos);
        }

        //public bool InsercionMasiva(IEnumerable<OtorgamientoDerechoAreaAcuaticaDTO> otorgamientoDerechoAreaAcuaticaDTO)
        //{
        //    return otorgamientoDerechoAreaAcuaticaDAO.InsercionMasiva(otorgamientoDerechoAreaAcuaticaDTO);
        //}

    }
}
