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
        public Cadastro()
        {
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
                        Cliente cliente = new Cliente();
                        cliente.Nome = txtNome.Text;

                        if (String.IsNullOrEmpty(txtTelefone.Text))
                        {
                            throw new Exception("Campo Telefone Nulo!");
                        }
                        else
                        {
                            cliente.Telefone = Convert.ToInt32(txtTelefone.Text);

                        }
                        cliente.Email = txtEmail.Text;
                        cliente.Senha = txtSenha.Text;

                        Service1 sv = new Service1();

                        sv.InsertCliente(cliente);

                        MessageBox.Show("Usuário Cadastrado Com Sucesso!");

                        this.Hide();
                        Loguin loguin = new Loguin();
                        loguin.Closed += (s, args) => this.Close();
                        loguin.Show();
                    }

                    else if (slcTipoCadastro.Text == "Empresa")
                    {
                        Empresa empresa = new Empresa();
                        empresa.Nome = txtNome.Text;

                        if (String.IsNullOrEmpty(txtTelefone.Text))
                        {
                            throw new Exception("Campo Telefone Nulo!");
                        }
                        else
                        {
                            empresa.Telefone = Convert.ToInt32(txtTelefone.Text);

                        }
                        empresa.Email = txtEmail.Text;
                        empresa.Senha = txtSenha.Text;

                        Service1 sv = new Service1();

                        sv.InsertEmpresa(empresa);

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
