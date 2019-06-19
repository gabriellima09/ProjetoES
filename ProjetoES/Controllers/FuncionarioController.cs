using ProjetoES.Facade;
using ProjetoES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoES.Controllers
{
    public class FuncionarioController : Controller
    {
        private Fachada fachada = new Fachada();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PvFuncionarios()
        {
            ConsultarCommand consultar = new ConsultarCommand();
            return PartialView(consultar.executar());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            var dataContratacao = funcionario.DataContratacao;
            var dataCadastro = funcionario.DataCadastro;

            SalvarCommand salvar = new SalvarCommand();
                salvar.executar(funcionario);

                return View("Index");
            
        }

        public ActionResult Edit(int id)
        {
            ConsultarCommand consultar = new ConsultarCommand();

            return View(consultar.executar(id));
        }

        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            try
            {
                AlterarCommand alterar = new AlterarCommand();
                alterar.executar(funcionario);

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
                ConsultarCommand consultar = new ConsultarCommand();

                return View(consultar.executar(id));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ActionResult TrocarStatus(int id, int status)
        {
            
                TrocarStatusCommand trocarStatus = new TrocarStatusCommand();

                trocarStatus.executar(id);

                return RedirectToAction("Details", new { id });
            

        }
    }
}