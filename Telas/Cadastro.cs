using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacaoForm.localhost;

namespace AplicacaoForm
{
    public partial class Cadastro : Form
    {
        private Cliente EntCliente;
        private Empresa EntEmpresa;
        public Cadastro()
        {
            EntCliente = new Cliente();
            EntEmpresa = new Empresa();

            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (slcTipoCadastro.Text != "Empresa" && slcTipoCadastro.Text != "Cliente")
                {
                    MessageBox.Show("Escolha Um Tipo de Cadastro!")
;               }
                else
                {
                    if (slcTipoCadastro.Text == "Cliente")
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

                        Service1 sv = new Service1();

                        sv.InsertCliente(EntCliente);

                        MessageBox.Show("Usuário Cadastrado Com Sucesso!");

                        this.Hide();
                        Loguin loguin = new Loguin();
                        loguin.Closed += (s, args) => this.Close();
                        loguin.Show();
                    }

                    else if (slcTipoCadastro.Text == "Empresa")
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

                        Service1 sv = new Service1();

                        sv.InsertEmpresa(EntEmpresa);

                        MessageBox.Show("Usuário Cadastrado Com Sucesso!");

                        this.Hide();
                        Loguin loguin = new Loguin();
                        loguin.Closed += (s, args) => this.Close();
                        loguin.Show();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro em Tentar Cadastrar Usuário: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loguin loguin = new Loguin();
            loguin.Closed += (s, args) => this.Close();
            loguin.Show();
        }
    }
}
