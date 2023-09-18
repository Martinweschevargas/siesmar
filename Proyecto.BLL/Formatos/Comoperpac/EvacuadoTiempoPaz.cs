using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.AccesoDatos.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac
{
    public class EvacuadoTiempoPaz
    {
        EvacuadoTiempoPazDAO evacuadoTiempoPazDAO = new();

        public List<EvacuadoTiempoPazDTO> ObtenerLista()
        {
            return evacuadoTiempoPazDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvacuadoTiempoPazDTO evacuadoTiempoPazDTO)
        {
            return evacuadoTiempoPazDAO.AgregarRegistro(evacuadoTiempoPazDTO);
        }

        public EvacuadoTiempoPazDTO BuscarFormato(int Codigo)
        {
            return evacuadoTiempoPazDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvacuadoTiempoPazDTO evacuadoTiempoPazDTO)
        {
            return evacuadoTiempoPazDAO.ActualizaFormato(evacuadoTiempoPazDTO);
        }

        public bool EliminarFormato(EvacuadoTiempoPazDTO evacuadoTiempoPazDTO)
        {
            return evacuadoTiempoPazDAO.EliminarFormato(evacuadoTiempoPazDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return evacuadoTiempoPazDAO.InsertarDatos(datos);
        }

    }
}
