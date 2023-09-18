using Marina.Siesmar.AccesoDatos.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dicapi
{
    public class ExpTransporteMercanciaSustancia
    {
        ExpTransporteMercanciaSustanciaDAO expTransporteMercanciaSustanciaDAO = new();

        public List<ExpTransporteMercanciaSustanciaDTO> ObtenerLista()
        {
            return expTransporteMercanciaSustanciaDAO.ObtenerLista();
        }

        public string AgregarRegistro(ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustancia)
        {
            return expTransporteMercanciaSustanciaDAO.AgregarRegistro(expTransporteMercanciaSustancia);
        }

        public ExpTransporteMercanciaSustanciaDTO BuscarFormato(int Codigo)
        {
            return expTransporteMercanciaSustanciaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO)
        {
            return expTransporteMercanciaSustanciaDAO.ActualizaFormato(expTransporteMercanciaSustanciaDTO);
        }

        public bool EliminarFormato(ExpTransporteMercanciaSustanciaDTO expTransporteMercanciaSustanciaDTO)
        {
            return expTransporteMercanciaSustanciaDAO.EliminarFormato( expTransporteMercanciaSustanciaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return expTransporteMercanciaSustanciaDAO.InsertarDatos(datos);
        }

        //public bool InsercionMasiva(IEnumerable<ExpTransporteMercanciaSustanciaDTO> expTransporteMercanciaSustanciaDTO)
        //{
        //    return expTransporteMercanciaSustanciaDAO.InsercionMasiva(expTransporteMercanciaSustanciaDTO);
        //}

    }
}
