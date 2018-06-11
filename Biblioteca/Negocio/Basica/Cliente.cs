using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio.Basica
{
    [DataContract]
    public class Cliente
    {
        public readonly string TipoAcesso = "Cliente";

        [DataMember(IsRequired = true)]
        public int IdUsuario { get; set; }

        [DataMember(IsRequired = true)]
        public string Nome { get; set; }

        [DataMember(IsRequired = true)]
        public int Telefone { get; set; }

        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        [DataMember(IsRequired = true)]
        public string Senha { get; set; }
    }
}
