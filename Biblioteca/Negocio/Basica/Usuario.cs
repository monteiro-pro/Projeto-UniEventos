using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Basica
{
    public class Usuario
    {
        public string TipoAcesso { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdUsuario { get; set; }

    }
}
