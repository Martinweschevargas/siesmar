using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class MovilidadFlotaPesadaLivianaCombasnai
    {
        MovilidadFlotaPesadaLivianaCombasnaiDAO movilidadFlotaPesadaLivianaCombasnaiDAO = new();

        public List<MovilidadFlotaPesadaLivianaCombasnaiDTO> ObtenerLista()
        {
            return movilidadFlotaPesadaLivianaCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO)
        {
            return movilidadFlotaPesadaLivianaCombasnaiDAO.AgregarRegistro(movilidadFlotaPesadaLivianaCombasnaiDTO);
        }

        public MovilidadFlotaPesadaLivianaCombasnaiDTO BuscarFormato(int Codigo)
        {
            return movilidadFlotaPesadaLivianaCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO)
        {
            return movilidadFlotaPesadaLivianaCombasnaiDAO.ActualizaFormato(movilidadFlotaPesadaLivianaCombasnaiDTO);
        }

        public bool EliminarFormato(MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO)
        {
            return movilidadFlotaPesadaLivianaCombasnaiDAO.EliminarFormato(movilidadFlotaPesadaLivianaCombasnaiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return movilidadFlotaPesadaLivianaCombasnaiDAO.InsertarDatos(datos);
        }

    }
}
