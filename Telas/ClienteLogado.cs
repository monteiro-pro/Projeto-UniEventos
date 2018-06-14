using AplicacaoForm;
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
    public partial class ClienteLogado : Form
    {
        private Service1 Service;

        private Cliente EntCliente;
        private Contrato EntContrato;

        public ClienteLogado()
        {
            InitializeComponent();
        }

        public ClienteLogado(Cliente EntCliente)
        {
            Service = new Service1();

            this.EntCliente = new Cliente();
            this.EntContrato = new Contrato();

            this.EntCliente = EntCliente;

            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loguin loguin = new Loguin();
            loguin.Closed += (s, args) => this.Close();
            loguin.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarPerfil perfil = new EditarPerfil(EntCliente, true);
            perfil.Closed += (s, args) => this.Close();
            perfil.Show();
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContratarServicos contratar = new ContratarServicos(EntCliente);
            contratar.Closed += (s, args) => this.Close();
            contratar.Show();
        }

        private void ClienteLogado_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Contrato item in Service.ListarContrato(EntCliente.IdUsuario, true))
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.Idcontrato));
                    lista.SubItems.Add(item.NomeServico);
                    lista.SubItems.Add(item.TipoServico);
                    lista.SubItems.Add(item.NomeEmpresa);
                    lista.SubItems.Add(Convert.ToString(item.Valor));
                    listServicos.Items.Add(lista);
                }

                lblNome.Text = EntCliente.Nome;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro No Loguin do Usuário!" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lista in listServicos.SelectedItems)
                {
                    Service.DeletarContrato(Convert.ToInt32(listServicos.SelectedItems[0].SubItems[0].Text), true);

                    lista.Remove();

                    MessageBox.Show("Serviço Excluido Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Excluir o Item Selecionado: " + ex.Message);
            }
        }
    }
}
