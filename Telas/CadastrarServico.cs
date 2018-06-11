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
    public partial class CadastrarServico : Form
    {
        private Service1 Service;

        private Servico Servicos;

        private Empresa EntEmpresa;

        public CadastrarServico()
        {
            InitializeComponent();
        }

        public CadastrarServico(Empresa EntEmpresa)
        {
            Service = new Service1();

            Servicos = new Servico();

            this.EntEmpresa = EntEmpresa;

            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpresaLogada empresa = new EmpresaLogada(EntEmpresa);
            empresa.Closed += (s, args) => this.Close();
            empresa.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Servicos.TipoServico = slcTipoCadastro.Text;
                Servicos.Nome = txtNome.Text;
                Servicos.Valor = Convert.ToInt32(txtValor.Text);
                Servicos.EntEmpresa = EntEmpresa;

                Service.InserirServico(Servicos);

                MessageBox.Show("Serviço Cadastrado Com Sucesso!");

                this.Hide();
                EmpresaLogada empresa = new EmpresaLogada(EntEmpresa);
                empresa.Closed += (s, args) => this.Close();
                empresa.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Cadastrar o Serviço: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
