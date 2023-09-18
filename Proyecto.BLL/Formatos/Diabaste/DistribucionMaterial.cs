using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.AccesoDatos.Formatos.Diabaste;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diabaste
{
    public class DistribucionMaterial
    {
        DistribucionMaterialDAO distribucionMaterialDAO = new();

        public List<DistribucionMaterialDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return distribucionMaterialDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(DistribucionMaterialDTO distribucionMaterial, string? fecha)
        {
            return distribucionMaterialDAO.AgregarRegistro(distribucionMaterial, fecha);
        }

        public DistribucionMaterialDTO EditarFormato(int Codigo)
        {
            return distribucionMaterialDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DistribucionMaterialDTO distribucionMaterialDTO)
        {
            return distribucionMaterialDAO.ActualizaFormato(distribucionMaterialDTO);
        }

        public bool EliminarFormato(DistribucionMaterialDTO distribucionMaterialDTO)
        {
            return distribucionMaterialDAO.EliminarFormato( distribucionMaterialDTO);
        }

        public bool EliminarCarga(DistribucionMaterialDTO distribucionMaterialDTO)
        {
            return distribucionMaterialDAO.EliminarCarga(distribucionMaterialDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return distribucionMaterialDAO.InsertarDatos(datos, fecha);
        }

    }
}
