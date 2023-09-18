using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class SituacionAeronave
    {
        SituacionAeronaveDAO situacionAeronaveDAO = new();

        public List<SituacionAeronaveDTO> ObtenerLista()
        {
            return situacionAeronaveDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionAeronaveDTO situacionAeronaveDTO)
        {
            return situacionAeronaveDAO.AgregarRegistro(situacionAeronaveDTO);
        }

        public SituacionAeronaveDTO BuscarFormato(int Codigo)
        {
            return situacionAeronaveDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionAeronaveDTO situacionAeronaveDTO)
        {
            return situacionAeronaveDAO.ActualizaFormato(situacionAeronaveDTO);
        }

        public bool EliminarFormato(SituacionAeronaveDTO situacionAeronaveDTO)
        {
            return situacionAeronaveDAO.EliminarFormato(situacionAeronaveDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionAeronaveDTO> situacionAeronaveDTO)
        {
            return situacionAeronaveDAO.InsercionMasiva(situacionAeronaveDTO);
        }

    }
}
