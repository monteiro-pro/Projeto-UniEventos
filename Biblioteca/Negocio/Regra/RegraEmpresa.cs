using Biblioteca.Dados.Acesso;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Regra
{
    public class RegraEmpresa
    {
        public void Validar(Empresa usuario)
        {
            if (String.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("Nome não Informado!");
            }

            if (String.IsNullOrEmpty(Convert.ToString(usuario.Telefone)))
            {
                throw new Exception("Telefone Não Infomado!");
            }

            if (String.IsNullOrEmpty(usuario.Email))
            {
                throw new Exception("Email Não Informado!");
            }

            if (String.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("Senha Não Informada!");
            }
        }
        public void Inserir(Empresa usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Objeto Não Instanciado!");
            }

            if (VerificarDuplicidade(usuario.Email) == true)
            {
                throw new Exception("Já Existe um Usuário Cadastrado Com Esse Email!");
            }

            Validar(usuario);

            new DadosEmpresa().Inserir(usuario);
        }

        public void Deletar(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Usuário Não Informado!");
            }

            new DadosEmpresa().Deletar(idUsuario);
        }

        public void Alterar(Empresa usuario, bool emailAtual)
        {
            if (usuario == null)
            {
                throw new Exception("Obejeto Não Instanciado!");
            }

            if (usuario.IdUsuario <= 0)
            {
                throw new Exception("Usuário Não Informado!");
            }

            Validar(usuario);

            if (VerificarDuplicidade(usuario.Email, emailAtual) == true)
            {
                throw new Exception("Já Existe um Usuário Cadastrado Com Esse Email!");
            }

            new DadosEmpresa().Alterar(usuario);
        }

        public List<Empresa> Listar()
        {
            return new DadosEmpresa().Listar();
        }

        public Empresa Logar(String nome, String senha)
        {
            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(senha))
            {
                throw new Exception("Valores do Parametro Não Informado!");
            }

            return new DadosEmpresa().Logar(nome, senha);
        }

        public Empresa SelectEmpresa(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Id Não Informado!");
            }

            return new DadosEmpresa().SelectEmpresa(idUsuario);

        }

        public bool VerificarDuplicidade(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("Email Não Informado!");
            }

            return new DadosEmpresa().VerificarDuplicidade(email);
        }

        public bool VerificarDuplicidade(string email, bool emailAtual)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("Email Não Informado!");
            }

            return new DadosEmpresa().VerificarDuplicidade(email, emailAtual);
        }
    }
}
