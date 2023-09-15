using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class KilometroRecorridoUnidadTerrestre
    {
        KilometroRecorridoUnidadTerrestreDAO kilometroRecUniTerrestreDAO = new();

        public List<KilometroRecorridoUnidadTerrestreDTO> ObtenerLista()
        {
            return kilometroRecUniTerrestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(KilometroRecorridoUnidadTerrestreDTO kilometroRecUniTerrestreDTO)
        {
            return kilometroRecUniTerrestreDAO.AgregarRegistro(kilometroRecUniTerrestreDTO);
        }

        public KilometroRecorridoUnidadTerrestreDTO BuscarFormato(int Codigo)
        {
            return kilometroRecUniTerrestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(KilometroRecorridoUnidadTerrestreDTO kilometroRecUniTerrestreDTO)
        {
            return kilometroRecUniTerrestreDAO.ActualizaFormato(kilometroRecUniTerrestreDTO);
        }

        public bool EliminarFormato(KilometroRecorridoUnidadTerrestreDTO kilometroRecUniTerrestreDTO)
        {
            return kilometroRecUniTerrestreDAO.EliminarFormato(kilometroRecUniTerrestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<KilometroRecorridoUnidadTerrestreDTO> kilometroRecUniTerrestreDTO)
        {
            return kilometroRecUniTerrestreDAO.InsercionMasiva(kilometroRecUniTerrestreDTO);
        }

    }
}
