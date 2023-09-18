using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ModeloEquipoComunicacionDTO
    {
        public int ModeloEquipoComunicacionId { get; set; }
        public string? DescModeloEquipoComunicacion { get; set; }
        public string? CodigoModeloEquipoComunicacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
