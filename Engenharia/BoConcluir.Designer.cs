namespace Engenharia
{
    partial class BO_Concluir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BO_Concluir));
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.statusboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._sas_1DataSet = new Engenharia._sas_1DataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.statusboTableAdapter = new Engenharia._sas_1DataSetTableAdapters.statusboTableAdapter();
            this.btnAtualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sas_1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.DataSource = this.statusboBindingSource;
            this.cbStatus.DisplayMember = "statusbo";
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(114, 68);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(193, 27);
            this.cbStatus.TabIndex = 0;
            this.cbStatus.ValueMember = "id_statusbo";
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // statusboBindingSource
            // 
            this.statusboBindingSource.DataMember = "statusbo";
            this.statusboBindingSource.DataSource = this._sas_1DataSet;
            // 
            // _sas_1DataSet
            // 
            this._sas_1DataSet.DataSetName = "_sas_1DataSet";
            this._sas_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hora:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 143);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 27);
            this.textBox2.TabIndex = 5;
            // 
            // dtData
            // 
            this.dtData.CustomFormat = "dd/MM/yyyy";
            this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtData.Location = new System.Drawing.Point(114, 105);
            this.dtData.MinDate = new System.DateTime(2018, 11, 29, 15, 44, 38, 0);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(193, 27);
            this.dtData.TabIndex = 6;
            this.dtData.Value = new System.DateTime(2018, 11, 29, 15, 44, 38, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Conclusão";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dtHora
            // 
            this.dtHora.CustomFormat = "HH:mm";
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHora.Location = new System.Drawing.Point(114, 143);
            this.dtHora.Name = "dtHora";
            this.dtHora.Size = new System.Drawing.Size(193, 27);
            this.dtHora.TabIndex = 14;
            // 
            // statusboTableAdapter
            // 
            this.statusboTableAdapter.ClearBeforeFill = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(129, 188);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(98, 33);
            this.btnAtualizar.TabIndex = 15;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // BO_Concluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 242);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.dtHora);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtData);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStatus);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BO_Concluir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAS - Sistema de Automação de Segurança";
            this.Load += new System.EventHandler(this.BO_Concluir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sas_1DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtHora;
        private _sas_1DataSet _sas_1DataSet;
        private System.Windows.Forms.BindingSource statusboBindingSource;
        private _sas_1DataSetTableAdapters.statusboTableAdapter statusboTableAdapter;
        private System.Windows.Forms.Button btnAtualizar;
    }
}