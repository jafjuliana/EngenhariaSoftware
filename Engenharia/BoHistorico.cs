using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engenharia
{
    public partial class BO_Historico : Form
    {
        public BO_Historico()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BO_Historico_Load(object sender, EventArgs e)
        {
            var numSoliti = Dashboard.solicitacaoNum;
            var result = dbAccess.callSql("SELECT resposta FROM backoffice where num_solicitacao=" + numSoliti);
            var resultKeys = result[0];

            txtAnalisesAnteriores.Text = resultKeys["resposta"].ToString();
        }
    }
}
