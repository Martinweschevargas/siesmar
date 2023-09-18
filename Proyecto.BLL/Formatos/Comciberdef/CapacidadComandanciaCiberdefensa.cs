using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comciberdef
{
    public class CapacidadComandanciaCiberdefensa
    {
        CapacidadComandanciaCiberdefensaDAO capacidadComandanciaCiberdefensaDAO = new();

        public List<CapacidadComandanciaCiberdefensaDTO> ObtenerLista(int? CargaId = null)
        {
            return capacidadComandanciaCiberdefensaDAO.ObtenerLista(CargaId);
        }

        public List<CapacidadComandanciaCiberdefensaDTO> VisualizacionCapacidadComandanciaCiberdefensa(int? CargaId = null)
        {
            return capacidadComandanciaCiberdefensaDAO.VisualizacionCapacidadComandanciaCiberdefensa( CargaId);
        }
        public string AgregarRegistro(CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO)
        {
            return capacidadComandanciaCiberdefensaDAO.AgregarRegistro(capacidadComandanciaCiberdefensaDTO);
        }

        public CapacidadComandanciaCiberdefensaDTO BuscarFormato(int Codigo)
        {
            return capacidadComandanciaCiberdefensaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO)
        {
            return capacidadComandanciaCiberdefensaDAO.ActualizaFormato(capacidadComandanciaCiberdefensaDTO);
        }

        public bool EliminarFormato(CapacidadComandanciaCiberdefensaDTO capacidadComandanciaCiberdefensaDTO)
        {
            return capacidadComandanciaCiberdefensaDAO.EliminarFormato(capacidadComandanciaCiberdefensaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return capacidadComandanciaCiberdefensaDAO.InsertarDatos(datos);
        }

    }
}
