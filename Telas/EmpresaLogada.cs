using AplicacaoForm;
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
    public partial class EmpresaLogada : Form
    {
        public EmpresaLogada()
        {
            InitializeComponent();
        }
        public EmpresaLogada(Usuario usuario)
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastrarServico cadastrar = new CadastrarServico();
            cadastrar.Closed += (s, args) => this.Close();
            cadastrar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void EmpresaLogada_Load(object sender, EventArgs e)
        {

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
            EditarPerfil perfil = new EditarPerfil();
            perfil.Closed += (s, args) => this.Close();
            perfil.Show();
        }
    }
}
