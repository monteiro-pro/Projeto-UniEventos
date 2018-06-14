using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class FachadaEmpresa
    {
        private RegraEmpresa Regra;
        public FachadaEmpresa()
        {
            Regra = new RegraEmpresa();
        }

        public void Inserir(Empresa usuario)
        {
            Regra.Inserir(usuario);
        }

        public void Deletar(int idUsuario)
        {
            Regra.Deletar(idUsuario);
        }

        public void Alterar(Empresa usuario, bool emailAtual)
        {
            Regra.Alterar(usuario, emailAtual);
        }

        public void validar(Empresa usuario)
        {
            Regra.Validar(usuario);
        }

        public List<Empresa> Listar()
        {
            return Regra.Listar();
        }

        public Empresa Logar(String nome, String senha)
        {
            return Regra.Logar(nome, senha);
        }

        public Empresa SelectEmpresa(int idUsuario)
        {
            return Regra.SelectEmpresa(idUsuario);
        }
    }
}
