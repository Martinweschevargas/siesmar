using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class InformeAccionTransgredenSeguridadDTO
    {
        public int InformeAccionTransgredenSeguridadId { get; set; }
        public string? InformeTransgresion { get; set; }
        public string? FechaInforme { get; set; }
        public string? FechaSucesoTransgresion { get; set; }
        public string? DepartamentoUbigeo { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? ZonaNavald { get; set; }
        public int? DependenciaId { get; set; }
        public int? TipoTransgresionId { get; set; }
        public string? DetalleHecho { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescTipoTransgresion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
