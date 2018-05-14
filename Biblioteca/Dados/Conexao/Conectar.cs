using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Conexao
{
    public class Conectar
    {
        public SqlConnection sqlConn;
        private const string local = "MONTEIRO_PC\\SQLEXPRESS";
        private const string banco = "UniEventos";
        private const string usuario = "MONTEIRO_PC\\SQLEXPRESS";
        private const string senha = "123";

        string connectionStringSqlServer = @"Data Source=" + local + ";Initial Catalog=" + banco + "; Integrated Security=true";
        public void abrirConexao()
        {
            this.sqlConn = new SqlConnection(connectionStringSqlServer);
            this.sqlConn.Open();
        }

        public void fecharConexao()
        {
            sqlConn.Close();
            sqlConn.Dispose();
        }

    }
}
