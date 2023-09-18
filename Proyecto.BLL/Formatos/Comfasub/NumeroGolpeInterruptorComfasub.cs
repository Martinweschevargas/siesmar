using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class NumeroGolpeInterruptorComfasub
    {
        NumeroGolpeInterruptorComfasubDAO numeroGolpeInterruptorComfasubDAO = new();

        public List<NumeroGolpeInterruptorComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return numeroGolpeInterruptorComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasub, string? fecha)
        {
            return numeroGolpeInterruptorComfasubDAO.AgregarRegistro(numeroGolpeInterruptorComfasub, fecha);
        }

        public NumeroGolpeInterruptorComfasubDTO EditarFormado(int Codigo)
        {
            return numeroGolpeInterruptorComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO)
        {
            return numeroGolpeInterruptorComfasubDAO.ActualizaFormato(numeroGolpeInterruptorComfasubDTO);
        }

        public bool EliminarFormato(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO)
        {
            return numeroGolpeInterruptorComfasubDAO.EliminarFormato( numeroGolpeInterruptorComfasubDTO);
        }

        public bool EliminarCarga(NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO)
        {
            return numeroGolpeInterruptorComfasubDAO.EliminarCarga(numeroGolpeInterruptorComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return numeroGolpeInterruptorComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
