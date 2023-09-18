using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperpac
{
    public partial class BajaTiempoPazDTO
    {

        public int? BajaTiempoPazId { get; set; }
        public int? ZonaNavalId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? GradoPersonalId { get; set; }
        public int? TipoBajaId { get; set; }
        public string? MotivoBajaTiempoPaz { get; set; }

        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }

        public string? DescZonaNaval { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescGradoPersonal { get; set; }
        public string? DescTipoBaja { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
