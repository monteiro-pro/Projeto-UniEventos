﻿using Biblioteca.Dados.Conexao;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public class DadosContrato : Conectar, IDadosContrato
    {
        public void Inserir(Contrato contrato)
        {
            try
            {
                this.abrirConexao();
                string sql = "INSERT INTO Contrato(idusuario,idservico) VALUES (@idusuario, @idservico);";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = contrato.Idusuario;

                cmd.Parameters.Add("@idservico", SqlDbType.Int);
                cmd.Parameters["@idservico"].Value = contrato.Idservico;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Inserir no Banco de Dados!" + ex);
            }
        }

        public void Deletar(int idContrato)
        {
            try
            {
                this.abrirConexao();
                string sql = "DELETE Contrato WHERE idcontrato = @idcontrato;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idcontrato", SqlDbType.Int);
                cmd.Parameters["@idcontrato"].Value = idContrato;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Executar o Camando Deletar no Banco de Dados!" + ex);
            }
        }

        public List<Contrato> Listar(int idUsuario)
        {
            List<Contrato> retorno = new List<Contrato>();

            try
            {
                this.abrirConexao();
                string sql = "SELECT Contrato.idcontrato, Servicos.nome, Servicos.tiposervico, Usuario.nome AS 'nomeusu', Servicos.valor FROM Servicos INNER JOIN Contrato ON Servicos.idservico = Contrato.idservico ";
                sql += "INNER JOIN Usuario ON Contrato.idusuario = Usuario.idusuario WHERE Contrato.idusuario = @idUsuario;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = idUsuario;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Contrato contrato = new Contrato();
                    contrato.Idcontrato = DbReader.GetInt32(DbReader.GetOrdinal("idcontrato"));
                    contrato.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    contrato.Tipo = DbReader.GetString(DbReader.GetOrdinal("tiposervico"));
                    contrato.Empresa = DbReader.GetString(DbReader.GetOrdinal("nomeusu"));
                    contrato.Valor = DbReader.GetInt32(DbReader.GetOrdinal("valor"));
                    retorno.Add(contrato);
                }

                DbReader.Close();
                cmd.Dispose();
                this.fecharConexao();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Executar o Comando Listar no Banco!" + ex);
            }

            return retorno;
        }
    }
}
