using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class EvaluacionAlistPersonalCombasnai
    {
        EvaluacionAlistPersonalCombasnaiDAO evaluacionAlistPersonalCombasnaiDAO = new();

        public List<EvaluacionAlistPersonalCombasnaiDTO> ObtenerLista()
        {
            return evaluacionAlistPersonalCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistPersonalCombasnaiDTO evaluacionAlistPersonalCombasnaiDTO)
        {
            return evaluacionAlistPersonalCombasnaiDAO.AgregarRegistro(evaluacionAlistPersonalCombasnaiDTO);
        }

        public EvaluacionAlistPersonalCombasnaiDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistPersonalCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistPersonalCombasnaiDTO evaluacionAlistPersonalCombasnaiDTO)
        {
            return evaluacionAlistPersonalCombasnaiDAO.ActualizaFormato(evaluacionAlistPersonalCombasnaiDTO);
        }

        public bool EliminarFormato(EvaluacionAlistPersonalCombasnaiDTO evaluacionAlistPersonalCombasnaiDTO)
        {
            return evaluacionAlistPersonalCombasnaiDAO.EliminarFormato(evaluacionAlistPersonalCombasnaiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return evaluacionAlistPersonalCombasnaiDAO.InsertarDatos(datos);
        }
    }
}
