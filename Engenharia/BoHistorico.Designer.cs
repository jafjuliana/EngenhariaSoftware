namespace Engenharia
{
    partial class BO_Historico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BO_Historico));
            this.txtAnalisesAnteriores = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAnalisesAnteriores
            // 
            this.txtAnalisesAnteriores.Enabled = false;
            this.txtAnalisesAnteriores.Location = new System.Drawing.Point(24, 65);
            this.txtAnalisesAnteriores.Multiline = true;
            this.txtAnalisesAnteriores.Name = "txtAnalisesAnteriores";
            this.txtAnalisesAnteriores.Size = new System.Drawing.Size(424, 130);
            this.txtAnalisesAnteriores.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(129, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "Análises anteriores";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // BO_Historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 221);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAnalisesAnteriores);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BO_Historico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAS - Sistema de Automação de Segurança";
            this.Load += new System.EventHandler(this.BO_Historico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAnalisesAnteriores;
        private System.Windows.Forms.Label label6;
    }
}