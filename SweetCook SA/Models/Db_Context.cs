using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    public class Db_Context:DbContext
    {
        public Db_Context():base("SweetCook_SA")
        {

        }
        public DbSet<DepartamentoSucursal> departamentoSucursales { get; set; }
        public DbSet<DepartamentoRecibe> departamentoReciben {get; set; }
        public DbSet<Sucursal> sucursales { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Envia> envias { get; set; }
        public DbSet<Recibe> reciben { get; set; }
    }
}