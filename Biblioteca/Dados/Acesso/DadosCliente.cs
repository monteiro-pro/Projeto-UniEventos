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
    public class DadosCliente : Conectar, IDadosCliente
    {
        public void Inserir(Cliente usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "INSERT INTO Cliente (nome,telefone,email,senha) "
                + "VALUES(@nome,@telefone,@email,@senha)";
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Inserir no Banco de Dados!" + ex);
            }
        }

        public void Deletar(int idUsuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "DELETE FROM Cliente WHERE idusuario = @idusuario;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = idUsuario;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Camando Deletar no Banco de Dados!" + ex);
            }
        }

        public void Alterar(Cliente usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "UPDATE Cliente SET nome = @nome, telefone = @telefone, email = @email, senha = @senha WHERE idusuario = @idusuario";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idUsuario", SqlDbType.Int);
                cmd.Parameters["@idUsuario"].Value = usuario.IdUsuario;

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
                throw new Exception("Erro ao Executar o Camando Alterar no Banco de Dados!" + ex);
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> retorno = new List<Cliente>();

            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Cliente;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Cliente usuario = new Cliente();
                    usuario.IdUsuario = DbReader.GetInt32(DbReader.GetOrdinal("idusuario"));
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Listar no Banco!" + ex);
            }

            return retorno;
        }

        public Cliente SelectCliente(int idUsuario)
        {
            Cliente retorno = new Cliente();
            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Cliente WHERE idUsuario = " + idUsuario + ";";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    retorno.IdUsuario = DbReader.GetInt32(DbReader.GetOrdinal("idusuario"));
                    retorno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    retorno.Telefone = DbReader.GetInt32(DbReader.GetOrdinal("telefone"));
                    retorno.Email = DbReader.GetString(DbReader.GetOrdinal("email"));
                    retorno.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    break;
                }

                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando SelectCliente no Banco!" + ex);
            }

            return retorno;
        }

        public bool VerificarDuplicidade(string email)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                string sql = "SELECT idusuario, nome FROM Cliente WHERE email = @email;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }
                DbReader.Close();

                if (retorno == false)
                {
                    sql = "SELECT idusuario, nome FROM Empresa WHERE email = @email;";
                    cmd.CommandText = sql;
                    DbReader = cmd.ExecuteReader();

                    while (DbReader.Read())
                    {
                        retorno = true;
                        break;
                    }
                }
               
                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando VerificarDuplicidade no Banco!" + ex);
            }

            return retorno;
        }

        public bool VerificarDuplicidade(string email, bool emailAtual)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();

                if (emailAtual)
                {
                    string sql = "SELECT idusuario, nome FROM Cliente WHERE email = @email;";
                    SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;

                    SqlDataReader DbReader = cmd.ExecuteReader();

                    while (DbReader.Read())
                    {
                        retorno = true;
                        break;
                    }
                    DbReader.Close();

                    if (retorno == false)
                    {
                        sql = "SELECT idusuario, nome FROM Empresa WHERE email = @email;";
                        cmd.CommandText = sql;
                        DbReader = cmd.ExecuteReader();

                        while (DbReader.Read())
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
                else
                {
                    string sql = "SELECT idusuario, nome FROM Empresa WHERE email = @email;";
                    SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = email;

                    SqlDataReader DbReader = cmd.ExecuteReader();

                    while (DbReader.Read())
                    {
                        retorno = true;
                        break;
                    }
                    DbReader.Close();
                    cmd.Dispose();
                }

                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando VerificarDuplicidade no Banco!" + ex);
            }

            return retorno;
        }

        public Cliente Logar(String nome, String senha)
        {
            Cliente retorno = new Cliente();
            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Cliente WHERE email = @email AND senha = @senha;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = nome;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                cmd.Parameters["@senha"].Value = senha;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    retorno.IdUsuario = DbReader.GetInt32(DbReader.GetOrdinal("idusuario"));
                    retorno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    retorno.Telefone = DbReader.GetInt32(DbReader.GetOrdinal("telefone"));
                    retorno.Email = DbReader.GetString(DbReader.GetOrdinal("email"));
                    retorno.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    break;
                }

                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Logar no Banco!" + ex);
            }

            return retorno;
        }
    }
}
