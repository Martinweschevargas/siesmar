using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperama
{
    public partial class IngresoAlistamientoDTO
    {

        public int? IngresoAlistamientoId { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoDependencia { get; set; }
        public decimal? Aliper { get; set; }
        public decimal? Alient { get; set; }
        public decimal? Alimat { get; set; }
        public decimal? Alilog { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public int? CargaId { get; set; }

        public string? DescComandanciaDependencia { get; set; }
        public string? NombreDependencia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
