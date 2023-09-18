using Marina.Siesmar.AccesoDatos.Formatos.Fovimar;
using Marina.Siesmar.Entidades.Formatos.Fovimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Fovimar
{
    public class PrestamoHipotecarioNaval
    {
        PrestamoHipotecarioNavalDAO prestamoHipotecarioNavalDAO = new();

        public List<PrestamoHipotecarioNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return prestamoHipotecarioNavalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(PrestamoHipotecarioNavalDTO prestamoHipotecarioNaval, string? fecha)
        {
            return prestamoHipotecarioNavalDAO.AgregarRegistro(prestamoHipotecarioNaval, fecha);
        }

        public PrestamoHipotecarioNavalDTO BuscarFormato(int Codigo)
        {
            return prestamoHipotecarioNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO)
        {
            return prestamoHipotecarioNavalDAO.ActualizaFormato(prestamoHipotecarioNavalDTO);
        }

        public bool EliminarFormato(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO)
        {
            return prestamoHipotecarioNavalDAO.EliminarFormato( prestamoHipotecarioNavalDTO);
        }

        public bool EliminarCarga(PrestamoHipotecarioNavalDTO prestamoHipotecarioNavalDTO)
        {
            return prestamoHipotecarioNavalDAO.EliminarCarga(prestamoHipotecarioNavalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return prestamoHipotecarioNavalDAO.InsertarDatos(datos, fecha);
        }


    }
}
