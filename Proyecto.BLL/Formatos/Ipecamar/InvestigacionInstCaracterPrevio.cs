using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar
{
    public class InvestigacionInstCaracterPrevio
    {
        InvestigacionInstCaracterPrevioDAO investigacionInstCaracterPrevioDAO = new();

        public List<InvestigacionInstCaracterPrevioDTO> ObtenerLista(int? CargaId = null)
        {
            return investigacionInstCaracterPrevioDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO)
        {
            return investigacionInstCaracterPrevioDAO.AgregarRegistro(investigacionInstCaracterPrevioDTO);
        }

        public InvestigacionInstCaracterPrevioDTO BuscarFormato(int Codigo)
        {
            return investigacionInstCaracterPrevioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO)
        {
            return investigacionInstCaracterPrevioDAO.ActualizaFormato(investigacionInstCaracterPrevioDTO);
        }

        public bool EliminarFormato(InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO)
        {
            return investigacionInstCaracterPrevioDAO.EliminarFormato(investigacionInstCaracterPrevioDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return investigacionInstCaracterPrevioDAO.InsertarDatos(datos);
        }

    }
}
