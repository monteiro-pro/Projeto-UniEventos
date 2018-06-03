using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public interface IDadosUsuario
    {
        void Inserir(Usuario usuario);
        void Deletar(int idUsuario);
        void Alterar(Usuario usuario);
        List<Usuario> Listar();
        Usuario SelectUsuario(int idUsuario);
        bool VerificarDuplicidade(string email);
        Usuario Logar(string emial, string senha);
    }
}
