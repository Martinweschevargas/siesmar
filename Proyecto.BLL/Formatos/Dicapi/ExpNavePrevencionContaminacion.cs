using Marina.Siesmar.AccesoDatos.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dicapi
{
    public class ExpNavePrevencionContaminacion
    {
        ExpNavePrevencionContaminacionDAO expNavePrevencionContaminacionDAO = new();

        public List<ExpNavePrevencionContaminacionDTO> ObtenerLista()
        {
            return expNavePrevencionContaminacionDAO.ObtenerLista();
        }

        public string AgregarRegistro(ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacion)
        {
            return expNavePrevencionContaminacionDAO.AgregarRegistro(expNavePrevencionContaminacion);
        }

        public ExpNavePrevencionContaminacionDTO BuscarFormato(int Codigo)
        {
            return expNavePrevencionContaminacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO)
        {
            return expNavePrevencionContaminacionDAO.ActualizaFormato(expNavePrevencionContaminacionDTO);
        }

        public bool EliminarFormato(ExpNavePrevencionContaminacionDTO expNavePrevencionContaminacionDTO)
        {
            return expNavePrevencionContaminacionDAO.EliminarFormato( expNavePrevencionContaminacionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return expNavePrevencionContaminacionDAO.InsertarDatos(datos);
        }

        //public bool InsercionMasiva(IEnumerable<ExpNavePrevencionContaminacionDTO> expNavePrevencionContaminacionDTO)
        //{
        //    return expNavePrevencionContaminacionDAO.InsercionMasiva(expNavePrevencionContaminacionDTO);
        //}

    }
}
