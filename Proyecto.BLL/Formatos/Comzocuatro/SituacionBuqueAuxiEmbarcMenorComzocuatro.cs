using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class SituacionBuqueAuxiEmbarcMenorComzocuatro
    {
        SituacionBuqueAuxiEmbarcMenorComzocuatroDAO situacionBuqueAuxiEmbarcMenorComzocuatroDAO = new();

        public List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO> ObtenerLista()
        {
            return situacionBuqueAuxiEmbarcMenorComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO)
        {
            return situacionBuqueAuxiEmbarcMenorComzocuatroDAO.AgregarRegistro(situacionBuqueAuxiEmbarcMenorComzocuatroDTO);
        }

        public SituacionBuqueAuxiEmbarcMenorComzocuatroDTO BuscarFormato(int Codigo)
        {
            return situacionBuqueAuxiEmbarcMenorComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO)
        {
            return situacionBuqueAuxiEmbarcMenorComzocuatroDAO.ActualizaFormato(situacionBuqueAuxiEmbarcMenorComzocuatroDTO);
        }

        public bool EliminarFormato(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO)
        {
            return situacionBuqueAuxiEmbarcMenorComzocuatroDAO.EliminarFormato(situacionBuqueAuxiEmbarcMenorComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return situacionBuqueAuxiEmbarcMenorComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
