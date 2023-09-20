using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class AlistCombustibleLubricanteComescuamaDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public string? CodigoUnidadComescuama { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante2 { get; set; }
        public decimal? PromedioPonderado { get; set; }
        public decimal? SubPromedioParcial { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadComescuama { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? DescUnidadMedida { get; set; }
        public string? Cargo { get; set; }
        public string? Aumento { get; set; }
        public string? Consumo { get; set; }
        public string? Existencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
