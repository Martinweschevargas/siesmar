using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combasnai
{
    public partial class SituacionEmbarcacionMenorCombasnaiDTO
    {

        public int? SituacionEmbarcacionMenorId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? CategoriaEmbarcacion { get; set; }
        public int? TipoPlataformaNaveId { get; set; }
        public int? DependenciaId { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CapacidadOperativaRequeridaId { get; set; }
        public int? CondicionId { get; set; }
        public string? Observacion { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescTipoPlataformaNave { get; set; }
        public string? NombreDependencia { get; set; }  
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCapacidadOperativaRequerida { get; set; }
        public string? DescCondicion { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
