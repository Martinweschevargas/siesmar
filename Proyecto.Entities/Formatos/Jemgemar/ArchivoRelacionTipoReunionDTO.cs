using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Jemgemar
{
    public partial class ArchivoRelacionTipoReunionDTO
    {
        public int ArchivoRelacionTipoReunionId { get; set; }
        public string? CodigoReunion { get; set; }
        public string? NumericoPais { get; set; }
        public string? CondicionPais { get; set; }
        public string? NroReunion { get; set; }
        public int? NroParticipantes { get; set; }
        public int? NroDiasRelacionReunion { get; set; }
        public decimal? GastosRelacionReunion { get; set; }
        public string? Observaciones { get; set; }
        public int? AFPersonal { get; set; }
        public int? AFInteligencia { get; set; }
        public int? AFOperacionEntrenamiento { get; set; }
        public int? AFLogistica { get; set; }
        public int? AFTelematica { get; set; }
        public int? AFInstruccion { get; set; }
        public int? AFAccionCivica { get; set; }
        public int? AFCienciaTecnologia { get; set; }
        public int? AFTerrorismoNarcotrafico { get; set; }
        public int? AFMedioAmbiente { get; set; }
        public int? APPersonal { get; set; }
        public int? APInteligencia { get; set; }
        public int? APOperacionEntrenamiento { get; set; }
        public int? APLogistica { get; set; }
        public int? APTelematica { get; set; }
        public int? APInstruccion { get; set; }
        public int? APAccionCivica { get; set; }
        public int? APCienciaTecnologia { get; set; }
        public int? APTerrorismoNarcotrafico { get; set; }
        public int? APMedioAmbiente { get; set; }
        public int? AEPersonal { get; set; }
        public int? AEInteligencia { get; set; }
        public int? AEOperacionEntrenamiento { get; set; }
        public int? AELogistica { get; set; }
        public int? AETelematica { get; set; }
        public int? AEInstruccion { get; set; }
        public int? AEAccionCivica { get; set; }
        public int? AECienciaTecnologia { get; set; }
        public int? AETerrorismoNarcotrafico { get; set; }
        public int? AEMedioAmbiente { get; set; }
        public int? CargaId { get; set; }
        public string? NombrePais { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
