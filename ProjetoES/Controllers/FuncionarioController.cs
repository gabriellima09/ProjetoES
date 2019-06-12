using ProjetoES.Command;
using ProjetoES.Models;
using System;
using System.Web.Mvc;

namespace ProjetoES.Controllers
{
    public class FuncionarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PvFuncionarios()
        {
            return PartialView(new ConsultarCommand().Executar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            try
            {
                new SalvarCommand().Executar(funcionario);

                return View("Index");
            }
            catch (Exception error)
            {
                return View("Error");
            }

        }

        public ActionResult Edit(int id)
        {
            return View(new ConsultarCommand().Executar(id));
        }

        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            try
            {
                new AlterarCommand().Executar(funcionario);

                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                return View(new ConsultarCommand().Executar(id));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ActionResult TrocarStatus(int id, int status)
        {
            try
            {
                new TrocarStatusCommand().Executar(id, status);

                return RedirectToAction("Details", new { id });
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}