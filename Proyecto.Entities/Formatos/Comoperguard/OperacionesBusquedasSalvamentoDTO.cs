using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperguard
{
    public partial class OperacionesBusquedasSalvamentoDTO
    {

        public int? OperacionBusquedaSalvamentoId { get; set; }
        public int? JefaturaDistritoCapitaniaId { get; set; }
        public int? CapitaniaId { get; set; }
        public string? HoraSiniestro { get; set; }
        public string? FechaSiniestro { get; set; }
        public int? TipoSiniestroId { get; set; }
        public string? MensajeActivacionRSC { get; set; }
        public string? MensajeDesactivacionRSC { get; set; }
        public string? NombreNaveSiniestrada { get; set; }
        public string? MatriculaNaveSiniestrada { get; set; }
        public int? ABEdad { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? PersonasRescatadasVida { get; set; }
        public int? PersonasFallecidas { get; set; }
        public int? PersonasDesaparecidas { get; set; }
        public int? PersonasEvacuadas { get; set; }
        public string? LatitudUbicacionNave { get; set; }
        public string? LongitudUbicacionNave { get; set; }
        public string? ZonaSiniestro { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? AmbitoNaveId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? TipoVehiculoMovilId { get; set; }
        public int? MarcaVehiculoId { get; set; }
        public int? Millas { get; set; }
        public int? Kilometro { get; set; }
        public int? Galones { get; set; }
        public string? ResultadoTerminoOperaciones { get; set; }
        public string? ObservacionesSiniestro { get; set; }
        public string? DescJefaturaDistritoCapitania { get; set; }
        public string? NombreCapitania { get; set; }
        public string? DescTipoSiniestro { get; set; }
        public string? NombrePais { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescAmbitoNave { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescTipoVehiculoMovil { get; set; }
        public string? DescMarcaVehiculo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
