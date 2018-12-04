namespace Engenharia
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.loginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtBO = new System.Windows.Forms.TextBox();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backofficeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._sas_1DataSet = new Engenharia._sas_1DataSet();
            this.backofficeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.backofficeTableAdapter = new Engenharia._sas_1DataSetTableAdapters.backofficeTableAdapter();
            this.loginTableAdapter1 = new Engenharia._sas_1DataSetTableAdapters.loginTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDigito = new System.Windows.Forms.TextBox();
            this.statusboTableAdapter = new Engenharia._sas_1DataSetTableAdapters.statusboTableAdapter();
            this.tableAdapterManager = new Engenharia._sas_1DataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.loginBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backofficeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sas_1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backofficeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBindingSource
            // 
            this.loginBindingSource.DataMember = "login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 1;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nº B.O:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(339, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ag:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(339, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Conta:";
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // txtBO
            // 
            this.txtBO.Location = new System.Drawing.Point(144, 116);
            this.txtBO.Name = "txtBO";
            this.txtBO.Size = new System.Drawing.Size(138, 27);
            this.txtBO.TabIndex = 7;
            this.txtBO.TextChanged += new System.EventHandler(this.txtBO_TextChanged);
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(399, 80);
            this.txtAgencia.MaxLength = 6;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(89, 27);
            this.txtAgencia.TabIndex = 8;
            // 
            // txtConta
            // 
            this.txtConta.Location = new System.Drawing.Point(399, 147);
            this.txtConta.Name = "txtConta";
            this.txtConta.Size = new System.Drawing.Size(89, 27);
            this.txtConta.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(579, 108);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(95, 36);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(41, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(633, 204);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // backofficeBindingSource1
            // 
            this.backofficeBindingSource1.DataMember = "backoffice";
            this.backofficeBindingSource1.DataSource = this._sas_1DataSet;
            // 
            // _sas_1DataSet
            // 
            this._sas_1DataSet.DataSetName = "_sas_1DataSet";
            this._sas_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // backofficeBindingSource
            // 
            this.backofficeBindingSource.DataMember = "backoffice";
            this.backofficeBindingSource.CurrentChanged += new System.EventHandler(this.backofficeBindingSource_CurrentChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(204, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Consulta de Solicitações";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Location = new System.Drawing.Point(312, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(2, 102);
            this.label21.TabIndex = 29;
            // 
            // backofficeTableAdapter
            // 
            this.backofficeTableAdapter.ClearBeforeFill = true;
            // 
            // loginTableAdapter1
            // 
            this.loginTableAdapter1.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "-";
            // 
            // txtDigito
            // 
            this.txtDigito.Location = new System.Drawing.Point(515, 147);
            this.txtDigito.MaxLength = 2;
            this.txtDigito.Name = "txtDigito";
            this.txtDigito.Size = new System.Drawing.Size(31, 27);
            this.txtDigito.TabIndex = 31;
            // 
            // statusboTableAdapter
            // 
            this.statusboTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.agenciaTableAdapter = null;
            this.tableAdapterManager.backofficeTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.binaTableAdapter = null;
            this.tableAdapterManager.clienteTableAdapter = null;
            this.tableAdapterManager.contaTableAdapter = null;
            this.tableAdapterManager.enderecoTableAdapter = null;
            this.tableAdapterManager.funcionarioTableAdapter = null;
            this.tableAdapterManager.historico_chavesegTableAdapter = null;
            this.tableAdapterManager.loginTableAdapter = null;
            this.tableAdapterManager.modalidade_contaTableAdapter = null;
            this.tableAdapterManager.recarga_celularTableAdapter = null;
            this.tableAdapterManager.referencia_contatoTableAdapter = null;
            this.tableAdapterManager.status_contaTableAdapter = null;
            this.tableAdapterManager.statusboTableAdapter = this.statusboTableAdapter;
            this.tableAdapterManager.telefoneTableAdapter = null;
            this.tableAdapterManager.tipo_contaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Engenharia._sas_1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(721, 470);
            this.Controls.Add(this.txtDigito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtConta);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.txtBO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAS - Sistema de Automação de Segurança";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loginBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backofficeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sas_1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backofficeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private _sas_1DataSet sasDataSet;
        private System.Windows.Forms.BindingSource loginBindingSource;
        //private sasDataSetTableAdapters.loginTableAdapter1 loginTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txtBO;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource backofficeBindingSource;
        //private sasDataSetTableAdapters.backofficeTableAdapter backofficeTableAdapter;
        private System.Windows.Forms.Label label6;
        //private sasDataSetTableAdapters.clienteTableAdapter clienteTableAdapter1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn numsolicitacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtaberturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusboDataGridViewTextBoxColumn;
        private _sas_1DataSet _sas_1DataSet;
        private System.Windows.Forms.BindingSource backofficeBindingSource1;
        private _sas_1DataSetTableAdapters.backofficeTableAdapter backofficeTableAdapter;
        private _sas_1DataSetTableAdapters.loginTableAdapter loginTableAdapter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDigito;
        private _sas_1DataSetTableAdapters.statusboTableAdapter statusboTableAdapter;
        private _sas_1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}