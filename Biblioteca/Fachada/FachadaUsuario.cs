using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class FachadaUsuario
    {
        private RegraUsuario regra;
        public FachadaUsuario()
        {
            regra = new RegraUsuario();
        }
        
        public void Inserir(Usuario usuario)
        {
            regra.Inserir(usuario);
        }

        public void Deletar(Usuario usuario)
        {
            regra.Deletar(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            regra.Alterar(usuario);
        }

        public List<Usuario> Listar()
        {
            return regra.Listar();
        }

        public Usuario Logar(Usuario usuario)
        {
            return regra.Logar(usuario);
        }
    }
}
