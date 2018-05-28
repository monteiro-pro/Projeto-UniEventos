using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Basica
{
    public class Contrato
    {
        public int Idcontrato { set; get; }
        public int Idusuario { set; get; }
        public int Idservico { set; get; }

        public string Nome { set; get; }
        public string Tipo { set; get; }
        public string Empresa { set; get; }
        public int Valor { set; get; }
    }
}
