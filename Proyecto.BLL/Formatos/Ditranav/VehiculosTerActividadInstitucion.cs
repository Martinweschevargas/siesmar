using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Ditranav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Ditranav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ditranav
{
    public class VehiculosTerActividadInstitucion
    {
        VehiculosTerActividadInstitucionDAO vehiculosTerActividadInstitucionDAO = new();

        public List<VehiculosTerActividadInstitucionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return vehiculosTerActividadInstitucionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstitucion, string? fecha)
        {
            return vehiculosTerActividadInstitucionDAO.AgregarRegistro(vehiculosTerActividadInstitucion, fecha);
        }

        public VehiculosTerActividadInstitucionDTO EditarFormato(int Codigo)
        {
            return vehiculosTerActividadInstitucionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstitucionDTO)
        {
            return vehiculosTerActividadInstitucionDAO.ActualizaFormato(vehiculosTerActividadInstitucionDTO);
        }

        public bool EliminarFormato(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstitucionDTO)
        {
            return vehiculosTerActividadInstitucionDAO.EliminarFormato(vehiculosTerActividadInstitucionDTO);
        }

        public bool EliminarCarga(VehiculosTerActividadInstitucionDTO vehiculosTerActividadInstitucionDTO)
        {
            return vehiculosTerActividadInstitucionDAO.EliminarCarga(vehiculosTerActividadInstitucionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return vehiculosTerActividadInstitucionDAO.InsertarDatos(datos, fecha);
        }

    }
}
