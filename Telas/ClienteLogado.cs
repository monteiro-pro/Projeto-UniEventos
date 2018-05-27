using AplicacaoForm;
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

namespace Telas
{
    public partial class ClienteLogado : Form
    {
        private FachadaUsuario fachada;
        private Usuario usuario;

        private int idEntidade;

        public ClienteLogado()
        {
            InitializeComponent();
        }

        public ClienteLogado(int idEntidade)
        {
            this.idEntidade = idEntidade;

            fachada = new FachadaUsuario();
            usuario = new Usuario();

            InitializeComponent();
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
            EditarPerfil perfil = new EditarPerfil(idEntidade);
            perfil.Closed += (s, args) => this.Close();
            perfil.Show();
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContratarServicos contratar = new ContratarServicos();
            contratar.Closed += (s, args) => this.Close();
            contratar.Show();
        }

        private void ClienteLogado_Load(object sender, EventArgs e)
        {

        }
    }
}
