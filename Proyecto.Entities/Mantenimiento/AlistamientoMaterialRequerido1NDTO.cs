using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoMaterialRequerido1NDTO
    {
        public int AlistamientoMaterialRequerido1NId { get; set; }
        public string? CapacidadIntrinseca { get; set; }
        public decimal? Ponderado1N { get; set; }
        public string? CodigoAlistamientoMaterialRequerido1N { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}

