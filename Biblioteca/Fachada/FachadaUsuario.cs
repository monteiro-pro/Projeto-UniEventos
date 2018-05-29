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
        private RegraUsuario Regra;
        public FachadaUsuario()
        {
            Regra = new RegraUsuario();
        }
        
        public void Inserir(Usuario usuario)
        {
            Regra.Inserir(usuario);
        }

        public void Deletar(int idUsuario)
        {
            Regra.Deletar(idUsuario);
        }

        public void Alterar(Usuario usuario)
        {
            Regra.Alterar(usuario);
        }

        public void validar(Usuario usuario)
        {
            Regra.Validar(usuario);
        }

        public List<Usuario> Listar()
        {
            return Regra.Listar();
        }

        public Usuario Logar(String nome, String senha)
        {
            return Regra.Logar(nome, senha);
        }

        public Usuario SelectUsuario(int idUsuario)
        {
            return Regra.SelectUsuario(idUsuario);
        }
    }
}
