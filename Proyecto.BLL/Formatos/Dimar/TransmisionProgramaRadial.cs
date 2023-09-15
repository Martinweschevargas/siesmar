using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class TransmisionProgramaRadial
    {
        TransmisionProgramaRadialDAO transmisionProgramaRadialDAO = new();

        public List<TransmisionProgramaRadialDTO> ObtenerLista(int? CargaId = null)
        {
            return transmisionProgramaRadialDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(TransmisionProgramaRadialDTO transmisionProgramaRadialDTO)
        {
            return transmisionProgramaRadialDAO.AgregarRegistro(transmisionProgramaRadialDTO);
        }

        public TransmisionProgramaRadialDTO BuscarFormato(int Codigo)
        {
            return transmisionProgramaRadialDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(TransmisionProgramaRadialDTO transmisionProgramaRadialDTO)
        {
            return transmisionProgramaRadialDAO.ActualizaFormato(transmisionProgramaRadialDTO);
        }

        public bool EliminarFormato(TransmisionProgramaRadialDTO transmisionProgramaRadialDTO)
        {
            return transmisionProgramaRadialDAO.EliminarFormato(transmisionProgramaRadialDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return transmisionProgramaRadialDAO.InsertarDatos(datos);
        }

    }
}
