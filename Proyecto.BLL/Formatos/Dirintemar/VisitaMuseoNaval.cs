using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class VisitaMuseoNaval
    {
        VisitaMuseoNavalDAO visitaMuseoNavalDAO = new();

        public List<VisitaMuseoNavalDTO> ObtenerLista()
        {
            return visitaMuseoNavalDAO.ObtenerLista();
        }

        public string AgregarRegistro(VisitaMuseoNavalDTO visitaMuseoNaval)
        {
            return visitaMuseoNavalDAO.AgregarRegistro(visitaMuseoNaval);
        }

        public VisitaMuseoNavalDTO EditarFormato(int Codigo)
        {
            return visitaMuseoNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(VisitaMuseoNavalDTO visitaMuseoNavalDTO)
        {
            return visitaMuseoNavalDAO.ActualizaFormato(visitaMuseoNavalDTO);
        }

        public bool EliminarFormato(VisitaMuseoNavalDTO visitaMuseoNavalDTO)
        {
            return visitaMuseoNavalDAO.EliminarFormato(visitaMuseoNavalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return visitaMuseoNavalDAO.InsertarDatos(datos);
        }

    }
}
