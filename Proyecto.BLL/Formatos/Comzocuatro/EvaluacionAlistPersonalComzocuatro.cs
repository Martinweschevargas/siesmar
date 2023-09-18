using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class EvaluacionAlistPersonalComzocuatro
    {
        EvaluacionAlistPersonalComzocuatroDAO evaluacionAlistPersonalComzocuatroDAO = new();

        public List<EvaluacionAlistPersonalComzocuatroDTO> ObtenerLista()
        {
            return evaluacionAlistPersonalComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO)
        {
            return evaluacionAlistPersonalComzocuatroDAO.AgregarRegistro(evaluacionAlistPersonalComzocuatroDTO);
        }

        public EvaluacionAlistPersonalComzocuatroDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistPersonalComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO)
        {
            return evaluacionAlistPersonalComzocuatroDAO.ActualizaFormato(evaluacionAlistPersonalComzocuatroDTO);
        }

        public bool EliminarFormato(EvaluacionAlistPersonalComzocuatroDTO evaluacionAlistPersonalComzocuatroDTO)
        {
            return evaluacionAlistPersonalComzocuatroDAO.EliminarFormato(evaluacionAlistPersonalComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return evaluacionAlistPersonalComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
