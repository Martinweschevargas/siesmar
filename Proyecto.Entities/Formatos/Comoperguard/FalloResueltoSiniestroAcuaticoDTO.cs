using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class FalloResueltoSiniestroAcuaticoDTO
    {

        public int? FalloResueltoSiniestroAcuaticoId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraCaptura { get; set; }
        public int? DiaCaptura { get; set; }
        public int? MesId { get; set; }
        public int? AnioSiniestro { get; set; }
        public int? TipoNaveId { get; set; }
        public string? NombreNaveSiniestro { get; set; }
        public string? MatriculaNaveSiniestro { get; set; }
        public int? ABEdad { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? TipoSiniestroId { get; set; }
        public int? PersonasRescatadasVida { get; set; }
        public int? PersonasFallecidas { get; set; }
        public int? PersonasDesaparecida { get; set; }
        public int? PersonasEvacuadas { get; set; }
        public int? TotalPersonas { get; set; }
        public string? ReferenciaDocumento { get; set; }
        public string? FechaDocumento { get; set; }
        public string? ResumenFallo { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescMes { get; set; }
        public string? DescTipoNave { get; set; }
        public string? NombrePaisUbigeo { get; set; }
        public string? DescTipoSiniestro { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
