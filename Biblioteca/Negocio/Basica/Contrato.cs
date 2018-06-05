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
        [DataMember(IsRequired = true)]
        public int Idcontrato { set; get; }

        [DataMember(IsRequired = true)]
        public int Idusuario { set; get; }

        [DataMember(IsRequired = true)]
        public int Idservico { set; get; }

        [DataMember(IsRequired = true)]
        public string Nome { set; get; }
        [DataMember(IsRequired = true)]
        public string Tipo { set; get; }
        [DataMember(IsRequired = true)]
        public string Empresa { set; get; }
        [DataMember(IsRequired = true)]
        public int Valor { set; get; }
    }
}
