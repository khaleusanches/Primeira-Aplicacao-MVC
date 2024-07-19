using CasaCodigoCapitulo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaCodigoCapitulo1.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "UniParaná",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoID = 2,
                Nome = "UniSanta",
                Endereco = "Paraná"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instuicao)
        {
            instituicoes.Add(instuicao);
            instuicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }
    }
}
