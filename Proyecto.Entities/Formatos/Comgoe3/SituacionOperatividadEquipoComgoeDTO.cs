using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comgoe3
{
    public partial class SituacionOperatividadEquipoComgoeDTO
    {

        public int? FormatoSituacionOperatividadEquipoId { get; set; }
        public int? DescripcionMaterialId { get; set; }
        public int? Cantidad { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CondicionId { get; set; }
        public string? Observaciones { get; set; } 
 

        public string? Clasificacion { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; } 
        public string? DescCondicion { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
