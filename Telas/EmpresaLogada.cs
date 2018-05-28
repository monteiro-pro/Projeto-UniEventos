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
        private FachadaServico FachadaServico;
        private Servico EntServicos;
        private int IdEntidade;
        public EmpresaLogada()
        {
            InitializeComponent();
        }
        public EmpresaLogada(int idEntidade)
        {
            FachadaServico = new FachadaServico();
            EntServicos = new Servico();

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

            foreach (Servico item in FachadaServico.Listar(IdEntidade))
            {
                ListViewItem lista = new ListViewItem(item.Nome);
                lista.SubItems.Add(item.TipoServico);
                lista.SubItems.Add(Convert.ToString(item.Valor));
                listServicos.Items.Add(lista);
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

        }
    }
}
