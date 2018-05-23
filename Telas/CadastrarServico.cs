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
        public CadastrarServico()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpresaLogada empresa = new EmpresaLogada();
            empresa.Closed += (s, args) => this.Close();
            empresa.Show();
        }
    }
}
