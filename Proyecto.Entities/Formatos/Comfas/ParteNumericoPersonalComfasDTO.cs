using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfas
{
    public partial class ParteNumericoPersonalComfasDTO
    {

        public int? ParteNumericoPersonalComfasId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? FechaParte { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? PlantaOrganica { get; set; }
        public int? PlantaActual { get; set; }
        public int? EfectivoDeficit { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescEspecialidadGenericaPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
