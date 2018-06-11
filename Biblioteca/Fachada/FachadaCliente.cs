using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class FachadaCliente
    {

        private RegraCliente Regra;
        public FachadaCliente()
        {
            Regra = new RegraCliente();
        }

        public void Inserir(Cliente usuario)
        {
            Regra.Inserir(usuario);
        }

        public void Deletar(int idUsuario)
        {
            Regra.Deletar(idUsuario);
        }

        public void Alterar(Cliente usuario, bool emailAtual)
        {
            Regra.Alterar(usuario, emailAtual);
        }

        public void validar(Cliente usuario)
        {
            Regra.Validar(usuario);
        }

        public List<Cliente> Listar()
        {
            return Regra.Listar();
        }

        public Cliente Logar(String nome, String senha)
        {
            return Regra.Logar(nome, senha);
        }

        public Cliente SelectCliente(int idUsuario)
        {
            return Regra.SelectCliente(idUsuario);
        }

    }
}
