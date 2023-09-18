using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperama
{
    public partial class EfectivoUnidadOperativaPazDTO
    {

        public int? EfectivoUnidadOperativaPazId { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoGradoPersonal { get; set; }
        public int? NumeroEfectivosRequeridos { get; set; }
        public int? NumeroEfectivosAsignados { get; set; }
        public int? CargaId { get; set; }

        public string? DescComandanciaDependencia { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescGrado { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
