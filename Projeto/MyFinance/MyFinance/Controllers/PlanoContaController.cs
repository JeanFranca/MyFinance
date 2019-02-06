using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class PlanoContaController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;

        public PlanoContaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            PlanoContasModel objPlanoConta = new PlanoContasModel(HttpContextAccessor);
            ViewBag.ListaPlanoContas = objPlanoConta.ListaPlanoContas();
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContasModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if(id != null)
            {
                PlanoContasModel objPlanoContas = new PlanoContasModel(HttpContextAccessor);
                ViewBag.Registro = objPlanoContas.CarregarRegistro(id);
            }
            return View();
        }

        public IActionResult ExcluirPlanoConta(int id)
        {
            PlanoContasModel objPlanoConta = new PlanoContasModel(HttpContextAccessor);
            objPlanoConta.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}