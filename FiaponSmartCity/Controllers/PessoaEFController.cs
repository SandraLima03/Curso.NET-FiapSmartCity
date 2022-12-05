using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapSmartCity.Controllers
{
    public class PessoaEFController : Controller
    {
        private readonly PessoaRepositoryEF PessoaRepositoryEF;
        //private readonly PessoaRepository PessoaRepository;

        public PessoaEFController()
        {
            PessoaRepositoryEF = new PessoaRepositoryEF();
            //PessoaRepository = new PessoaRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoa = PessoaRepositoryEF.Listar();
            return View(listaPessoa);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new PessoaEF());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.PessoaEF PessoaEF)
        {
            if (ModelState.IsValid)
            {
                PessoaRepositoryEF.Inserir(PessoaEF);

                @TempData["mensagem"] = "Pessoa cadastrada com sucesso!";
                return RedirectToAction("Index", "PessoaEF");

            }
            else
            {
                return View(PessoaEF);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var PessoaEF = PessoaRepositoryEF.Consultar(Id);
            return View(PessoaEF);
        }

        [HttpPost]
        public ActionResult Editar(Models.PessoaEF PessoaEF)
        {

            if (ModelState.IsValid)
            {
                PessoaRepositoryEF.Alterar(PessoaEF);

                @TempData["mensagem"] = "Pessoa alterada com sucesso!";
                return RedirectToAction("Index", "PessoaEF");
            }
            else
            {
                return View(PessoaEF);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var PessoaEF = PessoaRepositoryEF.Consultar(Id);
            return View(PessoaEF);
        }

        //[HttpGet]
        //public ActionResult ConsultarPessoa(int Id)
        //{
            //var Pessoa = PessoaRepository.Consultar(Id);
            //return View(Pessoa);
        //}


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            PessoaRepositoryEF.Excluir(Id);

            @TempData["mensagem"] = "Pessoa removida com sucesso!";

            return RedirectToAction("Index", "PessoaEF");
        }
    }
}
