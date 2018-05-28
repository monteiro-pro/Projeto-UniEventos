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
    public partial class CadastrarServico : Form
    {
        private FachadaServico Fachada;
        private Servico Servicos;

        private int IdEntidade;

        public CadastrarServico()
        {
            InitializeComponent();
        }

        public CadastrarServico(int idEntidade)
        {
            Fachada = new FachadaServico();
            Servicos = new Servico();

            this.IdEntidade = idEntidade;

            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpresaLogada empresa = new EmpresaLogada(IdEntidade);
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
                Servicos.IdUsuario = IdEntidade;

                Fachada.Inserir(Servicos);

                MessageBox.Show("Serviço Cadastrado Com Sucesso!");

                this.Hide();
                EmpresaLogada empresa = new EmpresaLogada(IdEntidade);
                empresa.Closed += (s, args) => this.Close();
                empresa.Show();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Tentar Cadastrar o Serviço!" + ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
