using Biblioteca.Dados.Conexao;
using Biblioteca.Fachada;
using Biblioteca.Negocio.Basica;
using Biblioteca.Negocio.Regra;
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
                Usuario usuario = new Usuario();
                usuario.Nome = txtNome.Text;
                usuario.TipoAcesso = slcTipoCadastro.Text;
                usuario.Telefone = Convert.ToInt32(txtTelefone.Text);
                usuario.Email = txtEmail.Text;
                usuario.Senha = txtSenha.Text;

                new FachadaUsuario().Inserir(usuario);

                MessageBox.Show("Usuário Cadastrado Com Sucesso!");

                this.Hide();
                Loguin loguin = new Loguin();
                loguin.Closed += (s, args) => this.Close();
                loguin.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro em Tentar Conectar-se ao Banco!" + ex);
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
