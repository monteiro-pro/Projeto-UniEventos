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
using Telas;

namespace AplicacaoForm
{
    public partial class EditarPerfil : Form
    {
        private Cliente EntCliente;
        private Empresa EntEmpresa;

        private Service1 Service;

        private int idEntidade;
        public EditarPerfil()
        {
            InitializeComponent();
        }

        public EditarPerfil(int idEntidade)
        {

            Service = new Service1();

            this.idEntidade = idEntidade;

            EntCliente = new Cliente();
            EntEmpresa = new Empresa();

            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Service.SelectCliente(idEntidade, true) != null)
                {
                    EntCliente.Nome = txtNome.Text;
                    EntCliente.Telefone = Convert.ToInt32(txtTelefone.Text);
                    EntCliente.Email = txtEmail.Text;
                    EntCliente.Senha = txtSenha.Text;

                    Service.AlterarCliente(EntCliente);

                    MessageBox.Show("Dados Alterados Com Sucesso!");

                    this.Hide();
                    ClienteLogado logado = new ClienteLogado(idEntidade);
                    logado.Closed += (s, args) => this.Close();
                    logado.Show();
                }
                else if (Service.SelectEmpresa(idEntidade, true) != null)
                {
                    EntEmpresa.Nome = txtNome.Text;
                    EntEmpresa.Telefone = Convert.ToInt32(txtTelefone.Text);
                    EntEmpresa.Email = txtEmail.Text;
                    EntEmpresa.Senha = txtSenha.Text;

                    Service.AlterarEmpresa(EntEmpresa);

                    MessageBox.Show("Dados Alterados Com Sucesso!");

                    this.Hide();
                    EmpresaLogada logado = new EmpresaLogada(idEntidade);
                    logado.Closed += (s, args) => this.Close();
                    logado.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro Em Tentar Alterar os Dados: " + ex.Message);
            }

        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            if(Service.SelectCliente(idEntidade, true) != null)
            {
                EntCliente = Service.SelectCliente(idEntidade, true);

                txtNome.Text = EntCliente.Nome;
                txtTelefone.Text = Convert.ToString(EntCliente.Telefone);
                txtEmail.Text = EntCliente.Email;
                txtSenha.Text = EntCliente.Senha;
            }

            else if (Service.SelectEmpresa(idEntidade, true) != null)
            {
                EntEmpresa = Service.SelectEmpresa(idEntidade, true);

                txtNome.Text = EntEmpresa.Nome;
                txtTelefone.Text = Convert.ToString(EntEmpresa.Telefone);
                txtEmail.Text = EntEmpresa.Email;
                txtSenha.Text = EntEmpresa.Senha;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Service.SelectCliente(idEntidade, true) != null)
            {
                this.Hide();
                ClienteLogado logado = new ClienteLogado(idEntidade);
                logado.Closed += (s, args) => this.Close();
                logado.Show();
            }
            else
            {
                this.Hide();
                EmpresaLogada logado = new EmpresaLogada(idEntidade);
                logado.Closed += (s, args) => this.Close();
                logado.Show();
            }
        }
    }
}
