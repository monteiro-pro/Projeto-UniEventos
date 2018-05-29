namespace Telas
{
    partial class EmpresaLogada
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
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listServicos = new System.Windows.Forms.ListView();
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(408, 405);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(121, 51);
            this.btnSair.TabIndex = 17;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(197, 405);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(151, 51);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar Perfil";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.listServicos);
            this.groupBox1.Controls.Add(this.btnCadastrar);
            this.groupBox1.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 327);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serviços Cadastrados";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // listServicos
            // 
            this.listServicos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Nome,
            this.Tipo,
            this.Valor});
            this.listServicos.FullRowSelect = true;
            this.listServicos.GridLines = true;
            this.listServicos.Location = new System.Drawing.Point(17, 35);
            this.listServicos.Name = "listServicos";
            this.listServicos.Size = new System.Drawing.Size(548, 275);
            this.listServicos.TabIndex = 16;
            this.listServicos.UseCompatibleStateImageBehavior = false;
            this.listServicos.View = System.Windows.Forms.View.Details;
            this.listServicos.SelectedIndexChanged += new System.EventHandler(this.listServicos_SelectedIndexChanged);
            // 
            // Nome
            // 
            this.Nome.Text = "Nome do Serviço";
            this.Nome.Width = 250;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 186;
            // 
            // Valor
            // 
            this.Valor.Text = "Valor";
            this.Valor.Width = 106;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(571, 35);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(161, 56);
            this.btnCadastrar.TabIndex = 15;
            this.btnCadastrar.Text = "Cadastr. Serviço";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(571, 111);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(158, 56);
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.Text = "Excluir Serviço";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 32;
            // 
            // EmpresaLogada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 482);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmpresaLogada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpresaLogada";
            this.Load += new System.EventHandler(this.EmpresaLogada_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.ListView listServicos;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Valor;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ColumnHeader ID;
    }
}