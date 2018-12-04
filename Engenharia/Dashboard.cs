using Engenharia.Entities;
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

    public partial class Dashboard : Form
    {
        public static string solicitacaoNum = "";

        public Dashboard()
        {
            InitializeComponent();




            //dataGridView1.DataBindings.Add();

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela '_sas_1DataSet.backoffice'. Você pode movê-la ou removê-la conforme necessário.
            this.backofficeTableAdapter.Fill(this._sas_1DataSet.backoffice);
            // TODO: esta linha de código carrega dados na tabela 'sasDataSet.login'. Você pode movê-la ou removê-la conforme necessário.
            this.loginTableAdapter1.Fill(this._sas_1DataSet.login);

            var returnBackoffice = dbAccess.callSql("select * from backoffice");
            BindingList<BackOffice> backoffices = new BindingList<BackOffice>();
            foreach(var row in returnBackoffice)
            {               
                
                
                BackOffice backOffice = new BackOffice();
                backOffice.num_solicitacao = Convert.ToInt32(row["num_solicitacao"]);
                backOffice.dtAbertura = Convert.ToDateTime(row["dt_abertura"]);
                backOffice.status = Utils.GetDescription((enStatusBackoffice)Convert.ToInt32(row["status_bo"]));
                backoffices.Add(backOffice);

            }

            dataGridView1.DataSource = backoffices;


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var numBo = txtBO.Text;
            var agencia = txtAgencia.Text;
            var conta = txtConta.Text;

            BO formBO = new BO();

            if (((numBo == "") && (agencia == "") && (conta == "")) || ((numBo != "") && (agencia != "") && (conta != "")) || ((numBo != "") && (agencia != "") && (conta == "")) || ((numBo != "") && (agencia == "") && (conta != "")))
            {
                MessageBox.Show("Por favor, preencha a agência e conta ou o número de BO");
            }
            else if ((numBo == "") && (agencia != "") && (conta != ""))
            {
                var result = dbAccess.callSql("SELECT num_conta FROM conta where num_conta=" + txtConta.Text + " AND num_agencia=" + txtAgencia.Text + " AND digito ="+ txtDigito.Text);
                
                if (Convert.ToString(result.Count) != "0")
                {
                    var resultBackoffice = dbAccess.callSql("SELECT num_solicitacao FROM backoffice where num_conta=" + txtConta.Text);
                    var resultKeys = resultBackoffice[0];
                    solicitacaoNum = Convert.ToString(resultKeys["num_solicitacao"]);
                    formBO.Show();
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrato");
                }
            }
            else if ((numBo != "") && (agencia == "") && (conta == ""))
            {
                var result = dbAccess.callSql("SELECT num_solicitacao FROM backoffice where num_solicitacao=" + txtBO.Text);
                if (Convert.ToString(result.Count) != "0")
                {
                    solicitacaoNum = numBo;
                    formBO.Show();
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrato");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (!(index < 0))
            {
                DataGridViewRow row = dataGridView1.Rows[index];
                solicitacaoNum = row.Cells[0].Value.ToString();
                BO formBO = new BO();
                formBO.Show();
            }
        }

        private void backofficeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void txtBO_TextChanged(object sender, EventArgs e)
        {

        }


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.statusboTableAdapter.FillBy(this._sas_1DataSet.statusbo);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.statusboTableAdapter.FillBy(this._sas_1DataSet.statusbo);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
