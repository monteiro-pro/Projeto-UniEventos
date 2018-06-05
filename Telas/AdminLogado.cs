using AplicacaoForm;
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

namespace Telas
{
    public partial class AdminLogado : Form
    {
        //private FachadaUsuario FachadaUsuario;
        private Service1 Service;

        private Usuario EntUsuario;

        public AdminLogado()
        {
            //FachadaUsuario = new FachadaUsuario();
            Service = new Service1();

            EntUsuario = new Usuario();

            InitializeComponent();
        }

        private void AdminLogado_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Usuario item in Service.ListarUsuario())
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdUsuario));
                    lista.SubItems.Add(item.TipoAcesso);
                    lista.SubItems.Add(item.Nome);
                    lista.SubItems.Add(Convert.ToString(item.Telefone));
                    listCadastrados.Items.Add(lista);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro No Loguin do Usuário!" + ex.Message);
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
                    Service.DeleteUsuario(Convert.ToInt32(listCadastrados.SelectedItems[0].SubItems[0].Text), true);

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
