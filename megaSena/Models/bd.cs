using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace megaSena.Models
{
    public class BancoDeDadosSimulado
    {
        // Criar uma propriedade que simula uma LISTA do objeto desejado -- TO DO: CRIAR UMA PROPRIEDADE PARA CADA TABELA/OBJETO
        public IList<MegaSena>  ListaJogoMegaSena   { get; set; }
        public IList<Apostador> ListaApostador      { get; set; }

        #region Codigo para simular carga do banco de dados

        private BancoDeDadosSimulado()
        {
            // Criar uma tabela em memoria -- TO DO: Criar tabelas
            this.ListaJogoMegaSena = new List<MegaSena>();
            this.ListaApostador = new List<Apostador>();
        }

        /// <summary>
        /// Método para carregar o banco de dados em memória.
        /// NÃO PRECISA ALTERAR ESTE MÉTODO
        /// </summary>
        /// <returns></returns>
        public static BancoDeDadosSimulado CriarConexaoComBancoDeDados()
        {
            BancoDeDadosSimulado banco = HttpContext.Current.Session["bd"] as BancoDeDadosSimulado;
            if (banco == null)
                HttpContext.Current.Session["bd"] = new BancoDeDadosSimulado();

            return HttpContext.Current.Session["bd"] as BancoDeDadosSimulado;
        }

        /// <summary>
        /// Limpar a memória
        /// NÃO PRECISA ALTERAR ESTE MÉTODO
        /// </summary>
        public void LimparBanco()
        {
            HttpContext.Current.Session["bd"] = null;
        }

        #endregion
    }
}