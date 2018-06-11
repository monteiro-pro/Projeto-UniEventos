using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public interface IDadosServicos
    {
        void Inserir(Servico servico);
        bool Deletar(int idServico);
        Servico SelectServico(int idUsuario);
        List<Servico> Listar();
        List<Servico> Listar(int idUsuario);
        List<Servico> Listar(string parametro);
    }
}
