using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class EjercicioTiroArmaMenorComzocuatro
    {
        EjercicioTiroArmaMenorComzocuatroDAO ejercicioTiroArmaMenorComzocuatroDAO = new();

        public List<EjercicioTiroArmaMenorComzocuatroDTO> ObtenerLista()
        {
            return ejercicioTiroArmaMenorComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO)
        {
            return ejercicioTiroArmaMenorComzocuatroDAO.AgregarRegistro(ejercicioTiroArmaMenorComzocuatroDTO);
        }

        public EjercicioTiroArmaMenorComzocuatroDTO BuscarFormato(int Codigo)
        {
            return ejercicioTiroArmaMenorComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO)
        {
            return ejercicioTiroArmaMenorComzocuatroDAO.ActualizaFormato(ejercicioTiroArmaMenorComzocuatroDTO);
        }

        public bool EliminarFormato(EjercicioTiroArmaMenorComzocuatroDTO ejercicioTiroArmaMenorComzocuatroDTO)
        {
            return ejercicioTiroArmaMenorComzocuatroDAO.EliminarFormato(ejercicioTiroArmaMenorComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ejercicioTiroArmaMenorComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
