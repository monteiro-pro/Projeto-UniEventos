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
        private FachadaUsuario FachadaUsuario;
        private FachadaContrato FachadaContrato;
        private Usuario EntUsuario;
        private Contrato EntContrato;

        private int idEntidade;

        public ClienteLogado()
        {
            InitializeComponent();
        }

        public ClienteLogado(int idEntidade)
        {
            this.idEntidade = idEntidade;

            FachadaUsuario = new FachadaUsuario();
            FachadaContrato = new FachadaContrato();
            EntUsuario = new Usuario();
            EntContrato = new Contrato();

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
            ContratarServicos contratar = new ContratarServicos(idEntidade);
            contratar.Closed += (s, args) => this.Close();
            contratar.Show();
        }

        private void ClienteLogado_Load(object sender, EventArgs e)
        {
            foreach (Contrato item in FachadaContrato.Listar(idEntidade))
            {
                ListViewItem lista = new ListViewItem(Convert.ToString(item.Idcontrato));
                lista.SubItems.Add(item.Nome);
                lista.SubItems.Add(item.Tipo);
                lista.SubItems.Add(item.Empresa);
                lista.SubItems.Add(Convert.ToString(item.Valor));
                listServicos.Items.Add(lista);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lista in listServicos.SelectedItems)
                {
                    FachadaContrato.Deletar(Convert.ToInt32(listServicos.SelectedItems[0].SubItems[0].Text));

                    lista.Remove();

                    MessageBox.Show("Serviço Excluido Com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Excluir o Item Selecionado: " + ex.Message);
            }
        }
    }
}
