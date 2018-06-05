using AplicacaoForm.localhost;
using Biblioteca.Fachada;
//using Biblioteca.Negocio.Basica;
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
        //private FachadaUsuario FachadaUsuario;
        private Usuario EntUsuario;
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

            //FachadaUsuario = new FachadaUsuario();
            EntUsuario = new Usuario();

            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                EntUsuario.Nome = txtNome.Text;
                EntUsuario.Telefone = Convert.ToInt32(txtTelefone.Text);
                EntUsuario.Email = txtEmail.Text;
                EntUsuario.Senha = txtSenha.Text;

                Service.AlterarUsuario(EntUsuario);

                MessageBox.Show("Dados Alterados Com Sucesso!");

                if (EntUsuario.TipoAcesso == "Cliente")
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
                MessageBox.Show("Erro Em Tentar Alterar os Dados: " + ex.Message);
            }

        }

        private void EditarPerfil_Load(object sender, EventArgs e)
        {
            EntUsuario = Service.SelectUsuarioUsuario(idEntidade, true);

            txtNome.Text = EntUsuario.Nome;
            txtTelefone.Text = Convert.ToString(EntUsuario.Telefone);
            txtEmail.Text = EntUsuario.Email;
            txtSenha.Text = EntUsuario.Senha;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (EntUsuario.TipoAcesso == "Cliente")
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
