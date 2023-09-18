﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comescuama
{
    public partial class SituacionAeronaveDTO
    {

        public int? SituacionAeronaveId { get; set; }
        public int? UnidadNavalId { get; set; }
        public string? Categoria { get; set; }
        public int? TipoPlataformaAeronaveId { get; set; }
        public int? DependenciaId { get; set; }
        public string? Ubicacion { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public int? CapacidadOperativaRequeridaId { get; set; }
        public int? CondicionId { get; set; }
        public string? Observaciones { get; set; }



        public string? DescUnidadNaval { get; set; }
        public string? DescTipoPlataformaAeronave { get; set; }
        public string?  NombreDependencia { get; set; }
        public string? DescDistrito { get; set; }
        public string? DescCapacidadOperativaRequerida { get; set; }
        public string? DescCondicion { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
