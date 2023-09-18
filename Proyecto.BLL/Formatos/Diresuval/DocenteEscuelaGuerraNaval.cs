
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diresuval;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresuval;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresuval
{
    public class DocenteEscuelaGuerraNaval
    {
        DocenteEscuelaGuerraNavalDAO docenteEscuelaGuerraNavalDAO = new();

        public List<DocenteEscuelaGuerraNavalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return docenteEscuelaGuerraNavalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO, string? fecha = null)
        {
            return docenteEscuelaGuerraNavalDAO.AgregarRegistro(docenteEscuelaGuerraNavalDTO, fecha);
        }

        public DocenteEscuelaGuerraNavalDTO BuscarFormato(int Codigo)
        {
            return docenteEscuelaGuerraNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO)
        {
            return docenteEscuelaGuerraNavalDAO.ActualizaFormato(docenteEscuelaGuerraNavalDTO);
        }

        public bool EliminarFormato(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO)
        {
            return docenteEscuelaGuerraNavalDAO.EliminarFormato(docenteEscuelaGuerraNavalDTO);
        }

        public bool EliminarCarga(DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO)
        {
            return docenteEscuelaGuerraNavalDAO.EliminarCarga(docenteEscuelaGuerraNavalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return docenteEscuelaGuerraNavalDAO.InsertarDatos(datos, fecha);
        }

    }
}
