using Biblioteca.Dados.Acesso;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Regra
{
    public class RegraServico
    {
        public void Validar(Servico servicos)
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
        public void Inserir(Servico servicos)
        {
            if (servicos == null)
            {
                throw new Exception("Objeto Não Instanciado!");
            }

            Validar(servicos);

            new DadosServico().Inserir(servicos);
        }

        public void Deletar(int idServico)
        {
            if (idServico <= 0)
            {
                throw new Exception("Serviço Não Informado!");
            }

            if(new DadosServico().Deletar(idServico))
            {
                throw new Exception("Você Não Pode Excluir Um Serviço Que Está Sendo Usado Por Um Cliente!");
            }
            else
            {
                new DadosServico().Deletar(idServico);
            }
        }

        public Servico SelectServico(int idUsuario)
        {
            return new DadosServico().SelectServico(idUsuario);
        }

        public List<Servico> Listar()
        {
            return new DadosServico().Listar();
        }

        public List<Servico> Listar(int idServico)
        {
            return new DadosServico().Listar(idServico);
        }

        public List<Servico> Listar(string parametro)
        {
            if (parametro != "Entretenimento" && parametro != "Espaço" && parametro != "Alimento" && parametro != "Equipamento")
            {
                parametro = "%" + parametro + "%";
            }

            return new DadosServico().Listar(parametro);
        }
    }
}
