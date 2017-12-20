using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinaf.WebApi.Dominio
{
    /*Aqui a classe é POCO - Classe Pura*/
    public class Pessoa
    {
        public int cdpes { get; set; }
        public int tppes { get; set; }
        public string nrcgccpf { get; set; }
        public string nmpes { get; set; }
        public DateTime dtcad { get; set; }
        public DateTime dtnas { get; set; }
        public int tpsex { get; set; }

    }
}
