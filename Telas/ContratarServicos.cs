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
    public partial class ContratarServicos : Form
    {
        private FachadaServico FachadaServico;
        private FachadaContrato FachadaContrato;

        private Servico EntServico;
        private Contrato EntContrato;

        private int IdEntidade;
        public ContratarServicos()
        {
            InitializeComponent();
        }

        public ContratarServicos(int idEntidade)
        {
            InitializeComponent();

            FachadaServico = new FachadaServico();
            FachadaContrato = new FachadaContrato();

            EntContrato = new Contrato();
            EntServico = new Servico();

            this.IdEntidade = idEntidade;
        }

        private void listServicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteLogado cliente = new ClienteLogado(IdEntidade);
            cliente.Closed += (s, args) => this.Close();
            cliente.Show();
        }

        private void ContratarServicos_Load(object sender, EventArgs e)
        {
            foreach(Servico item in FachadaServico.Listar())
            {
                ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                lista.SubItems.Add(item.Nome);
                lista.SubItems.Add(item.TipoServico);
                lista.SubItems.Add(Convert.ToString(item.Valor));
                listServicos.Items.Add(lista);
            }
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            try
            {
                EntContrato.Idusuario = IdEntidade;
                EntContrato.Idservico = Convert.ToInt32(listServicos.SelectedItems[0].SubItems[0].Text);
                FachadaContrato.Inserir(EntContrato);

                MessageBox.Show("Serviço Contratado Com Sucesso!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Inserir o Item Selecionado: " + ex.Message);
            }
        }
    }
}
