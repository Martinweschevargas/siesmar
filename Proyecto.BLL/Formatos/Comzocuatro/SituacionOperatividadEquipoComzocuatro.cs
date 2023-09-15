using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class SituacionOperatividadEquipoComzocuatro
    {
        SituacionOperatividadEquipoComzocuatroDAO SituacionOperatividadEquipoComzocuatroDAO = new();

        public List<SituacionOperatividadEquipoComzocuatroDTO> ObtenerLista()
        {
            return SituacionOperatividadEquipoComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadEquipoComzocuatroDTO SituacionOperatividadEquipoComzocuatroDTO)
        {
            return SituacionOperatividadEquipoComzocuatroDAO.AgregarRegistro(SituacionOperatividadEquipoComzocuatroDTO);
        }

        public SituacionOperatividadEquipoComzocuatroDTO BuscarFormato(int Codigo)
        {
            return SituacionOperatividadEquipoComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadEquipoComzocuatroDTO SituacionOperatividadEquipoComzocuatroDTO)
        {
            return SituacionOperatividadEquipoComzocuatroDAO.ActualizaFormato(SituacionOperatividadEquipoComzocuatroDTO);
        }

        public bool EliminarFormato(SituacionOperatividadEquipoComzocuatroDTO SituacionOperatividadEquipoComzocuatroDTO)
        {
            return SituacionOperatividadEquipoComzocuatroDAO.EliminarFormato(SituacionOperatividadEquipoComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return SituacionOperatividadEquipoComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
