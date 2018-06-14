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
    public partial class EmpresaLogada : Form
    {
        private Service1 Service;

        private Empresa EntEmpresa;

        public EmpresaLogada()
        {
            InitializeComponent();
        }
        public EmpresaLogada(Empresa EntEmpresa)
        {
            Service = new Service1();

            this.EntEmpresa = new Empresa();

            this.EntEmpresa = EntEmpresa;

            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastrarServico cadastrar = new CadastrarServico(EntEmpresa);
            cadastrar.Closed += (s, args) => this.Close();
            cadastrar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void EmpresaLogada_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Servico item in Service.ListarServicoID(EntEmpresa.IdUsuario, true))
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                    lista.SubItems.Add(item.Nome);
                    lista.SubItems.Add(item.TipoServico);
                    lista.SubItems.Add(Convert.ToString(item.Valor));
                    listServicos.Items.Add(lista);
                }

                lblNome.Text = EntEmpresa.Nome;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro No Loguin do Usuário!" + ex.Message);
            }
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
            EditarPerfil perfil = new EditarPerfil(EntEmpresa, false);
            perfil.Closed += (s, args) => this.Close();
            perfil.Show();
        }

        private void listServicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lista in listServicos.SelectedItems)
                {
                    Service.DeletarServico(Convert.ToInt32(listServicos.SelectedItems[0].SubItems[0].Text), true);

                    lista.Remove();

                    MessageBox.Show("Serviço Excluido Com Sucesso!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Excluir o Item Selecionado: " + ex.Message);
            }
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }
    }
}
