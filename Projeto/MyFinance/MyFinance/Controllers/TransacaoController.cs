using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers
{
    public class TransacaoController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;

        public TransacaoController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            TransacaoModel objTransacao = new TransacaoModel(HttpContextAccessor);
            ViewBag.ListaTransacao = objTransacao.ListaTransacao();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(TransacaoModel form)
        {
            if (ModelState.IsValid)
            {
                form.HttpContextAccessor = HttpContextAccessor;
                form.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {
            if (id != null)
            {
                TransacaoModel objTransacao = new TransacaoModel(HttpContextAccessor);
                ViewBag.Registro = objTransacao.CarregarRegistro(id);
            }
            ViewBag.ListaPlanoContas = new PlanoContasModel(HttpContextAccessor).ListaPlanoContas();
            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            return View();
        }

        [HttpGet]
        public IActionResult ExcluirTransacao(int id)
        {
            
            TransacaoModel objTransacao = new TransacaoModel(HttpContextAccessor);
            ViewBag.Registro = objTransacao.CarregarRegistro(id);
            return View();
        }

        public IActionResult Excluir(int id)
        {
            TransacaoModel objTransacao = new TransacaoModel(HttpContextAccessor);
            objTransacao.Excluir(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Extrato(TransacaoModel formulario)
        {
            formulario.HttpContextAccessor = HttpContextAccessor;
            ViewBag.ListaTransacao = formulario.ListaTransacao();
            ViewBag.ListaContas = new ContaModel(HttpContextAccessor).ListaConta();
            return View();
        }

        public IActionResult Dashboard()
        {
            List<DashBoard> listaPie = new DashBoard(HttpContextAccessor).RetornarDadosGraficoPie();
            List<DashBoard> listaBar = new DashBoard(HttpContextAccessor).RetornarDadosGraficoBar();

            string valoresPie = "";
            string labelsPie = "";
            string coresPie = "";

            string valoresBar = "";
            string labelsBar = "";

            var random = new Random();

            for(int i = 0; i < listaBar.Count; i++)
            {
                valoresBar += listaBar[i].saldoConta.ToString() + ", ";
                labelsBar += "'" + listaBar[i].NomeConta.ToString() + "', ";
            }

            for (int i = 0; i < listaPie.Count; i++)
            {
                coresPie += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "', ";
                valoresPie += listaPie[i].Total.ToString() + ", ";
                labelsPie += "'" + listaPie[i].PlanoConta.ToString() + "', ";
            }

            ViewBag.ValoresPie = valoresPie;
            ViewBag.LabelsPie = labelsPie;
            ViewBag.CoresPie = coresPie;

            ViewBag.ValoresBar = valoresBar;
            ViewBag.LabelsBar = labelsBar;


            return View();
        }


    }
}
