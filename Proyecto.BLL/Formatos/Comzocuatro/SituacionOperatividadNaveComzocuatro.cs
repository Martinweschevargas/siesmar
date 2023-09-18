using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class SituacionOperatividadNaveComzocuatro
    {
        SituacionOperatividadNaveComzocuatroDAO situacionOperatividadNaveComzocuatroDAO = new();

        public List<SituacionOperatividadNaveComzocuatroDTO> ObtenerLista()
        {
            return situacionOperatividadNaveComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadNaveComzocuatroDTO situacionOperatividadNaveComzocuatroDTO)
        {
            return situacionOperatividadNaveComzocuatroDAO.AgregarRegistro(situacionOperatividadNaveComzocuatroDTO);
        }

        public SituacionOperatividadNaveComzocuatroDTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadNaveComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadNaveComzocuatroDTO situacionOperatividadNaveComzocuatroDTO)
        {
            return situacionOperatividadNaveComzocuatroDAO.ActualizaFormato(situacionOperatividadNaveComzocuatroDTO);
        }

        public bool EliminarFormato(SituacionOperatividadNaveComzocuatroDTO situacionOperatividadNaveComzocuatroDTO)
        {
            return situacionOperatividadNaveComzocuatroDAO.EliminarFormato(situacionOperatividadNaveComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return situacionOperatividadNaveComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
