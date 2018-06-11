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
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_BottomToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Loguin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Service1 Service = new Service1();

                if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtSenha.Text))
                {
                    MessageBox.Show("Digite Um Email e Uma Senha Para Logar!");
                }
                else if (txtEmail.Text == "adm" && txtSenha.Text == "123" || txtEmail.Text == "ADM" && txtSenha.Text == "123")
                {
                    this.Hide();
                    AdminLogado logado = new AdminLogado();
                    logado.Closed += (s, args) => this.Close();
                    logado.Show();
                }
                else if (!String.IsNullOrEmpty(Service.LogarCliente(txtEmail.Text, txtSenha.Text).Email))
                {
                    this.Hide();
                    ClienteLogado logado = new ClienteLogado(Service.LogarCliente(txtEmail.Text, txtSenha.Text).IdUsuario);
                    logado.Closed += (s, args) => this.Close();
                    logado.Show();
                }
                else if (!String.IsNullOrEmpty(Service.LogarEmpresa(txtEmail.Text, txtSenha.Text).Email))
                {
                    this.Hide();
                    EmpresaLogada logado = new EmpresaLogada(Service.LogarEmpresa(txtEmail.Text, txtSenha.Text).IdUsuario);
                    logado.Closed += (s, args) => this.Close();
                    logado.Show();
                }
                else
                {
                    MessageBox.Show("Email ou Senha Inválidos!");

                    txtEmail.Clear();
                    txtSenha.Clear();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Tentar Logar!" + ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadastro cadastro = new Cadastro();
            cadastro.Closed += (s, args) => this.Close();
            cadastro.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
