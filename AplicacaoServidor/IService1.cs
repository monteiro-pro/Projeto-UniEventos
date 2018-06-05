using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AplicacaoServidor
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void InsertUsuario(Usuario usuario);

        [OperationContract]
        void DeleteUsuario(int idUsuario);

        [OperationContract]
        void AlterarUsuario(Usuario usuario);

        [OperationContract]
        List<Usuario> ListarUsuario();

        [OperationContract]
        Usuario SelectUsuarioUsuario(int idUsuario);

        [OperationContract]
        Usuario LogarUsuario(string emial, string senha);


        [OperationContract]
        void InserirServico(Servico servico);

        [OperationContract]
        void DeletarServico(int idServico);

        [OperationContract]
        List<Servico> ListarServico();

        [OperationContract]
        List<Servico> ListarServicoID(int idUsuario);

        [OperationContract]
        List<Servico> ListarServicoPA(string parametro);



        [OperationContract]
        void InserirContrato(Contrato contrato);

        [OperationContract]
        void DeletarContrato(int idContrato);

        [OperationContract]
        List<Contrato> ListarContrato(int idUsuario);


        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Adicione suas operações de serviço aqui
    }

    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
