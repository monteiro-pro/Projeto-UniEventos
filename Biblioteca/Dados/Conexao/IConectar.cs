using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Conexao
{
    public interface IConectar
    {
        void abrirConexao();

        void fecharConexao();
    }
}
