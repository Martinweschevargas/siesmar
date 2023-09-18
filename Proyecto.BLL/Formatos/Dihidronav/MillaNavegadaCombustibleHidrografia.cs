using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class MillaNavegadaCombustibleHidrografia
    {
        MillaNavegadaCombustibleHidrografiaDAO millaNavegadaCombustibleHidrografiaDAO = new();

        public List<MillaNavegadaCombustibleHidrografiaDTO> ObtenerLista(int? CargaId = null)
        {
            return millaNavegadaCombustibleHidrografiaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografia)
        {
            return millaNavegadaCombustibleHidrografiaDAO.AgregarRegistro(millaNavegadaCombustibleHidrografia);
        }

        public MillaNavegadaCombustibleHidrografiaDTO BuscarFormato(int Codigo)
        {
            return millaNavegadaCombustibleHidrografiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO)
        {
            return millaNavegadaCombustibleHidrografiaDAO.ActualizaFormato(millaNavegadaCombustibleHidrografiaDTO);
        }

        public bool EliminarFormato(MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO)
        {
            return millaNavegadaCombustibleHidrografiaDAO.EliminarFormato( millaNavegadaCombustibleHidrografiaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return millaNavegadaCombustibleHidrografiaDAO.InsertarDatos(datos);
        }

    }
}
