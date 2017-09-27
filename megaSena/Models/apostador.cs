using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace megaSena.Models
{
    public class Apostador
    {
        public int apostadorID { get; set; }

        [Required(ErrorMessage = "Informe o nome do apostador", AllowEmptyStrings = false)]
        public string nomeApostador { get; set; }

        public List<MegaSena> jogos { get; set; }
    }
}