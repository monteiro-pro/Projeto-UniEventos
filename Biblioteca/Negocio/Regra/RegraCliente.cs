using Biblioteca.Dados.Acesso;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Regra
{
    public class RegraCliente
    {

        public void Validar(Cliente usuario)
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
        public void Inserir(Cliente usuario)
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

            new DadosCliente().Inserir(usuario);
        }

        public void Deletar(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Usuário Não Informado!");
            }

            new DadosCliente().Deletar(idUsuario);
        }

        public void Alterar(Cliente usuario)
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

            new DadosCliente().Alterar(usuario);
        }

        public List<Cliente> Listar()
        {
            return new DadosCliente().Listar();
        }

        public Cliente Logar(String nome, String senha)
        {
            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(senha))
            {
                throw new Exception("Valores do Parametro Não Informado!");
            }

            return new DadosCliente().Logar(nome, senha);
        }

        public Cliente SelectCliente(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Id Não Informado!");
            }

            return new DadosCliente().SelectCliente(idUsuario);

        }

        public bool VerificarDuplicidade(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("Email Não Informado!");
            }

            return new DadosCliente().VerificarDuplicidade(email);
        }
    }
}
