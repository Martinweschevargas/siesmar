using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperpac
{
    public partial class EfectivoAccionMilitarDTO
    {

        public int? EfectivoAccionMilitarId { get; set; }
        public int? ComandanciaNavalId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public string? UnidadParticipante { get; set; }
        public int? GradoPersonalId { get; set; }
        public string? ObservacionesEfectivoAccionMilitar { get; set; }
        public string? DescComandanciaNaval { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescGradoPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
