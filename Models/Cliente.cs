using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoERC.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [Column("CodCliente", Order = 0)]
        public int CodigoCliente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("NombreCompleto", Order = 1)]
        public string NombreCompleto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("NombreCorto", Order = 2)]
        public string NombreCorto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("Abreviatura", Order = 3)]
        public string Abreviatura { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("Ruc", Order = 4)]
        public string Ruc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("Estado", Order = 5)]
        public string Estado { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("GrupoFacturacion", Order = 6)]
        public string? GrupoFacturacion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("InactivoDesde", Order = 7)]
        public DateTime? InactivoDesde { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Column("CodigoSap", Order = 8)]
        public string? CodigoSAP { get; set; }
    }
}
