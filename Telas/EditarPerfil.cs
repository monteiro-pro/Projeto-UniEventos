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

        private string TipoAcesso;
        public EditarPerfil()
        {
            InitializeComponent();
        }

        public EditarPerfil(Cliente EntCliente)
        {
            Service = new Service1();

            this.EntCliente = new Cliente();
            this.EntCliente = EntCliente;

            TipoAcesso = "Cliente";

            InitializeComponent();
        }
        public EditarPerfil(Empresa EntEmpresa)
        {
            Service = new Service1();

            this.EntEmpresa = new Empresa();
            this.EntEmpresa = EntEmpresa;

            TipoAcesso = "Empresa";

            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            bool verificarEmail = false;

            if (EntCliente.Email != txtEmail.Text)
            {
                verificarEmail = true;
            }

            try
            {
                if (TipoAcesso == "Cliente")
                {
                    EntCliente.Nome = txtNome.Text;
                    if (String.IsNullOrEmpty(txtTelefone.Text))
                    {
                        throw new Exception("Preencha Todos os Campos!");
                    }
                    else
                    {
                        EntCliente.Telefone = Convert.ToInt32(txtTelefone.Text);

                    }
                    EntCliente.Email = txtEmail.Text;
                    EntCliente.Senha = txtSenha.Text;

                    Service.AlterarCliente(EntCliente, verificarEmail, true);

                    MessageBox.Show("Dados Alterados Com Sucesso!");

                    this.Hide();
                    ClienteLogado logado = new ClienteLogado(EntCliente);
                    logado.Closed += (s, args) => this.Close();
                    logado.Show();
                }
                else if (TipoAcesso == "Empresa")
                {
                    EntEmpresa.Nome = txtNome.Text;
                    if (String.IsNullOrEmpty(txtTelefone.Text))
                    {
                        throw new Exception("Preencha Todos os Campos!");
                    }
                    else
                    {
                        EntEmpresa.Telefone = Convert.ToInt32(txtTelefone.Text);

                    }
                    EntEmpresa.Email = txtEmail.Text;
                    EntEmpresa.Senha = txtSenha.Text;

                    Service.AlterarEmpresa(EntEmpresa);

                    MessageBox.Show("Dados Alterados Com Sucesso!");

                    this.Hide();
                    EmpresaLogada logado = new EmpresaLogada(EntEmpresa);
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
            if(TipoAcesso == "Cliente")
            {
                txtNome.Text = EntCliente.Nome;
                txtTelefone.Text = Convert.ToString(EntCliente.Telefone);
                txtEmail.Text = EntCliente.Email;
                txtSenha.Text = EntCliente.Senha;
            }

            else if (TipoAcesso == "Empresa")
            {
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
            if (TipoAcesso == "Cliente")
            {
                this.Hide();
                ClienteLogado logado = new ClienteLogado(EntCliente);
                logado.Closed += (s, args) => this.Close();
                logado.Show();
            }
            else
            {
                this.Hide();
                EmpresaLogada logado = new EmpresaLogada(EntEmpresa);
                logado.Closed += (s, args) => this.Close();
                logado.Show();
            }
        }
    }
}
