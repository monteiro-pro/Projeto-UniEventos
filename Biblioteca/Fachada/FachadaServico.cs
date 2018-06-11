using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class FachadaServico
    {
        private RegraServico Regra;
        public FachadaServico()
        {
            Regra = new RegraServico();
        }
        public void Inserir(Servico servicos)
        {
            Regra.Inserir(servicos);
        }

        public void Deletar(int idServico)
        {
            Regra.Deletar(idServico);
        }

        public Servico SelectServico(int idUsuario)
        {
            return Regra.SelectServico(idUsuario);
        }

        public List<Servico> Listar()
        {
            return Regra.Listar();
        }

        public List<Servico> Listar(int idServico)
        {
           return Regra.Listar(idServico);
        }

        public List<Servico> Listar(string parametro)
        {
            return Regra.Listar(parametro);
        }
    }
}
