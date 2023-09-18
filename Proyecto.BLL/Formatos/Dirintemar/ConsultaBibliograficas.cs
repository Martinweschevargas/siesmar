using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class ConsultaBibliograficas
    {
        ConsultaBibliograficasDAO consultaBibliograficasDAO = new();

        public List<ConsultaBibliograficasDTO> ObtenerLista()
        {
            return consultaBibliograficasDAO.ObtenerLista();
        }

        public string AgregarRegistro(ConsultaBibliograficasDTO consultaBibliograficas)
        {
            return consultaBibliograficasDAO.AgregarRegistro(consultaBibliograficas);
        }

        public ConsultaBibliograficasDTO EditarFormato(int Codigo)
        {
            return consultaBibliograficasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsultaBibliograficasDTO consultaBibliograficasDTO)
        {
            return consultaBibliograficasDAO.ActualizaFormato(consultaBibliograficasDTO);
        }

        public bool EliminarFormato(ConsultaBibliograficasDTO consultaBibliograficas)
        {
            return consultaBibliograficasDAO.EliminarFormato(consultaBibliograficas);
        }


        public string InsertarDatos(DataTable datos)
        {
            return consultaBibliograficasDAO.InsertarDatos(datos);
        }

    }
}
