namespace HospitalStHelena
{
    partial class frmListaFuncionarios
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
            this.btnAdicionarFuncionario = new System.Windows.Forms.Button();
            this.dataFuncionarios = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdicionarFuncionario
            // 
            this.btnAdicionarFuncionario.Location = new System.Drawing.Point(718, 480);
            this.btnAdicionarFuncionario.Name = "btnAdicionarFuncionario";
            this.btnAdicionarFuncionario.Size = new System.Drawing.Size(138, 75);
            this.btnAdicionarFuncionario.TabIndex = 1;
            this.btnAdicionarFuncionario.Text = "Adicionar Funcionário";
            this.btnAdicionarFuncionario.UseVisualStyleBackColor = true;
            this.btnAdicionarFuncionario.Click += new System.EventHandler(this.btnAdicionarFuncionario_Click);
            // 
            // dataFuncionarios
            // 
            this.dataFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFuncionarios.Location = new System.Drawing.Point(12, 12);
            this.dataFuncionarios.Name = "dataFuncionarios";
            this.dataFuncionarios.RowHeadersWidth = 62;
            this.dataFuncionarios.RowTemplate.Height = 28;
            this.dataFuncionarios.Size = new System.Drawing.Size(844, 462);
            this.dataFuncionarios.TabIndex = 2;
            // 
            // frmListaFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 562);
            this.Controls.Add(this.dataFuncionarios);
            this.Controls.Add(this.btnAdicionarFuncionario);
            this.Name = "frmListaFuncionarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionários";
            this.Load += new System.EventHandler(this.frmListaFuncionarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdicionarFuncionario;
        private System.Windows.Forms.DataGridView dataFuncionarios;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}