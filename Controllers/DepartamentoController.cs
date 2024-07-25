using CasaCodigoCapitulo1.Data;
using CasaCodigoCapitulo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigoCapitulo1.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IESContext _context;
        
        public DepartamentoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos.OrderBy(c => c.Nome).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] Departamento departamento) // Indica que o metodo recebe o objeto departamento, porém usando o bind, ele puxa apenas a váriavel "Nome" do objeto.
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não	foi	possível	inserir	os dados.");
            }
            return View(departamento);
        }
    }
}
