using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Biblioteca.Fachada;
using Biblioteca.Negocio.Basica;

namespace AplicacaoServidor
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service1 : IService1
    {
        private FachadaCliente FachadaCliente;
        private FachadaEmpresa FachadaEmpresa;
        private FachadaServico FachadaServico;
        private FachadaContrato FachadaContrato;

        public Service1()
        {
            FachadaCliente = new FachadaCliente();
            FachadaEmpresa = new FachadaEmpresa();
            FachadaServico = new FachadaServico();
            FachadaContrato = new FachadaContrato();
        }

        #region Cliente

        public void InsertCliente(Cliente usuario)
        {
            FachadaCliente.Inserir(usuario);
        }

        public void DeleteCliente(int idUsuario)
        {
            FachadaCliente.Deletar(idUsuario);
        }

        public void AlterarCliente(Cliente usuario)
        {
            FachadaCliente.Alterar(usuario);
        }

        public List<Cliente> ListarCliente()
        {
            return FachadaCliente.Listar();
        }

        public Cliente SelectCliente(int idUsuario)
        {
            return FachadaCliente.SelectCliente(idUsuario);
        }

        public Cliente LogarCliente(string emial, string senha)
        {
            return FachadaCliente.Logar(emial, senha);
        }

        #endregion

        #region Empresa

        public void InsertEmpresa(Empresa usuario)
        {
            FachadaEmpresa.Inserir(usuario);
        }

        public void DeleteEmpresa(int idUsuario)
        {
            FachadaEmpresa.Deletar(idUsuario);
        }

        public void AlterarEmpresa(Empresa usuario)
        {
            FachadaEmpresa.Alterar(usuario);
        }

        public List<Empresa> ListarEmpresa()
        {
            return FachadaEmpresa.Listar();
        }

        public Empresa SelectEmpresa(int idUsuario)
        {
            return FachadaEmpresa.SelectEmpresa(idUsuario);
        }

        public Empresa LogarEmpresa(string emial, string senha)
        {
            return FachadaEmpresa.Logar(emial, senha);
        }

        #endregion

        #region Servicos

        public void InserirServico(Servico servico)
        {
            FachadaServico.Inserir(servico);
        }

        public void DeletarServico(int idServico)
        {
            FachadaServico.Deletar(idServico);
        }

        public List<Servico> ListarServico()
        {
            return FachadaServico.Listar();
        }

        public List<Servico> ListarServicoID(int idUsuario)
        {
            return FachadaServico.Listar(idUsuario);
        }

        public List<Servico> ListarServicoPA(string parametro)
        {
            return FachadaServico.Listar(parametro);
        }

        #endregion

        #region Contrato

        public void InserirContrato(Contrato contrato)
        {
            FachadaContrato.Inserir(contrato);
        }

        public void DeletarContrato(int idContrato)
        {
            FachadaContrato.Deletar(idContrato);
        }

        public List<Contrato> ListarContrato(int idUsuario)
        {
            return FachadaContrato.Listar(idUsuario);
        }

        #endregion

    }
}
