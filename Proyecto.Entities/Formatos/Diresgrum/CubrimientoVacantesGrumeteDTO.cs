using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diresgrum
{
    public partial class CubrimientoVacantesGrumeteDTO
    {
        public int? CubrimientoVacanteGrumeteId { get; set; }
        public int? AnioCubrimientoVacante { get; set; }
        public int? NumeroContingente { get; set; }
        public string? CodigoEspecialidadGrumete { get; set; }
        public string? SexoGrumete { get; set; }
        public int? NumeroRequerido { get; set; }
        public int? NumeroEfectivo { get; set; }
        public int? DeficitVacante { get; set; }
        public int? CargaId { get; set; }
        public string? DescEspecialidadGrumete { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
