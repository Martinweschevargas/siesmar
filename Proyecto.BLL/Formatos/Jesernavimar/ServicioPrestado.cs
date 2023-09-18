
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Jesernavimar;
using Marina.Siesmar.Entidades.Formatos.Jesernavimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesernavimar
{
    public class ServicioPrestado
    {
        ServicioPrestadoDAO servicioPrestadoDAO = new();

        public List<ServicioPrestadoDTO> ObtenerLista(int? CargaId = null, int? mes = null, int? anio = null)
        {
            return servicioPrestadoDAO.ObtenerLista(CargaId, mes, anio);
        }

        public string AgregarRegistro(ServicioPrestadoDTO servicioPrestadoDTO, int mes, int anio)
        {
            return servicioPrestadoDAO.AgregarRegistro(servicioPrestadoDTO, mes, anio);
        }

        public ServicioPrestadoDTO BuscarFormato(int Codigo)
        {
            return servicioPrestadoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioPrestadoDTO servicioPrestadoDTO)
        {
            return servicioPrestadoDAO.ActualizaFormato(servicioPrestadoDTO);
        }

        public bool EliminarFormato(ServicioPrestadoDTO servicioPrestadoDTO)
        {
            return servicioPrestadoDAO.EliminarFormato(servicioPrestadoDTO);
        }

        public string InsertarDatos(DataTable datos, int mes, int anio)
        {
            return servicioPrestadoDAO.InsertarDatos(datos, mes, anio);
        }


    }
}
