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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PvFuncionarios()
        {
            return PartialView(Fachada.Consultar());
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
                Fachada.Cadastrar(funcionario);

                return View("Index");
            }catch(Exception error) {
                return View("Error");
            }
            
        }

        public ActionResult Edit(int id)
        {
            return View(Fachada.ConsultarPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            try
            {
                Fachada.Alterar(funcionario);

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
                return View(Fachada.ConsultarPorId(id));
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
                if (status == 1)
                {
                    Fachada.InativarFuncionario(id);
                }
                else
                {
                    Fachada.AtivarFuncionario(id);
                }

                return RedirectToAction("Details", new { id });
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}