using Marina.Siesmar.AccesoDatos.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diredumar
{
    public class SegEspecialidadPersonalSupSub
    {
        SegEspecialidadPersonalSupSubDAO segEspecialidadPersonalSupSubDAO = new();

        public List<SegEspecialidadPersonalSupSubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return segEspecialidadPersonalSupSubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSub, string? fecha = null)
        {
            return segEspecialidadPersonalSupSubDAO.AgregarRegistro(segEspecialidadPersonalSupSub, fecha);
        }

        public SegEspecialidadPersonalSupSubDTO EditarFormato(int Codigo)
        {
            return segEspecialidadPersonalSupSubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO)
        {
            return segEspecialidadPersonalSupSubDAO.ActualizaFormato(segEspecialidadPersonalSupSubDTO);
        }

        public bool EliminarFormato(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO)
        {
            return segEspecialidadPersonalSupSubDAO.EliminarFormato(segEspecialidadPersonalSupSubDTO);
        }

        public bool EliminarCarga(SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO)
        {
            return segEspecialidadPersonalSupSubDAO.EliminarCarga(segEspecialidadPersonalSupSubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return segEspecialidadPersonalSupSubDAO.InsertarDatos(datos, fecha);
        }

    }
}
