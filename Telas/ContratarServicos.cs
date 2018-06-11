using AplicacaoForm.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public partial class ContratarServicos : Form
    {
        private Service1 Service;

        private Contrato EntContrato;

        private Cliente EntCliente;
        public ContratarServicos()
        {
            InitializeComponent();
        }

        public ContratarServicos(Cliente EntCliente)
        {
            InitializeComponent();

            this.Service = new Service1();

            this.EntContrato = new Contrato();

            this.EntCliente = EntCliente;
        }

        private void listServicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteLogado cliente = new ClienteLogado(EntCliente);
            cliente.Closed += (s, args) => this.Close();
            cliente.Show();
        }

        private void ContratarServicos_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Servico item in Service.ListarServico())
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                    lista.SubItems.Add(item.Nome);
                    lista.SubItems.Add(item.TipoServico);
                    lista.SubItems.Add(Convert.ToString(item.Valor));
                    listServicos.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve Um Erro ao Tentar Listar os Serviços do Banco de Dados!" + ex.Message);
            }
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            try
            {
                EntContrato.EntCliente = EntCliente;
                EntContrato.EntServico = Service.SelectServico(Convert.ToInt32(listServicos.SelectedItems[0].SubItems[0].Text), true);
                EntContrato.EntServico.EntEmpresa = Service.SelectEmpresa(EntContrato.EntServico.IdUsuario, true);
                Service.InserirContrato(EntContrato);

                MessageBox.Show("Serviço Contratado Com Sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Inserir o Item Selecionado: " + ex.Message);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (slcTipoServico.Text == "Escolha um Tipo..." && String.IsNullOrEmpty(txtNome.Text) || slcTipoServico.Text == "Não Escolher Tipo..." && String.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Escolha Um Tipo ou Digite Um Nome de Serviço Para Pesquisar!");
                }
                else
                {
                    if (slcTipoServico.Text != "Não Escolher Tipo..." && slcTipoServico.Text != "Escolha um Tipo...")
                    {
                        listServicos.Items.Clear();

                        foreach (Servico item in Service.ListarServicoPA(slcTipoServico.Text))
                        {
                            ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                            lista.SubItems.Add(item.Nome);
                            lista.SubItems.Add(item.TipoServico);
                            lista.SubItems.Add(Convert.ToString(item.Valor));
                            listServicos.Items.Add(lista);
                        }
                    }
                    else
                    {
                        listServicos.Items.Clear();

                        foreach (Servico item in Service.ListarServicoPA(txtNome.Text))
                        {
                            ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                            lista.SubItems.Add(item.Nome);
                            lista.SubItems.Add(item.TipoServico);
                            lista.SubItems.Add(Convert.ToString(item.Valor));
                            listServicos.Items.Add(lista);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ouve Um Erro ao Tentar Listar os Serviços do Banco de Dados!" + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                listServicos.Items.Clear();

                foreach (Servico item in Service.ListarServico())
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                    lista.SubItems.Add(item.Nome);
                    lista.SubItems.Add(item.TipoServico);
                    lista.SubItems.Add(Convert.ToString(item.Valor));
                    listServicos.Items.Add(lista);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve Um Erro ao Tentar Listar os Serviços do Banco de Dados!" + ex.Message);
            }
        }
    }
}
