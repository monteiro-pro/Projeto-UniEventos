using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Basica
{
    public class Servicos
    {
        public int IdServico { set; get; }
        public int IdUsuario { set; get; }
        public string TipoServico { set; get; }
        public string Nome { set; get; }
        public int Valor { set; get; }
    }
}
