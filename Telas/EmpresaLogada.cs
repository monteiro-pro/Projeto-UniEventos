﻿using AplicacaoForm;
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
        private FachadaUsuario FachadaUsuario;

        private Servico EntServicos;
        private Usuario EntUsuario;

        private int IdEntidade;
        public EmpresaLogada()
        {
            InitializeComponent();
        }
        public EmpresaLogada(int idEntidade)
        {
            FachadaServico = new FachadaServico();
            FachadaUsuario = new FachadaUsuario();

            EntServicos = new Servico();
            EntUsuario = new Usuario();

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
            try
            {
                foreach (Servico item in FachadaServico.Listar(IdEntidade))
                {
                    ListViewItem lista = new ListViewItem(Convert.ToString(item.IdServico));
                    lista.SubItems.Add(item.Nome);
                    lista.SubItems.Add(item.TipoServico);
                    lista.SubItems.Add(Convert.ToString(item.Valor));
                    listServicos.Items.Add(lista);
                }

                lblNome.Text = FachadaUsuario.SelectUsuario(IdEntidade).Nome;
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lista in listServicos.SelectedItems)
                {
                    FachadaServico.Deletar(Convert.ToInt32(listServicos.SelectedItems[0].SubItems[0].Text));

                    lista.Remove();

                    MessageBox.Show("Serviço Excluido Com Sucesso!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Tentar Excluir o Item Selecionado: " + ex.Message);
            }
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }
    }
}
