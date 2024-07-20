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

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao) 
        {
            for (int i = 0; i < instituicoes.Count; i ++)
            {
                if (instituicoes[i].InstituicaoID == instituicao.InstituicaoID)
                {
                    instituicoes[i] = instituicao;
                }
            }
            //instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            //instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Delete(long id) 
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            for(int i = 0; i < instituicoes.Count; i++)
            {
                if(instituicao.InstituicaoID == instituicoes[i].InstituicaoID)
                {
                    instituicoes.Remove(instituicoes[i]);
                }
            }
            //instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }
    }
}
