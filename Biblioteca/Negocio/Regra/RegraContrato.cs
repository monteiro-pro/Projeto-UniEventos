using Biblioteca.Dados.Acesso;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Regra
{
    public class RegraContrato
    {
        private DadosContrato AcessoContrato;
        public RegraContrato()
        {
            AcessoContrato = new DadosContrato();
        }

        public void Validar(Contrato contrato)
        {
            if(contrato.EntCliente.IdUsuario <= 0)
            {
                throw new Exception("Id do Usuário Não Informado!");
            }

            if(contrato.EntServico.IdServico <= 0)
            {
                throw new Exception("Id do Serviço Não Informado!");
            }
        }

        public void Inserir(Contrato contrato)
        {
            if(contrato == null)
            {
                throw new Exception("Objeto não Instanciado!");
            }

            Validar(contrato);

            AcessoContrato.Inserir(contrato);
        }

        public void Deletar(int idContrato)
        {
            if(idContrato <= 0)
            {
                throw new Exception("Contrato Não Infomado!");
            }

            AcessoContrato.Deletar(idContrato);
        }

        public List<Contrato> Listar(int idUsuario)
        {
            return AcessoContrato.Listar(idUsuario);
        }
    }
}
