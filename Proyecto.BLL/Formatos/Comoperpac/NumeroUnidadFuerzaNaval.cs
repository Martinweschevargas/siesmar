using Marina.Siesmar.AccesoDatos.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac
{
    public class NumeroUnidadFuerzaNaval
    {
        NumeroUnidadFuerzaNavalDAO numeroUnidadFuerzaNavalDAO = new();

        public List<NumeroUnidadFuerzaNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return numeroUnidadFuerzaNavalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO, string? fecha = null)
        {
            return numeroUnidadFuerzaNavalDAO.AgregarRegistro(numeroUnidadFuerzaNavalDTO, fecha);
        }

        public NumeroUnidadFuerzaNavalDTO EditarFormato(int Codigo)
        {
            return numeroUnidadFuerzaNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO)
        {
            return numeroUnidadFuerzaNavalDAO.ActualizaFormato(numeroUnidadFuerzaNavalDTO);
        }

        public bool EliminarFormato(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO)
        {
            return numeroUnidadFuerzaNavalDAO.EliminarFormato(numeroUnidadFuerzaNavalDTO);
        }

        public bool EliminarCarga(NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO)
        {
            return numeroUnidadFuerzaNavalDAO.EliminarCarga(numeroUnidadFuerzaNavalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return numeroUnidadFuerzaNavalDAO.InsertarDatos(datos, fecha);
        }

    }
}
