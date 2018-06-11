using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public interface IDadosEmpresa
    {
        void Inserir(Empresa usuario);
        void Deletar(int idUsuario);
        void Alterar(Empresa usuario);
        List<Empresa> Listar();
        Empresa SelectEmpresa(int idUsuario);
        bool VerificarDuplicidade(string email);
        Empresa Logar(string emial, string senha);
    }
}
