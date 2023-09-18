using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.AccesoDatos.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac
{
    public class EfectivoAccionMilitar
    {
        EfectivoAccionMilitarDAO efectivoAccionMilitarDAO = new();

        public List<EfectivoAccionMilitarDTO> ObtenerLista()
        {
            return efectivoAccionMilitarDAO.ObtenerLista();
        }

        public string AgregarRegistro(EfectivoAccionMilitarDTO efectivoAccionMilitarDTO)
        {
            return efectivoAccionMilitarDAO.AgregarRegistro(efectivoAccionMilitarDTO);
        }

        public EfectivoAccionMilitarDTO BuscarFormato(int Codigo)
        {
            return efectivoAccionMilitarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EfectivoAccionMilitarDTO efectivoAccionMilitarDTO)
        {
            return efectivoAccionMilitarDAO.ActualizaFormato(efectivoAccionMilitarDTO);
        }

        public bool EliminarFormato(EfectivoAccionMilitarDTO efectivoAccionMilitarDTO)
        {
            return efectivoAccionMilitarDAO.EliminarFormato(efectivoAccionMilitarDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return efectivoAccionMilitarDAO.InsertarDatos(datos);
        }

    }
}
