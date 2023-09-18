using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Iafas
{
    public partial class PersonalAfiliadoProgramaSaludDTO
    {

        public int? PersonalAfiliadoProgramaSaludId { get; set; }
        public string? DocumentoAfiliado { get; set; }
        public string? SexoPersonalAfiliado { get; set; }
        public string? CodigoSituacionPersonalNaval { get; set; }
        public string? FechaAfiliacion { get; set; }
        public string? CodigoParentescoAfiliado { get; set; }
        public string? CodigoTipoAfiliacion { get; set; }
        public string? DistritoUbigeo { get; set; }
        public string? ProvinciaUbigeo { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? MantieneAfiliado { get; set; }
        public string? FechaDesafiliacion { get; set; }
        public string? MotivoDesafiliacion { get; set; }
        public string? CodigoFormaContactoAfiliado { get; set; }
        public string? ActivacionSeguroOncologico { get; set; }
        public string? ActivacionSeguroSegundaCapa { get; set; }

        public int? CargaId { get; set; }

        public string? DescSituacionPersonalNaval { get; set; }
        public string? DescParentescoAfiliado { get; set; }
        public string? DescTipoAfiliacion { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescFormaContactoAfiliado { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}