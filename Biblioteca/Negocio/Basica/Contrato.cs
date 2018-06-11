using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Basica
{
    [DataContract]
    public class Contrato
    {
        public Contrato()
        {
            this.EntCliente = new Cliente();

            this.EntServico = new Servico();
        }

        [DataMember(IsRequired = true)]
        public int Idcontrato { set; get; }

        [DataMember(IsRequired = true)]
        public Cliente EntCliente { get; set; }

        [DataMember(IsRequired = true)]
        public Servico EntServico { get; set; }

    }
}
