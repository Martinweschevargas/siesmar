using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Bienestar
{
    public partial class MaterialRecreacionEntretenamientoDTO
    {

        public int? MaterialRecreacionEntretenamientoId { get; set; }
        public string? FechaSolicitud { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoMaterialDeportivo { get; set; }
        public int? CantidadSolicitadoDeportivo { get; set; }
        public int? CantidadAtendidoDeportivo { get; set; }
        public decimal? MontoSolesSolicitadoDeportivo { get; set; }
        public decimal? MontoSolesAtendidoDeportivo { get; set; }
        public string? CodigoMaterialRecreativo { get; set; }
        public int? CantidadSolicitadoRecreativo { get; set; }
        public int? CantidadAtendidoRecreativo { get; set; }
        public decimal? MontoSolesSolicitanteRecreativo { get; set; }
        public decimal? MontoSolesAtendidoRecreativo { get; set; }
        public string? CodigoMaterialEntretenimiento { get; set; }
        public int? CantidadSolicitadoEntretenimiento { get; set; }
        public int? CantidadAtendidoEntretenimiento { get; set; }
        public decimal? MontoSolesSolicitadoEntretenimiento { get; set; }
        public decimal? MontoSolesAtendidoEntretenimiento { get; set; }


        public string? DescDependencia { get; set; }
        public string? DescMaterialDeportivo { get; set; }
        public string? DescMaterialRecreativo { get; set; }
        public string? DescMaterialEntretenimiento { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
