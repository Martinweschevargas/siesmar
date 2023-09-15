using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MaterialRepBienHistorico
    {
        readonly MaterialRepBienHistoricoDAO materialRepBienHistoricoDAO = new();

        public List<MaterialRepBienHistoricoDTO> ObtenerMaterialRepBienHistoricos()
        {
            return materialRepBienHistoricoDAO.ObtenerMaterialRepBienHistoricos();
        }

        public string AgregarMaterialRepBienHistorico(MaterialRepBienHistoricoDTO materialRepBienHistoricoDto)
        {
            return materialRepBienHistoricoDAO.AgregarMaterialRepBienHistorico(materialRepBienHistoricoDto);
        }

        public MaterialRepBienHistoricoDTO BuscarMaterialRepBienHistoricoID(int Codigo)
        {
            return materialRepBienHistoricoDAO.BuscarMaterialRepBienHistoricoID(Codigo);
        }

        public string ActualizarMaterialRepBienHistorico(MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO)
        {
            return materialRepBienHistoricoDAO.ActualizarMaterialRepBienHistorico(materialRepBienHistoricoDTO);
        }

        public bool EliminarMaterialRepBienHistorico(MaterialRepBienHistoricoDTO materialRepBienHistoricoDTO)
        {
            return materialRepBienHistoricoDAO.EliminarMaterialRepBienHistorico(materialRepBienHistoricoDTO);
        }

    }
}
