using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TechNovaSolutions.Models;

namespace TechNovaSolutions.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<TicketSoporte> TicketsSoporte { get; set; }
    }

    public class TicketSoporte
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        [StringLength(150)]
        public string Asunto { get; set; }

        [Required]
        public string Mensaje { get; set; }

        public string Estado { get; set; } = "Abierto";

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}