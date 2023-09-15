using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperama
{
    public partial class EfectivoNivelEntrenamientoUnidadDTO
    {

        public int? EfectivoNivelEntrenamientoUnidadId { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoGradoPersonal { get; set; }
        public decimal? NivelElemental { get; set; }
        public decimal? NivelBasico { get; set; }
        public decimal? NivelIntermedio { get; set; }
        public decimal? NivelAvanzado { get; set; }
        public decimal? NivelConjunto { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescGradoPersonal { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
