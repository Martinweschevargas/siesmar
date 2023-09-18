using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comoperpac
{
    public partial class EfectivoCompaniaIntervencionRapidaDTO
    {

        public int? EfectivoCompaniaIntervencionRapidaId { get; set; }
        public string? CodigoComandanciaNaval { get; set; }
        public string? CodigoUbicacionCIRD { get; set; }
        public int? CantidadEfectivos { get; set; }
        public decimal? NivelOrganizacion { get; set; }
        public decimal? NivelEquipamiento { get; set; }
        public decimal? NivelInstruccion { get; set; }
        public decimal? NivelEntrenamiento { get; set; }
        public int? CargaId { get; set; }
        public string? DescComandanciaNaval { get; set; }
        public string? DescUbicacionCIRD { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
