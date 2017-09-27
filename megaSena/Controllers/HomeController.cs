using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using megaSena.Models;

namespace megaSena.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apostar(FormCollection fc)
        {
            Apostador apostador = new Apostador();

            apostador.apostadorID++;
            apostador.nomeApostador = fc.Get("nomeApostador");

            BancoDeDadosSimulado bd = BancoDeDadosSimulado.CriarConexaoComBancoDeDados();
            bd.ListaApostador.Add(apostador);

            return View();
        }

        [HttpPost]
        public MegaSena RegistrarAposta(FormCollection fc)
        {
            MegaSena jogo = new MegaSena();
            
            foreach (var key in fc.AllKeys)
            {                
                jogo.numerosAposta.Add(Convert.ToInt32(fc[key]));                
            }

            var query = jogo.numerosAposta.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            
            BancoDeDadosSimulado bd = BancoDeDadosSimulado.CriarConexaoComBancoDeDados();
            bd.ListaJogoMegaSena.Add(jogo);

            return jogo;

        }
    }
}