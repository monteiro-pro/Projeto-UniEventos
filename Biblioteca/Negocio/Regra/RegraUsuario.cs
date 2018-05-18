using Biblioteca.Dados.Acesso;
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
            if (usuario.TipoAcesso != "Empresa" || usuario.TipoAcesso != "Cliente")
            {
                throw new Exception("Tipo de Acesso Não Informado!");
            }

            if (String.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("Nome não Informado!");
            }

            if (String.IsNullOrEmpty(usuario.Email))
            {
                throw new Exception("Email Não Informado!");
            }

            if (VerificarDuplicidade(usuario) == true)
            {
                throw new Exception("Já Existe um Usuário Cadastrado Com Esse Email!");
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

            Validar(usuario);

            new DadosUsuario().Inserir(usuario);
        }

        public void Deletar(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new Exception("Obejeto Não Instanciado!");
            }

            if (usuario.IdUsuario <= 0)
            {
                throw new Exception("Usuário Não Informado!");
            }

            if (VerificarDuplicidade(usuario)==false)
            {
                throw new Exception("Usuário Não Existe no Banco!");
            }

            new DadosUsuario().Deletar(usuario);
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

            if (VerificarDuplicidade(usuario) == false)
            {
                throw new Exception("Usuário Não Existe no Banco!");
            }

            new DadosUsuario().Alterar(usuario);

            Validar(usuario);
        }

        public List<Usuario> Listar()
        {
            return new DadosUsuario().Listar();
        }

        public bool VerificarDuplicidade(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Obejeto Não Instanciado!");
            }

            // ## Mudar Para IdUsuario!!
            if (String.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("Usuário Não Informado!");
            }

            return new DadosUsuario().VerificarDuplicidade(usuario);
        }

        public Usuario Logar(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new Exception("Usuário Não Instanciado!");
            }

            if (String.IsNullOrEmpty(usuario.Email))
            {
                throw new Exception("Propiedade Email Vazia!");
            }

            if (String.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("Propiedade Senha Vazia!");
            }

            return new DadosUsuario().Logar(usuario);
        }
    }
}
