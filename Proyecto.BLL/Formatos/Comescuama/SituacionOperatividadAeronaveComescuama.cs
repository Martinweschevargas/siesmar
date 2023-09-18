using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class SituacionOperatividadAeronaveComescuama
    {
        SituacionOperatividadAeronaveComescuamaDAO situacionOperatividadAeronaveComescuamaDAO = new();

        public List<SituacionOperatividadAeronaveComescuamaDTO> ObtenerLista()
        {
            return situacionOperatividadAeronaveComescuamaDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadAeronaveComescuamaDTO situacionOperatividadAeronaveComescuamaDTO)
        {
            return situacionOperatividadAeronaveComescuamaDAO.AgregarRegistro(situacionOperatividadAeronaveComescuamaDTO);
        }

        public SituacionOperatividadAeronaveComescuamaDTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadAeronaveComescuamaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadAeronaveComescuamaDTO situacionOperatividadAeronaveComescuamaDTO)
        {
            return situacionOperatividadAeronaveComescuamaDAO.ActualizaFormato(situacionOperatividadAeronaveComescuamaDTO);
        }

        public bool EliminarFormato(SituacionOperatividadAeronaveComescuamaDTO situacionOperatividadAeronaveComescuamaDTO)
        {
            return situacionOperatividadAeronaveComescuamaDAO.EliminarFormato(situacionOperatividadAeronaveComescuamaDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadAeronaveComescuamaDTO> situacionOperatividadAeronaveComescuamaDTO)
        {
            return situacionOperatividadAeronaveComescuamaDAO.InsercionMasiva(situacionOperatividadAeronaveComescuamaDTO);
        }

    }
}
