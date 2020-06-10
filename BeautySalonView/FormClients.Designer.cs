namespace BeautySalonView
{
    partial class FormClients
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
            this.labelFIO = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonBan = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonUnBan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(346, 7);
            this.labelFIO.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(88, 24);
            this.labelFIO.TabIndex = 1;
            this.labelFIO.Text = "Клиенты";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 50);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(672, 271);
            this.dataGridView.TabIndex = 2;
            // 
            // buttonBan
            // 
            this.buttonBan.Location = new System.Drawing.Point(704, 50);
            this.buttonBan.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(158, 31);
            this.buttonBan.TabIndex = 4;
            this.buttonBan.Text = "Бан";
            this.buttonBan.UseVisualStyleBackColor = true;
            this.buttonBan.Click += new System.EventHandler(this.buttonBan_Click);
            // 
            // buttonUnBan
            // 
            this.buttonUnBan.Location = new System.Drawing.Point(704, 106);
            this.buttonUnBan.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUnBan.Name = "buttonUnBan";
            this.buttonUnBan.Size = new System.Drawing.Size(158, 31);
            this.buttonUnBan.TabIndex = 7;
            this.buttonUnBan.Text = "Разбан";
            this.buttonUnBan.UseVisualStyleBackColor = true;
            this.buttonUnBan.Click += new System.EventHandler(this.buttonUnBan_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(704, 161);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(158, 31);
            this.buttonDel.TabIndex = 5;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(704, 216);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(158, 31);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 370);
            this.Controls.Add(this.buttonUnBan);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelFIO);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormClients";
            this.Text = "FormClients";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonBan;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonUnBan;
    }
}