using Biblioteca.Fachada;
using Biblioteca.Negocio.Basica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Usuario usuario = new Usuario();
                FachadaUsuario fachada = new FachadaUsuario();

                usuario.Email = txtEmail.Text;
                usuario.Senha = txtSenha.Text;

                if (fachada.Logar(usuario).Email == usuario.Email && fachada.Logar(usuario).Senha == usuario.Senha)
                {
                    MessageBox.Show("Logado Com Sucesso!");
                }
                else
                {
                    MessageBox.Show("Email ou Senha Inválidos!");
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
