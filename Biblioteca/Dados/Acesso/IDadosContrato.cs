using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Dados.Acesso
{
    public interface IDadosContrato
    {
        void Inserir(Contrato contrato);
        void Deletar(int idContrato);
        List<Contrato> Listar(int idUsuario);
    }
}
