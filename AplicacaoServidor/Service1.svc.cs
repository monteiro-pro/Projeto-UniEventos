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
        private FachadaUsuario FachadaUsuario;
        private FachadaServico FachadaServico;
        private FachadaContrato FachadaContrato;

        public Service1()
        {
            FachadaUsuario = new FachadaUsuario();
            FachadaServico = new FachadaServico();
            FachadaContrato = new FachadaContrato();
        }

        #region Usuario

        public void InsertUsuario(Usuario usuario)
        {
            FachadaUsuario.Inserir(usuario);
        }

        public void DeleteUsuario(int idUsuario)
        {
            FachadaUsuario.Deletar(idUsuario);
        }

        public void AlterarUsuario(Usuario usuario)
        {
            FachadaUsuario.Alterar(usuario);
        }

        public List<Usuario> ListarUsuario()
        {
            return FachadaUsuario.Listar();
        }

        public Usuario SelectUsuarioUsuario(int idUsuario)
        {
            return FachadaUsuario.SelectUsuario(idUsuario);
        }

        public Usuario LogarUsuario(string emial, string senha)
        {
            return FachadaUsuario.Logar(emial, senha);
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

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
