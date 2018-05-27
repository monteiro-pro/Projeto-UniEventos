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
using Telas;

namespace AplicacaoForm
{
    public partial class EditarPerfil : Form
    {
        private FachadaUsuario fachada;
        private Usuario usuario;

        private int idEntidade;
        public EditarPerfil()
        {
            InitializeComponent();
        }

        public EditarPerfil(int idEntidade)
        {
            this.idEntidade = idEntidade;

            fachada = new FachadaUsuario();
            usuario = new Usuario();

            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario.Nome = txtNome.Text;
                usuario.Telefone = Convert.ToInt32(txtTelefone.Text);
                usuario.Email = txtEmail.Text;
                usuario.Senha = txtSenha.Text;

                fachada.Alterar(usuario);

                MessageBox.Show("Dados Alterados Com Sucesso!");

                if (usuario.TipoAcesso == "Cliente")
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
            catch(Exception ex)
            {
                throw new Exception("Erro Em Tentar Alterar os Dados!" + ex);
            }

        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            usuario = fachada.SelectUsuario(idEntidade);

            txtNome.Text = usuario.Nome;
            txtTelefone.Text = Convert.ToString(usuario.Telefone);
            txtEmail.Text = usuario.Email;
            txtSenha.Text = usuario.Senha;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (usuario.TipoAcesso == "Cliente")
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
