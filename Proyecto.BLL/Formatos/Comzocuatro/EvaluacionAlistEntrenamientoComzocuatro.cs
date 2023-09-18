using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class EvaluacionAlistEntrenamientoComzocuatro
    {
        EvaluacionAlistEntrenamientoComzocuatroDAO evaluacionAlistEntrenamientoComzocuatroDAO = new();

        public List<EvaluacionAlistEntrenamientoComzocuatroDTO> ObtenerLista()
        {
            return evaluacionAlistEntrenamientoComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO)
        {
            return evaluacionAlistEntrenamientoComzocuatroDAO.AgregarRegistro(evaluacionAlistEntrenamientoComzocuatroDTO);
        }

        public EvaluacionAlistEntrenamientoComzocuatroDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistEntrenamientoComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO)
        {
            return evaluacionAlistEntrenamientoComzocuatroDAO.ActualizaFormato(evaluacionAlistEntrenamientoComzocuatroDTO);
        }

        public bool EliminarFormato(EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO)
        {
            return evaluacionAlistEntrenamientoComzocuatroDAO.EliminarFormato(evaluacionAlistEntrenamientoComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return evaluacionAlistEntrenamientoComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
