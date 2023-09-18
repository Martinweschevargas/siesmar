using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class SituacionOperatividadEquipoComestre
    {
        SituacionOperatividadEquipoComestreDAO situacionOperatividadEquipoComestreDAO = new();

        public List<SituacionOperatividadEquipoComestreDTO> ObtenerLista()
        {
            return situacionOperatividadEquipoComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestre)
        {
            return situacionOperatividadEquipoComestreDAO.AgregarRegistro(situacionOperatividadEquipoComestre);
        }

        public SituacionOperatividadEquipoComestreDTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadEquipoComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO)
        {
            return situacionOperatividadEquipoComestreDAO.ActualizaFormato(situacionOperatividadEquipoComestreDTO);
        }

        public bool EliminarFormato(SituacionOperatividadEquipoComestreDTO situacionOperatividadEquipoComestreDTO)
        {
            return situacionOperatividadEquipoComestreDAO.EliminarFormato( situacionOperatividadEquipoComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoComestreDTO> situacionOperatividadEquipoComestreDTO)
        {
            return situacionOperatividadEquipoComestreDAO.InsercionMasiva(situacionOperatividadEquipoComestreDTO);
        }

    }
}
