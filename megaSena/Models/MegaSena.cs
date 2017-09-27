using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace megaSena.Models
{
    public class MegaSena : IJogo
    {
        public int jogoID { get; set; }
        public DateTime dataAposta { get; set; }

        [Range(1, 60, ErrorMessage = "Selecione números entre 1 e 60.")]
        public List<int> numerosAposta { get; set; }

        public MegaSena()
        {
            int ultJogo = 0;

            BancoDeDadosSimulado bd = BancoDeDadosSimulado.CriarConexaoComBancoDeDados();

            if (bd.ListaJogoMegaSena.LastOrDefault() != null)
            {
                ultJogo = bd.ListaJogoMegaSena.LastOrDefault().jogoID;
            }

            if (ultJogo == 0) this.jogoID++;
            else
                this.jogoID = ultJogo++;
            
            this.dataAposta = DateTime.Now;            
        }

        public MegaSena JogoAutomatico()
        {
            try
            {
                // Faz um jogo automatizado

                MegaSena jogo = new MegaSena();

                jogo.jogoID++;
                jogo.dataAposta = DateTime.Now;

                // Gera números aleatoriamente

                Random rnd = new Random();

                for (int cnt = 0; cnt < 6; cnt++)
                {
                    jogo.numerosAposta.Add(rnd.Next(1, 60));
                }

                return jogo;

            }        
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}