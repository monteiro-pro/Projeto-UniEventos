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
    public partial class AdminLogado : Form
    {
        private FachadaUsuario FachadaUsuario;
        private Usuario EntUsuario;

        public AdminLogado()
        {
            FachadaUsuario = new FachadaUsuario();
            EntUsuario = new Usuario();

            InitializeComponent();
        }

        private void AdminLogado_Load(object sender, EventArgs e)
        {
            foreach (Usuario item in FachadaUsuario.Listar())
            {
                ListViewItem lista = new ListViewItem(Convert.ToString(item.IdUsuario));
                lista.SubItems.Add(item.TipoAcesso);
                lista.SubItems.Add(item.Nome);
                lista.SubItems.Add(Convert.ToString(item.Telefone));
                listCadastrados.Items.Add(lista);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loguin loguin = new Loguin();
            loguin.Closed += (s, args) => this.Close();
            loguin.Show();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lista in listCadastrados.SelectedItems)
                {
                    FachadaUsuario.Deletar(Convert.ToInt32(listCadastrados.SelectedItems[0].SubItems[0].Text));

                    lista.Remove();

                    MessageBox.Show("Usuário Excluido com Sucesso!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Excluir o Item Selecionado: " + ex.Message);
            }
        }
    }
}
