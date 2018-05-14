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
        public void Inserir(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Objeto Não Instanciado!");
            }

            if (String.IsNullOrEmpty(usuario.Nome))
            {
                throw new Exception("Nome não Informado!");
            }

            if (VerificarDuplicidade(usuario) == true)
            {
                throw new Exception("Usuário Não Existe no Banco!");
            }

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
        }

        public List<Usuario> Listar()
        {
            return new DadosUsuario().Listar();
        }

        public bool VerificarDuplicidade(Usuario usuario)
        {
            new DadosUsuario().VerificarDuplicidade(usuario);

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
    }
}
