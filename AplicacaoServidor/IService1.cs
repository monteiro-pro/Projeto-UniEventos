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
        #region Cliente
        [OperationContract]
        void InsertCliente(Cliente usuario);

        [OperationContract]
        void DeleteCliente(int idUsuario);

        [OperationContract]
        void AlterarCliente(Cliente usuario, bool emailAtual);

        [OperationContract]
        List<Cliente> ListarCliente();

        [OperationContract]
        Cliente SelectCliente(int idUsuario);

        [OperationContract]
        Cliente LogarCliente(string emial, string senha);
        #endregion

        #region Empresa
        [OperationContract]
        void InsertEmpresa(Empresa usuario);

        [OperationContract]
        void DeleteEmpresa(int idUsuario);

        [OperationContract]
        void AlterarEmpresa(Empresa usuario, bool emailAtual);

        [OperationContract]
        List<Empresa> ListarEmpresa();

        [OperationContract]
        Empresa SelectEmpresa(int idUsuario);

        [OperationContract]
        Empresa LogarEmpresa(string emial, string senha);
        #endregion

        #region Servico
        [OperationContract]
        void InserirServico(Servico servico);

        [OperationContract]
        void DeletarServico(int idServico);

        [OperationContract]
        Servico SelectServico(int idUsuario);

        [OperationContract]
        List<Servico> ListarServico();

        [OperationContract]
        List<Servico> ListarServicoID(int idUsuario);

        [OperationContract]
        List<Servico> ListarServicoPA(string parametro);
        #endregion

        #region Contrato
        [OperationContract]
        void InserirContrato(Contrato contrato);

        [OperationContract]
        void DeletarContrato(int idContrato);

        [OperationContract]
        List<Contrato> ListarContrato(int idUsuario);
        #endregion
    }
}
