namespace BeautySalonView
{
    partial class FormReportOrders
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBoxXls = new System.Windows.Forms.CheckBox();
            this.checkBoxDoc = new System.Windows.Forms.CheckBox();
            this.comboBoxFIO = new System.Windows.Forms.ComboBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.buttonReportOrders = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ФИО клиента:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.checkBoxXls);
            this.groupBox.Controls.Add(this.checkBoxDoc);
            this.groupBox.Location = new System.Drawing.Point(541, 12);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(96, 82);
            this.groupBox.TabIndex = 13;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Формат";
            // 
            // checkBoxXls
            // 
            this.checkBoxXls.AutoSize = true;
            this.checkBoxXls.Location = new System.Drawing.Point(5, 48);
            this.checkBoxXls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxXls.Name = "checkBoxXls";
            this.checkBoxXls.Size = new System.Drawing.Size(50, 21);
            this.checkBoxXls.TabIndex = 1;
            this.checkBoxXls.Text = ".xls";
            this.checkBoxXls.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoc
            // 
            this.checkBoxDoc.AutoSize = true;
            this.checkBoxDoc.Location = new System.Drawing.Point(5, 21);
            this.checkBoxDoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxDoc.Name = "checkBoxDoc";
            this.checkBoxDoc.Size = new System.Drawing.Size(57, 21);
            this.checkBoxDoc.TabIndex = 0;
            this.checkBoxDoc.Text = ".doc";
            this.checkBoxDoc.UseVisualStyleBackColor = true;
            // 
            // comboBoxFIO
            // 
            this.comboBoxFIO.FormattingEnabled = true;
            this.comboBoxFIO.Location = new System.Drawing.Point(170, 23);
            this.comboBoxFIO.Name = "comboBoxFIO";
            this.comboBoxFIO.Size = new System.Drawing.Size(351, 24);
            this.comboBoxFIO.TabIndex = 14;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(169, 67);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(351, 22);
            this.textBoxMail.TabIndex = 15;
            // 
            // buttonReportOrders
            // 
            this.buttonReportOrders.Location = new System.Drawing.Point(238, 110);
            this.buttonReportOrders.Name = "buttonReportOrders";
            this.buttonReportOrders.Size = new System.Drawing.Size(182, 39);
            this.buttonReportOrders.TabIndex = 16;
            this.buttonReportOrders.Text = "Отправить ";
            this.buttonReportOrders.UseVisualStyleBackColor = true;
            this.buttonReportOrders.Click += new System.EventHandler(this.buttonReportOrders_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(455, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 39);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEmail
            // 
            this.buttonEmail.Location = new System.Drawing.Point(30, 110);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(182, 39);
            this.buttonEmail.TabIndex = 18;
            this.buttonEmail.Text = "Получить Email";
            this.buttonEmail.UseVisualStyleBackColor = true;
            this.buttonEmail.Click += new System.EventHandler(this.buttonEmail_Click);
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 172);
            this.Controls.Add(this.buttonEmail);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonReportOrders);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.comboBoxFIO);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReportOrders";
            this.Text = "Отправка счетов клиенту";
            this.Load += new System.EventHandler(this.FormReportOrders_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox checkBoxXls;
        private System.Windows.Forms.CheckBox checkBoxDoc;
        private System.Windows.Forms.ComboBox comboBoxFIO;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Button buttonReportOrders;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEmail;
    }
}