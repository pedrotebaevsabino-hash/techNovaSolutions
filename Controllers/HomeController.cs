using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechNovaSolutions.Data;
using TechNovaSolutions.Models;

namespace TechNovaSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Página Principal: Muestra productos (E-commerce)
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        // Vista de la Mesa de Ayuda (Módulo 4 - ITIL)
        public IActionResult Soporte()
        {
            return View();
        }

        // Procesar el Ticket de Soporte enviado por el cliente
        [HttpPost]
        public async Task<IActionResult> CrearTicket(TicketSoporte ticket)
        {
            if (ModelState.IsValid)
            {
                _context.TicketsSoporte.Add(ticket);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "¡Ticket creado con éxito! Nuestro equipo de soporte lo atenderá bajo el ciclo ITIL.";
                return RedirectToAction(nameof(Soporte));
            }
            return View("Soporte", ticket);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}