using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engenharia
{
    public partial class Login : Form
    {

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        public static string raFunc = "";

        public Login()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sasDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = txtUser.Text;
            string psw = txtPass.Text;

            var result = dbAccess.callSql("SELECT * FROM login where usuario='" + txtUser.Text + "' AND senha='" + txtPass.Text + "'");
      

            if (Convert.ToString(result.Count) == "0")
            {
                MessageBox.Show("Usuário ou senha inválidos");
            }
            else
            {
                var resultData = result[0];
                Dashboard f2 = new Dashboard();

                raFunc = resultData["ra"].ToString();

                txtPass.Clear();
                txtUser.Clear();

                f2.Show();
                
                this.Hide();

                f2.FormClosed += (ev, args) =>
                {
                    this.Show();
                };
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
