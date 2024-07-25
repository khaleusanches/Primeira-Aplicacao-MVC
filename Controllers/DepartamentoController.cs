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

        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.ID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ID, Nome")] Departamento departamento)
        {
            if(id != departamento.ID)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        public async Task<IActionResult> Details(long? id)
        {
            return View(await _context.Departamentos.SingleOrDefaultAsync(departamentos => departamentos.ID == id));
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return View(await _context.Departamentos.SingleOrDefaultAsync(departamentos => departamentos.ID == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(long? id)
        {
            var departamento = await _context.Departamentos.SingleOrDefaultAsync(departamentos => departamentos.ID == id);
            _context.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
