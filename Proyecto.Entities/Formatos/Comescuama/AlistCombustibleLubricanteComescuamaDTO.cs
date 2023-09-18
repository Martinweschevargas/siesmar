using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class AlistCombustibleLubricanteComescuamaDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante2 { get; set; }
        public decimal? PromedioPonderado { get; set; }
        public decimal? SubPromedioParcial { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
