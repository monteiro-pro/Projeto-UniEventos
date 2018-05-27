using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class FachadaServicos
    {
        private RegraServicos regra;
        public FachadaServicos()
        {
            regra = new RegraServicos();
        }
        public void Inserir(Servicos servicos)
        {
            regra.Inserir(servicos);
        }

        public void Deletar(Servicos servicos)
        {
            regra.Deletar(servicos);
        }

        public List<Servicos> Listar(int idServico)
        {
           return regra.Listar(idServico);
        }
    }
}
