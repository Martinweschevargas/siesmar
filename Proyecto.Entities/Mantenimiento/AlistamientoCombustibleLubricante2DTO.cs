using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class AlistamientoCombustibleLubricante2DTO
    {
        public int AlistamientoCombustibleLubricante2Id { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante2 { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? CodigoUnidadMedida { get; set; }
        public int Cargo { get; set; }
        public int Aumento { get; set; }
        public int Consumo { get; set; }
        public int Existencia { get; set; }

        public string? DescUnidadMedida { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
