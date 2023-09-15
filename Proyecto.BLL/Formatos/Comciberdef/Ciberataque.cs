using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comciberdef
{
    public class Ciberataque
    {
        CiberataqueDAO ciberataqueDAO = new();

        public List<CiberataqueDTO> ObtenerLista(int? CargaId = null)
        {
            return ciberataqueDAO.ObtenerLista(CargaId);
        }
        public List<CiberataqueDTO> VisualizacionCiberataque(int? CargaId = null)
        {
            return ciberataqueDAO.VisualizacionCiberataque( CargaId);
        }

        public List<CiberataqueDTO> CantidadCiberataquesXSeveridadSegunAccion(string? accionAnteCiberataque = null, string? fecha_inicio = null, string? fecha_fin = null, int? CargaId=null)
        {
            return ciberataqueDAO.CantidadCiberataquesXSeveridadSegunAccion(accionAnteCiberataque,  fecha_inicio,  fecha_fin,  CargaId);
        }

        public List<CiberataqueDTO> CantidadCiberataquesXtipoAccionSegunTiposCiberataques(string? tipoCiberataque = null, string? fecha_inicio = null, string? fecha_fin = null, int? CargaId = null)
        {
            return ciberataqueDAO.CantidadCiberataquesXtipoAccionSegunTiposCiberataques( tipoCiberataque,  fecha_inicio,  fecha_fin,  CargaId);
        }
        public string AgregarRegistro(CiberataqueDTO ciberataqueDTO)
        {
            return ciberataqueDAO.AgregarRegistro(ciberataqueDTO);
        }

        public CiberataqueDTO BuscarFormato(int Codigo)
        {
            return ciberataqueDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CiberataqueDTO ciberataqueDTO)
        {
            return ciberataqueDAO.ActualizaFormato(ciberataqueDTO);
        }

        public bool EliminarFormato(CiberataqueDTO ciberataqueDTO)
        {
            return ciberataqueDAO.EliminarFormato(ciberataqueDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ciberataqueDAO.InsertarDatos(datos);
        }

    }
}
