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
    public class DadosEmpresa : Conectar, IDadosEmpresa
    {
        public void Inserir(Empresa usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "INSERT INTO Empresa (nome,telefone,email,senha) "
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
            bool checar = false;

            try
            {
                this.abrirConexao();
                string sql = "SELECT Servicos.idservico FROM Servicos INNER JOIN Contrato ON Servicos.idservico = " +
                "Contrato.idservico INNER JOIN Empresa ON Contrato.idusuario = Empresa.idusuario WHERE Servicos.idusuario = @idusuario;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = idUsuario;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    checar = true;
                    break;
                }

                DbReader.Close();
                cmd.Dispose();

                if (checar)
                {
                    sql = "DELETE Contrato FROM Servicos INNER JOIN Contrato ON Servicos.idservico = Contrato.idservico " +
                        "INNER JOIN Empresa ON Contrato.idusuario = Empresa.idusuario WHERE Servicos.idusuario = @idusuario;";

                    cmd.CommandText = sql;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                sql = "DELETE Empresa WHERE idusuario = @idusuario;";

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Camando Deletar no Banco de Dados!" + ex);
            }
        }

        public void Alterar(Empresa usuario)
        {
            try
            {
                this.abrirConexao();
                string sql = "UPDATE Empresa SET nome = @nome, telefone = @telefone, email = @email, senha = @senha WHERE idusuario = @idusuario";
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

        public List<Empresa> Listar()
        {
            List<Empresa> retorno = new List<Empresa>();

            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Empresa;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Empresa usuario = new Empresa();
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

        public Empresa SelectEmpresa(int idUsuario)
        {
            Empresa retorno = new Empresa();
            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Empresa WHERE idUsuario = " + idUsuario + ";";
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
                throw new Exception("Erro ao Executar o Comando SelectUsuario no Banco!" + ex);
            }

            return retorno;
        }

        public bool VerificarDuplicidade(string email)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
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

                if (retorno == false)
                {
                    sql = "SELECT idusuario, nome FROM Cliente WHERE email = @email;";
                    cmd.CommandText = sql;

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

        public Empresa Logar(String nome, String senha)
        {
            Empresa retorno = new Empresa();
            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Empresa WHERE email = @email AND senha = @senha;";
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
