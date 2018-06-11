using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Basica
{
    [DataContract]
    public class Servico
    {
        [DataMember(IsRequired = true)]
        public Empresa EntEmpresa { get; set; }

        public Servico()
        {
            this.EntEmpresa = new Empresa();
        }

        [DataMember(IsRequired = true)]
        public int IdServico { set; get; }

        [DataMember(IsRequired = true)]
        public string TipoServico { set; get; }

        [DataMember(IsRequired = true)]
        public string Nome { set; get; }

        [DataMember(IsRequired = true)]
        public int Valor { set; get; }

        [DataMember(IsRequired = true)]
        public int IdUsuario { set; get; }

    }
}
