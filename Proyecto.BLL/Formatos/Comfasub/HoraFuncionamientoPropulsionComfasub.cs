using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class HoraFuncionamientoPropulsionComfasub
    {
        HoraFuncionamientoPropulsionComfasubDAO horaFuncionamientoPropulsionComfasubDAO = new();

        public List<HoraFuncionamientoPropulsionComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return horaFuncionamientoPropulsionComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasub, string? fecha)
        {
            return horaFuncionamientoPropulsionComfasubDAO.AgregarRegistro(horaFuncionamientoPropulsionComfasub, fecha);
        }

        public HoraFuncionamientoPropulsionComfasubDTO EditarFormado(int Codigo)
        {
            return horaFuncionamientoPropulsionComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO)
        {
            return horaFuncionamientoPropulsionComfasubDAO.ActualizaFormato(horaFuncionamientoPropulsionComfasubDTO);
        }

        public bool EliminarFormato(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO)
        {
            return horaFuncionamientoPropulsionComfasubDAO.EliminarFormato( horaFuncionamientoPropulsionComfasubDTO);
        }

        public bool EliminarCarga(HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO)
        {
            return horaFuncionamientoPropulsionComfasubDAO.EliminarCarga(horaFuncionamientoPropulsionComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return horaFuncionamientoPropulsionComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
