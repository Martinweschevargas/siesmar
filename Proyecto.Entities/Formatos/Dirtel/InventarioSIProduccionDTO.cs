using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class InventarioSIProduccionDTO
    {

        public int? InventarioSIProduccionId { get; set; }
        public string? NombreSIProduccion { get; set; }
        public string? SiglasSIProduccion { get; set; }
        public string? CodigoAreaSatisfaceDirtel { get; set; }
        public string? DescripcionFuncionalidad { get; set; }
        public string? CodigoCicloDesarrolloSoftware { get; set; }
        public string? AlcanceSIProduccion { get; set; }
        public string? ProcedenciaSIProduccion { get; set; }
        public string? CodigoDenominacionBaseDato { get; set; }
        public string? ServidorBDSIProduccion { get; set; }
        public string? CodigoDenominacionLenguajeProgramacion { get; set; }
        public string? ServidorWebSIProduccion { get; set; }
        public string? CodigoDependencia { get; set; }


        public string? DescAreaSatisfaceDirtel { get; set; }
        public string? DescCicloDesarrolloSoftware { get; set; }
        public string? DescDenominacionBaseDato { get; set; }
        public string? DescDenominacionLenguajeProgramacion { get; set; }
        public string? DescDependencia { get; set; }
        public int? CargaId { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}