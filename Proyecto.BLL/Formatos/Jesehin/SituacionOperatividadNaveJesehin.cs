using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class SituacionOperatividadNaveJesehin
    {
        SituacionOperatividadNaveJesehinDAO situacionOperatividadNaveJesehinDAO = new();

        public List<SituacionOperatividadNaveJesehinDTO> ObtenerLista()
        {
            return situacionOperatividadNaveJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehin)
        {
            return situacionOperatividadNaveJesehinDAO.AgregarRegistro(situacionOperatividadNaveJesehin);
        }

        public SituacionOperatividadNaveJesehinDTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadNaveJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO)
        {
            return situacionOperatividadNaveJesehinDAO.ActualizaFormato(situacionOperatividadNaveJesehinDTO);
        }

        public bool EliminarFormato(SituacionOperatividadNaveJesehinDTO situacionOperatividadNaveJesehinDTO)
        {
            return situacionOperatividadNaveJesehinDAO.EliminarFormato( situacionOperatividadNaveJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadNaveJesehinDTO> situacionOperatividadNaveJesehinDTO)
        {
            return situacionOperatividadNaveJesehinDAO.InsercionMasiva(situacionOperatividadNaveJesehinDTO);
        }

    }
}
