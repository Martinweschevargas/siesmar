using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar
{
    public class InspeccionInstitucionales
    {
        InspeccionInstitucionalesDAO inspeccionInstitucionalesDAO = new();

        public List<InspeccionInstitucionalesDTO> ObtenerLista(int? CargaId= null)
        {
            return inspeccionInstitucionalesDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO)
        {
            return inspeccionInstitucionalesDAO.AgregarRegistro(inspeccionInstitucionalesDTO);
        }

        public InspeccionInstitucionalesDTO BuscarFormato(int Codigo)
        {
            return inspeccionInstitucionalesDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO)
        {
            return inspeccionInstitucionalesDAO.ActualizaFormato(inspeccionInstitucionalesDTO);
        }

        public bool EliminarFormato(InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO)
        {
            return inspeccionInstitucionalesDAO.EliminarFormato(inspeccionInstitucionalesDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return inspeccionInstitucionalesDAO.InsertarDatos(datos);
        }


    }
}
