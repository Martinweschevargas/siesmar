using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzouno
{
    public partial class AlistamientoCombustibleLubricanteComzounoDTO
    {

        public int AlistamientoCombustibleLubricanteId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante2 { get; set; }
        public decimal? PromedioPonderado { get; set; }
        public decimal? SubPromedioParcial { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? DescUnidadMedida { get; set; }
        public string? Cargo { get; set; }
        public string? Aumento { get; set; }
        public string? Consumo { get; set; }
        public string? Existencia { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
