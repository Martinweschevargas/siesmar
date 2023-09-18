using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ipecamar
{
    public partial class DenunciaAnticorrupcionDTO
    {
        public int DenunciaAnticorrupcionId { get; set; }
        public string? FechaRegistroDenuncAntic { get; set; }
        public string? CodigoCanalDenuncia { get; set; }
        public string? EvaluacionRequisitoDenuncAntic { get; set; }
        public string? SituacionActualDenuncAntic { get; set; }
        public int? CargaId { get; set; }
        public string? DescCanalDenuncia { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
