using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Fachada
{
    public class FachadaContrato
    {
        private RegraContrato Regra;
        public FachadaContrato()
        {
            Regra = new RegraContrato();
        }

        public void Inserir(Contrato contrato)
        {
            Regra.Inserir(contrato);
        }

        public void Deletar(int idContrato)
        {
            Regra.Deletar(idContrato);
        }

        public List<Contrato> Listar(int idUsuario)
        {
            return Regra.Listar(idUsuario);
        }
    }
}
