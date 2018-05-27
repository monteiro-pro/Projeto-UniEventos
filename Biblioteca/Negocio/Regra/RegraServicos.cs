using Biblioteca.Dados.Acesso;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Regra
{
    public class RegraServicos
    {
        public void Validar(Servicos servicos)
        {
            if (servicos.TipoServico != "Entretenimento" && servicos.TipoServico != "Espaço" && servicos.TipoServico != "Equipamento" && servicos.TipoServico != "Alimento")
            {
                throw new Exception("Tipo de Serviço Não Informado!");
            }

            if (String.IsNullOrEmpty(servicos.TipoServico))
            {
                throw new Exception("Tipo de Acesso não Informado!");
            }

            if (String.IsNullOrEmpty(servicos.Nome))
            {
                throw new Exception("Nome Não Informado!");
            }

            if (servicos.Valor <= 0)
            {
                throw new Exception("Valor Não Informado!");
            }
        }
        public void Inserir(Servicos servicos)
        {
            if (servicos == null)
            {
                throw new Exception("Objeto Não Instanciado!");
            }

            new DadosServicos().Inserir(servicos);

            Validar(servicos);
        }

        public void Deletar(Servicos servicos)
        {
            if (servicos == null)
            {
                throw new Exception("Obejeto Não Instanciado!");
            }

            if (servicos.IdUsuario <= 0)
            {
                throw new Exception("Serviço Não Informado!");
            }

            new DadosServicos().Deletar(servicos);
        }

        public List<Servicos> Listar(int idServico)
        {
            return new DadosServicos().Listar(idServico);
        }
    }
}
