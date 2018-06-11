using AplicacaoForm;
using AplicacaoForm.localhost;
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
        private Service1 Service;

        public AdminLogado()
        {
            Service = new Service1();

            InitializeComponent();
        }

        private void AdminLogado_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Cliente item in Service.ListarCliente())
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdUsuario));
                    lista.SubItems.Add("Cliente");
                    lista.SubItems.Add(item.Nome);
                    lista.SubItems.Add(Convert.ToString(item.Telefone));
                    listCadastrados.Items.Add(lista);
                }

                foreach (Empresa item in Service.ListarEmpresa())
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdUsuario));
                    lista.SubItems.Add("Empresa");
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
                    if (listCadastrados.SelectedItems[0].SubItems[1].Text == "Cliente")
                    {
                        Service.DeleteCliente(Convert.ToInt32(listCadastrados.SelectedItems[0].SubItems[0].Text), true);
                    }
                    else
                    {
                        Service.DeleteEmpresa(Convert.ToInt32(listCadastrados.SelectedItems[0].SubItems[0].Text), true);
                    }

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
