using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.AccesoDatos.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac
{
    public class BajaTiempoPaz
    {
        BajaTiempoPazDAO bajaTiempoPazDAO = new();

        public List<BajaTiempoPazDTO> ObtenerLista()
        {
            return bajaTiempoPazDAO.ObtenerLista();
        }

        public string AgregarRegistro(BajaTiempoPazDTO bajaTiempoPazDTO)
        {
            return bajaTiempoPazDAO.AgregarRegistro(bajaTiempoPazDTO);
        }

        public BajaTiempoPazDTO BuscarFormato(int Codigo)
        {
            return bajaTiempoPazDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(BajaTiempoPazDTO bajaTiempoPazDTO)
        {
            return bajaTiempoPazDAO.ActualizaFormato(bajaTiempoPazDTO);
        }

        public bool EliminarFormato(BajaTiempoPazDTO bajaTiempoPazDTO)
        {
            return bajaTiempoPazDAO.EliminarFormato(bajaTiempoPazDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return bajaTiempoPazDAO.InsertarDatos(datos);
        }

    }
}
