﻿using Biblioteca.Dados.Acesso;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Regra
{
    public class RegraUsuario
    {
        public void Validar(Usuario usuario)
        {
            if (usuario.TipoAcesso != "Empresa" && usuario.TipoAcesso != "Cliente")
            {
                throw new Exception("Tipo de Acesso Não Informado!");
            }

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
        public void Inserir(Usuario usuario)
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

            new DadosUsuario().Inserir(usuario);
        }

        public void Deletar(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Usuário Não Informado!");
            }

            new DadosUsuario().Deletar(idUsuario);
        }

        public void Alterar(Usuario usuario)
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

            new DadosUsuario().Alterar(usuario);
        }

        public List<Usuario> Listar()
        {
            return new DadosUsuario().Listar();
        }

        public Usuario Logar(String nome, String senha)
        {
            if(String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(senha))
            {
                throw new Exception("Valores do Parametro Não Informado!");
            }

            return new DadosUsuario().Logar(nome, senha);
        }

        public Usuario SelectUsuario(int idUsuario)
        {
            if(idUsuario <= 0)
            {
                throw new Exception("Id Não Informado!");
            }

            return new DadosUsuario().SelectUsuario(idUsuario);

        }

        public bool VerificarDuplicidade(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new Exception("Email Não Informado!");
            }

            return new DadosUsuario().VerificarDuplicidade(email);
        }
    }
}
