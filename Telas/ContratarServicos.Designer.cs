﻿namespace Telas
{
    partial class ContratarServicos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnContratar = new System.Windows.Forms.Button();
            this.listServicos = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.slcTipoServico = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnContratar);
            this.groupBox1.Controls.Add(this.listServicos);
            this.groupBox1.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 333);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serviços Cadastrados";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelar.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(630, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(161, 56);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Voltar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContratar
            // 
            this.btnContratar.BackColor = System.Drawing.Color.Lime;
            this.btnContratar.Font = new System.Drawing.Font("Lato", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContratar.ForeColor = System.Drawing.Color.White;
            this.btnContratar.Location = new System.Drawing.Point(630, 26);
            this.btnContratar.Name = "btnContratar";
            this.btnContratar.Size = new System.Drawing.Size(161, 56);
            this.btnContratar.TabIndex = 15;
            this.btnContratar.Text = "Contratar";
            this.btnContratar.UseVisualStyleBackColor = false;
            this.btnContratar.Click += new System.EventHandler(this.btnContratar_Click);
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
            this.listServicos.Location = new System.Drawing.Point(49, 26);
            this.listServicos.Name = "listServicos";
            this.listServicos.Size = new System.Drawing.Size(548, 275);
            this.listServicos.TabIndex = 1;
            this.listServicos.UseCompatibleStateImageBehavior = false;
            this.listServicos.View = System.Windows.Forms.View.Details;
            this.listServicos.SelectedIndexChanged += new System.EventHandler(this.listServicos_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 49;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome do Serviço";
            this.Nome.Width = 250;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 144;
            // 
            // Valor
            // 
            this.Valor.Text = "Valor";
            this.Valor.Width = 106;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(191, 100);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(286, 33);
            this.txtNome.TabIndex = 18;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Filtar Por Nome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtar Por Tipo:";
            // 
            // slcTipoServico
            // 
            this.slcTipoServico.AccessibleName = "";
            this.slcTipoServico.Font = new System.Drawing.Font("Lato", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slcTipoServico.FormattingEnabled = true;
            this.slcTipoServico.Items.AddRange(new object[] {
            "Não Escolher Tipo...",
            "Entretenimento",
            "Espaço",
            "Alimento",
            "Equipamento"});
            this.slcTipoServico.Location = new System.Drawing.Point(191, 39);
            this.slcTipoServico.Name = "slcTipoServico";
            this.slcTipoServico.Size = new System.Drawing.Size(286, 33);
            this.slcTipoServico.TabIndex = 20;
            this.slcTipoServico.Text = "Escolha um Tipo...";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.btnListar);
            this.groupBox2.Controls.Add(this.btnPesquisar);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.slcTipoServico);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 514);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contratar Serviço";
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.Gray;
            this.btnListar.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ForeColor = System.Drawing.Color.White;
            this.btnListar.Location = new System.Drawing.Point(684, 34);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(128, 45);
            this.btnListar.TabIndex = 21;
            this.btnListar.Text = "Listar Tudo";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.Gray;
            this.btnPesquisar.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(513, 34);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(128, 45);
            this.btnPesquisar.TabIndex = 17;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // ContratarServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(874, 550);
            this.Controls.Add(this.groupBox2);
            this.Name = "ContratarServicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContratarServicos";
            this.Load += new System.EventHandler(this.ContratarServicos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnContratar;
        private System.Windows.Forms.ListView listServicos;
        private System.Windows.Forms.ColumnHeader Tipo;
        private System.Windows.Forms.ColumnHeader Valor;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ComboBox slcTipoServico;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnPesquisar;
    }
}