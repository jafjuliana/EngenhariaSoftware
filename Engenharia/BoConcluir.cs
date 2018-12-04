using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Engenharia
{
    public partial class BO_Concluir : Form
    {
        
        public BO_Concluir()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BO_Concluir_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela '_sas_1DataSet.statusbo'. Você pode movê-la ou removê-la conforme necessário.
            this.statusboTableAdapter.Fill(this._sas_1DataSet.statusbo);

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            var raFunc = Login.raFunc;
            var resultFunc = dbAccess.callSql("SELECT nome FROM funcionario WHERE ra = " + raFunc);
            var keyNome = resultFunc[0];

            var nomeFuncionario = keyNome["nome"];
            var boResposta = BO.respostaFunc;
            var analiseFunc = BO.analiseFunc;
            var data = dtData.Text;
            var hora = dtHora.Text;

            var status = cbStatus.SelectedValue.ToString();
            var dataHora = data + " " + hora;

            var solicitacao = Dashboard.solicitacaoNum;

            var consulta = dbAccess.callSql("SELECT analise, resposta FROM backoffice where num_solicitacao=" + solicitacao);
            var consultaKeys = consulta[0];

            var analiseContext = consultaKeys["analise"] + " " + nomeFuncionario + " - " + DateTime.Now + " : " + analiseFunc;
            var respostaContext = consultaKeys["resposta"] + " " + nomeFuncionario + " - " + DateTime.Now + " : " + boResposta;

            if (status == "3")
            {
                var resultUpdate = dbAccess.callSql("UPDATE backoffice SET analise='" + analiseContext + "' , resposta='" + respostaContext + "' , data_agendamento='" + data + "' , status_bo=" + status + " where num_solicitacao=" + solicitacao);
            }
            else if (status == "2")
            {
                //OleDbCommand cmd = new OleDbCommand("UPDATE backoffice SET analise='" + analiseContext + "' , resposta='" + respostaContext + "' , data_agendamento='" + data + "' , status_bo=" + status + " where num_solicitacao=" + solicitacao , connection);
                string ConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Juliana Assalti\\source\\repos\\Engenharia\\Engenharia\\sas-1.accdb";
                using (OleDbConnection conn = new OleDbConnection(ConnString))
                using (OleDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = @"UPDATE backoffice SET [analise] = '@analise', [resposta] = '@resposta', [dt_conclusao] = @dt_conclusao, [status_bo] = @status_bo WHERE num_solicitacao = @num_solicitacao";
                    command.Parameters.AddWithValue("@analise", analiseContext);
                    command.Parameters.AddWithValue("@resposta", respostaContext);
                    command.Parameters.AddWithValue("@dt_conclusao", Convert.ToDateTime(data));
                    command.Parameters.AddWithValue("@status_bo", Convert.ToInt32(status));
                    command.Parameters.AddWithValue("@num_solicitacao", Convert.ToInt32(solicitacao));

                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();
                }

            }
            else
            {
                var resultUpdate = dbAccess.callSql("UPDATE backoffice SET analise='" + analiseContext + "' , resposta='" + respostaContext + "' , status_bo=" + status + " where num_solicitacao=" + solicitacao);
            }
            //var resultKeys = resultUpdate[0];

            MessageBox.Show("Status atualizado");
            //this.Hide();

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var status = cbStatus.SelectedValue.ToString();

            if (status != "3")
            {
                dtData.Enabled = false;
                dtHora.Enabled = false;
            }
            else
            {
                dtData.Enabled = true;
                dtHora.Enabled = true;
            }
        }
    }
}
