using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Dados.Conexao;
using Biblioteca.Negocio.Basica;

namespace Biblioteca.Dados.Acesso
{
    public class DadosUsuario : Conectar
    {
        public void Inserir(Usuario usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "INSERT INTO Usuario (tipoacesso,nome,telefone,email,senha) ";
                sql += "VALUES(@tipoacesso,@nome,@telefone,@email,@senha)";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@tipoacesso", SqlDbType.VarChar);
                cmd.Parameters["@tipoacesso"].Value = usuario.TipoAcesso;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = usuario.Nome;

                cmd.Parameters.Add("@telefone", SqlDbType.Int);
                cmd.Parameters["@telefone"].Value = usuario.Telefone;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = usuario.Email;

                cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                cmd.Parameters["@senha"].Value = usuario.Senha;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Inserir no Banco de Dados!" + ex.Message);
            }
        }

        public void Deletar(Usuario usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "DELETE INTO Usuario WHERE idusuario = @idusuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = usuario.IdUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch
            {
                throw new Exception("Erro ao Executar o Camando Deletar no Banco de Dados!");
            }
        }

        public void Alterar(Usuario usuario)
        {
            this.abrirConexao();
            string sql = "UPDATE Usuario SET nome = @nome, telefone = @telefone, email = @email, senha = @senha WHERE idusuario = @idusuario";
            SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

            cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            cmd.Parameters["@nome"].Value = usuario.Nome;

            cmd.Parameters.Add("@telefone", SqlDbType.Int);
            cmd.Parameters["@telefone"].Value = usuario.Telefone;

            cmd.Parameters.Add("@email", SqlDbType.VarChar);
            cmd.Parameters["@email"].Value = usuario.Email;

            cmd.Parameters.Add("@senha", SqlDbType.VarChar);
            cmd.Parameters["@senha"].Value = usuario.Senha;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            this.fecharConexao();
        }

        public List<Usuario> Listar()
        {
            List<Usuario> retorno = new List<Usuario>();

            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Usuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.TipoAcesso = DbReader.GetString(DbReader.GetOrdinal("tipoacesso"));
                    usuario.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    usuario.Telefone = DbReader.GetInt32(DbReader.GetOrdinal("telefone"));
                    usuario.Email = DbReader.GetString(DbReader.GetOrdinal("email"));
                    usuario.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    retorno.Add(usuario);
                }

                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch
            {
                throw new Exception("Erro ao Executar o Comando Listar no Banco!");
            }

            return retorno;
        }

        public bool VerificarDuplicidade(Usuario usuario)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                //## Mudar Para IdUsuario
                string sql = "SELECT idusuario, nome FROM Usuario WHERE nome = @nome";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = usuario.Nome;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }

                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch
            {
                throw new Exception("Erro ao Executar o Comando VerificarDuplicidade no Banco!");
            }

            return retorno;
        }
    }
}
