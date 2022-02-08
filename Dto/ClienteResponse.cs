using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoERC.Dto
{
    public class ClienteResponse
    {
        public int CodCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreCorto { get; set; }
        public string Abreviatura { get; set; }
        public string Ruc { get; set; }
        public string Estado { get; set; }
        public string? GrupoFacturacion { get; set; }
        public DateTime? InactivoDesde { get; set; }
        public string? CodigoSAP { get; set; }
    }
}
