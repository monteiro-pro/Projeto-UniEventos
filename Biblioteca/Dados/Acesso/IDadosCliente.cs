using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public interface IDadosCliente
    {
        void Inserir(Cliente usuario);
        void Deletar(int idUsuario);
        void Alterar(Cliente usuario);
        List<Cliente> Listar();
        Cliente SelectCliente(int idUsuario);
        bool VerificarDuplicidade(string email);
        Cliente Logar(string emial, string senha);

    }
}
