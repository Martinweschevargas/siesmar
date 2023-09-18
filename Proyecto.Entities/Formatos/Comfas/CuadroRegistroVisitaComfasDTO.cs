using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class CuadroRegistroVisitaComfasDTO
    {

        public int? CuadroRegistroVisitaComfasId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaVisita { get; set; }
        public string? HoraIngreso { get; set; }
        public string? HoraSalida { get; set; }
        public int? DNIVisitante { get; set; }
        public int? PasaporteVisitante { get; set; }
        public int? PaisUbigeoId { get; set; }
        public int? ClaseVisitaId { get; set; }
        public string? MotivoViaje { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? NombrePais { get; set; }
        public string? DescClaseVisita { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
