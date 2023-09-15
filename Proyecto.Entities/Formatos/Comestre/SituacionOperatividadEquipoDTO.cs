using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class SituacionOperatividadEquipoComestreDTO
    {

        public int? SituacionOperatividadEquipoId { get; set; }
        public int? DescripcionMaterialId { get; set; }
        public int? Cantidad { get; set; }
        public string? CodigoUnidad { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public string? Condicion { get; set; }
        public string? Observacion { get; set; }


        public string? Clasificacion { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}