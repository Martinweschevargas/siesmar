using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class SituacionOperatividadEquipoComescuama
    {
        SituacionOperatividadEquipoComescuamaDAO situacionOperatividadEquipoComescuamaDAO = new();

        public List<SituacionOperatividadEquipoComescuamaDTO> ObtenerLista()
        {
            return situacionOperatividadEquipoComescuamaDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadEquipoComescuamaDTO situacionOperatividadEquipoComescuamaDTO)
        {
            return situacionOperatividadEquipoComescuamaDAO.AgregarRegistro(situacionOperatividadEquipoComescuamaDTO);
        }

        public SituacionOperatividadEquipoComescuamaDTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadEquipoComescuamaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadEquipoComescuamaDTO situacionOperatividadEquipoComescuamaDTO)
        {
            return situacionOperatividadEquipoComescuamaDAO.ActualizaFormato(situacionOperatividadEquipoComescuamaDTO);
        }

        public bool EliminarFormato(SituacionOperatividadEquipoComescuamaDTO situacionOperatividadEquipoComescuamaDTO)
        {
            return situacionOperatividadEquipoComescuamaDAO.EliminarFormato(situacionOperatividadEquipoComescuamaDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoComescuamaDTO> situacionOperatividadEquipoComescuamaDTO)
        {
            return situacionOperatividadEquipoComescuamaDAO.InsercionMasiva(situacionOperatividadEquipoComescuamaDTO);
        }

    }
}
