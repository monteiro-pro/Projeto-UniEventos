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
    public partial class EmpresaLogada : Form
    {
        private FachadaServicos Fachada;
        private Servicos Servicos;
        private int IdEntidade;
        public EmpresaLogada()
        {
            InitializeComponent();
        }
        public EmpresaLogada(int idEntidade)
        {
            Fachada = new FachadaServicos();
            Servicos = new Servicos();

            this.IdEntidade = idEntidade;

            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastrarServico cadastrar = new CadastrarServico(IdEntidade);
            cadastrar.Closed += (s, args) => this.Close();
            cadastrar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void EmpresaLogada_Load(object sender, EventArgs e)
        {
            ListView items = new ListView();
            items = listServicos;

            foreach (Servicos item in Fachada.Listar(IdEntidade))
            {
               // items.ControlAdded()

                //listServicos.n
            }
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
            EditarPerfil perfil = new EditarPerfil(IdEntidade);
            perfil.Closed += (s, args) => this.Close();
            perfil.Show();
        }

        private void listServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nome.Text = "testetetetetet";
            foreach (Servicos item in Fachada.Listar(IdEntidade))
            {
                Nome.Text = item.Nome;
                Tipo.Text = item.TipoServico;
                Valor.Text = Convert.ToString(item.Valor);
            }
        }
    }
}
