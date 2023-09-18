using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class SituacionOperatividadEquipoCombima1
    {
        SituacionOperatividadEquipoCombima1DAO situacionOperatividadEquipoCombima1DAO = new();

        public List<SituacionOperatividadEquipoCombima1DTO> ObtenerLista()
        {
            return situacionOperatividadEquipoCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO)
        {
            return situacionOperatividadEquipoCombima1DAO.AgregarRegistro(situacionOperatividadEquipoCombima1DTO);
        }

        public SituacionOperatividadEquipoCombima1DTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadEquipoCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO)
        {
            return situacionOperatividadEquipoCombima1DAO.ActualizaFormato(situacionOperatividadEquipoCombima1DTO);
        }

        public bool EliminarFormato(SituacionOperatividadEquipoCombima1DTO situacionOperatividadEquipoCombima1DTO)
        {
            return situacionOperatividadEquipoCombima1DAO.EliminarFormato(situacionOperatividadEquipoCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoCombima1DTO> situacionOperatividadEquipoCombima1DTO)
        {
            return situacionOperatividadEquipoCombima1DAO.InsercionMasiva(situacionOperatividadEquipoCombima1DTO);
        }

    }
}
