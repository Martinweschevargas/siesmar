using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModeloEquipoComunicacion
    {
        readonly ModeloEquipoComunicacionDAO modeloEquipoComunicacionDAO = new();

        public List<ModeloEquipoComunicacionDTO> ObtenerModeloEquipoComunicacions()
        {
            return modeloEquipoComunicacionDAO.ObtenerModeloEquipoComunicacions();
        }

        public string AgregarModeloEquipoComunicacion(ModeloEquipoComunicacionDTO modeloEquipoComunicacionDto)
        {
            return modeloEquipoComunicacionDAO.AgregarModeloEquipoComunicacion(modeloEquipoComunicacionDto);
        }

        public ModeloEquipoComunicacionDTO BuscarModeloEquipoComunicacionID(int Codigo)
        {
            return modeloEquipoComunicacionDAO.BuscarModeloEquipoComunicacionID(Codigo);
        }

        public string ActualizarModeloEquipoComunicacion(ModeloEquipoComunicacionDTO modeloEquipoComunicacionDTO)
        {
            return modeloEquipoComunicacionDAO.ActualizarModeloEquipoComunicacion(modeloEquipoComunicacionDTO);
        }

        public bool EliminarModeloEquipoComunicacion(int Codigo)
        {
            return modeloEquipoComunicacionDAO.EliminarModeloEquipoComunicacion(Codigo);
        }

    }
}
