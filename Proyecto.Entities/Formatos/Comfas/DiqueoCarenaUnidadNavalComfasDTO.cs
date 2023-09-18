using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class DiqueoCarenaUnidadNavalComfasDTO
    {

        public int? DiqueoCarenaUnidadNavalId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaIngresoUltimoDiqueo { get; set; }
        public string? FechaSalidaUltimoDiqueo { get; set; }
        public string? FechaIngresoProximoDiqueo { get; set; }
        public string? FechaSalidaProximoDiqueo { get; set; }
        public string? PrioridadProximoDiqueo { get; set; }
        public string? Lugar { get; set; }
        public string? Observaciones { get; set; }



        public string? DescUnidadNaval { get; set; }





        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
