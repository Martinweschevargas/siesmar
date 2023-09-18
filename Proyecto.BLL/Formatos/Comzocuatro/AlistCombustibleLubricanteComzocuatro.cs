using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class AlistCombustibleLubricanteComzocuatro
    {
        AlistCombustibleLubricanteComzocuatroDAO alistCombustibleLubricanteComzocuatroDAO = new();

        public List<AlistCombustibleLubricanteComzocuatroDTO> ObtenerLista()
        {
            return alistCombustibleLubricanteComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO)
        {
            return alistCombustibleLubricanteComzocuatroDAO.AgregarRegistro(alistCombustibleLubricanteComzocuatroDTO);
        }

        public AlistCombustibleLubricanteComzocuatroDTO BuscarFormato(int Codigo)
        {
            return alistCombustibleLubricanteComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO)
        {
            return alistCombustibleLubricanteComzocuatroDAO.ActualizaFormato(alistCombustibleLubricanteComzocuatroDTO);
        }

        public bool EliminarFormato(AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO)
        {
            return alistCombustibleLubricanteComzocuatroDAO.EliminarFormato(alistCombustibleLubricanteComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return alistCombustibleLubricanteComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
