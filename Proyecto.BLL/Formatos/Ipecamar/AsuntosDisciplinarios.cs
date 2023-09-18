using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar
{
    public class AsuntosDisciplinarios
    {
        AsuntosDisciplinariosDAO asuntosDisciplinariosDAO = new();

        public List<AsuntosDisciplinariosDTO> ObtenerLista(int? CargaId = null)
        {
            return asuntosDisciplinariosDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(AsuntosDisciplinariosDTO asuntosDisciplinariosDTO)
        {
            return asuntosDisciplinariosDAO.AgregarRegistro(asuntosDisciplinariosDTO);
        }

        public AsuntosDisciplinariosDTO BuscarFormato(int Codigo)
        {
            return asuntosDisciplinariosDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AsuntosDisciplinariosDTO asuntosDisciplinariosDTO)
        {
            return asuntosDisciplinariosDAO.ActualizaFormato(asuntosDisciplinariosDTO);
        }

        public bool EliminarFormato(AsuntosDisciplinariosDTO asuntosDisciplinariosDTO)
        {
            return asuntosDisciplinariosDAO.EliminarFormato(asuntosDisciplinariosDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return asuntosDisciplinariosDAO.InsertarDatos(datos);
        }

    }
}
