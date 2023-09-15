using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class SiniestroAcuaticoActivacionRadiobalizaDTO
    {

        public int? SiniestroAcuaticoActivacionRadiobalizaId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraSiniestro { get; set; }
        public string? FechaSiniestro { get; set; }
        public int? TipoNaveId { get; set; }
        public string? NombreNaveSiniestro { get; set; }
        public string? MatriculaNaveSiniestro { get; set; }
        public int? ABEdad { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? TipoSiniestroId { get; set; }
        public string? CuentaRadiobaliza { get; set; }
        public string? ActivoRadiobaliza { get; set; }
        public string? TipoActivacionRadiobaliza { get; set; }
        public int? TipoRadiobalizaId { get; set; }
        public string? CodigoHexadecimal { get; set; }
        public string? ActivoPlanBusqueda { get; set; }
        public string? MNReferenciaActivacion { get; set; }
        public string? MNReferenciaDesactiva { get; set; }
        public int? TiempoDuracionHoras { get; set; }
        public string? LatitudUbicacionNave { get; set; }
        public string? LongitudUbicacionNave { get; set; }
        public int? AmbitoNaveId { get; set; }
        public int? PersonasRescatadasVida { get; set; }
        public int? PersonasFallecidas { get; set; }
        public int? PersonasDesaparecida { get; set; }
        public int? TotalPersonas { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? UnidadesParticulares { get; set; }
        public string? ResumenCaso { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescTipoNave { get; set; }
        public string? NombrePais { get; set; }
        public string? DescTipoSiniestro { get; set; }
        public string? DescTipoRadiobaliza { get; set; }
        public string? DescAmbitoNave { get; set; }
        public string? DescUnidadNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
