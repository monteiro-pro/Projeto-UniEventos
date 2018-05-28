﻿using Biblioteca.Negocio.Basica;
using Biblioteca.Dados.Conexao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public class DadosServico : Conectar
    {
        public void Inserir(Servico servicos)
        {
            try
            {
                this.abrirConexao();
                string sql = "INSERT INTO Servicos (idusuario,tiposervico,nome,valor) ";
                sql += "VALUES(@idusuario,@tiposervico,@nome,@valor);";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.VarChar);
                cmd.Parameters["@idusuario"].Value = servicos.IdUsuario;

                cmd.Parameters.Add("@tiposervico", SqlDbType.VarChar);
                cmd.Parameters["@tiposervico"].Value = servicos.TipoServico;

                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = servicos.Nome;

                cmd.Parameters.Add("@valor", SqlDbType.Int);
                cmd.Parameters["@valor"].Value = servicos.Valor;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Inserir no Banco de Dados!" + ex.Message);
            }
        }

        public void Deletar(int idServico)
        {
            try
            {
                this.abrirConexao();
                string sql = "DELETE Servicos WHERE idservico = @idservico;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idservico", SqlDbType.Int);
                cmd.Parameters["@idservico"].Value = idServico;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch
            {
                throw new Exception("Erro ao Executar o Camando Deletar no Banco de Dados!");
            }
        }

        public List<Servico> Listar()
        {
            List<Servico> retorno = new List<Servico>();

            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Servicos;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Servico servico = new Servico();
                    servico.IdServico = DbReader.GetInt32(DbReader.GetOrdinal("idservico"));
                    servico.TipoServico = DbReader.GetString(DbReader.GetOrdinal("tiposervico"));
                    servico.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    servico.Valor = DbReader.GetInt32(DbReader.GetOrdinal("valor"));
                    retorno.Add(servico);
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

        public List<Servico> Listar(int idUsuario)
        {
            List<Servico> retorno = new List<Servico>();

            try
            {
                this.abrirConexao();
                string sql = "SELECT * FROM Servicos WHERE idusuario = @idusuario;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = idUsuario;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Servico servico = new Servico();
                    servico.TipoServico = DbReader.GetString(DbReader.GetOrdinal("tiposervico"));
                    servico.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    servico.Valor = DbReader.GetInt32(DbReader.GetOrdinal("valor"));
                    retorno.Add(servico);
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
    }
}