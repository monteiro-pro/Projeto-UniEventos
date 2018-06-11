using Biblioteca.Dados.Conexao;
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
                string sql = "INSERT INTO Contrato(nomeservico,tiposervico,nomeempresa,valor,idusuario,idservico) VALUES"
                + "(@nomeservico, @tiposervico, @nomeempresa, @valor, @idusuario, @idservico);";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@nomeservico", SqlDbType.VarChar);
                cmd.Parameters["@nomeservico"].Value = contrato.EntServico.Nome;

                cmd.Parameters.Add("@tiposervico", SqlDbType.VarChar);
                cmd.Parameters["@tiposervico"].Value = contrato.EntServico.TipoServico;

                cmd.Parameters.Add("@nomeempresa", SqlDbType.VarChar);
                cmd.Parameters["@nomeempresa"].Value = contrato.EntServico.EntEmpresa.Nome;

                cmd.Parameters.Add("@valor", SqlDbType.Int);
                cmd.Parameters["@valor"].Value = contrato.EntServico.Valor;

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = contrato.EntCliente.IdUsuario;

                cmd.Parameters.Add("@idservico", SqlDbType.Int);
                cmd.Parameters["@idservico"].Value = contrato.EntServico.IdServico;

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
                string sql = "SELECT * FROM Contrato;";
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);

                cmd.Parameters.Add("@idusuario", SqlDbType.Int);
                cmd.Parameters["@idusuario"].Value = idUsuario;

                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    Contrato contrato = new Contrato();
                    contrato.Idcontrato = DbReader.GetInt32(DbReader.GetOrdinal("idcontrato"));
                    contrato.NomeServico = DbReader.GetString(DbReader.GetOrdinal("nomeservico"));
                    contrato.TipoServico = DbReader.GetString(DbReader.GetOrdinal("tiposervico"));
                    contrato.NomeEmpresa = DbReader.GetString(DbReader.GetOrdinal("nomeempresa"));
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
