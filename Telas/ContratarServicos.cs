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
        public ContratarServicos()
        {
            InitializeComponent();
        }

        private void listServicos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteLogado cliente = new ClienteLogado();
            cliente.Closed += (s, args) => this.Close();
            cliente.Show();
        }
    }
}
