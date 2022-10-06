using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreTienda { get; set; }
        public int Telefono { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }

        // Recibe llave primaria
        public DepartamentoSucursal TablaDepartamentoSucursal { get; set; }
        public int DepartamentoSucursalId { get; set; }

        // Envia llave primaria
        public ICollection<Envia> TablaEnvia { get; set; }
    }
}