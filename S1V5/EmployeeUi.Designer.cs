

using System.Windows.Forms;

namespace S1V5
{
    partial class EmployeeUi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            brnSeach = new Button();
            btnClear = new Button();
            txtSearchName = new TextBox();
            label1 = new Label();
            cmbSearchGender = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtName = new TextBox();
            txtNic = new TextBox();
            txtMobile = new TextBox();
            txtEmail = new TextBox();
            cmbDesignation = new ComboBox();
            cmbStatus = new ComboBox();
            cmbGender = new ComboBox();
            txtDate = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClearForm = new Button();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Location = new Point(12, 433);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(791, 315);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // brnSeach
            // 
            brnSeach.Location = new Point(565, 383);
            brnSeach.Name = "brnSeach";
            brnSeach.Size = new Size(94, 29);
            brnSeach.TabIndex = 1;
            brnSeach.Text = "Search";
            brnSeach.UseVisualStyleBackColor = true;
            brnSeach.Click += SeachByName;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(690, 383);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += ClearSearch;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(92, 383);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.PlaceholderText = "Enter Search Name";
            txtSearchName.Size = new Size(204, 27);
            txtSearchName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 385);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 4;
            label1.Text = "Name :";
            // 
            // cmbSearchGender
            // 
            cmbSearchGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchGender.FormattingEnabled = true;
            cmbSearchGender.Location = new Point(388, 384);
            cmbSearchGender.Name = "cmbSearchGender";
            cmbSearchGender.Size = new Size(151, 28);
            cmbSearchGender.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 387);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 6;
            label2.Text = "Gender :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 19);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 7;
            label3.Text = "Name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 65);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 8;
            label4.Text = "DOB :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(360, 65);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 9;
            label5.Text = "Gender :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 114);
            label6.Name = "label6";
            label6.Size = new Size(40, 20);
            label6.TabIndex = 10;
            label6.Text = "NIC :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 163);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 11;
            label7.Text = "Mobile :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 215);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 12;
            label8.Text = "Email :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 268);
            label9.Name = "label9";
            label9.Size = new Size(96, 20);
            label9.TabIndex = 13;
            label9.Text = "Designation :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(356, 268);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 14;
            label10.Text = "Status :";
            // 
            // txtName
            // 
            txtName.Location = new Point(131, 16);
            txtName.Name = "txtName";
            txtName.Size = new Size(204, 27);
            txtName.TabIndex = 15;
            txtName.KeyUp += txtNameKC;
            // 
            // txtNic
            // 
            txtNic.Location = new Point(131, 111);
            txtNic.Name = "txtNic";
            txtNic.Size = new Size(204, 27);
            txtNic.TabIndex = 17;
            txtNic.KeyUp += txtNicKC;
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(131, 160);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(204, 27);
            txtMobile.TabIndex = 18;
            txtMobile.KeyUp += txtMobileKC;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(131, 212);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(204, 27);
            txtEmail.TabIndex = 19;
            txtEmail.KeyUp += txtEmailKC;
            // 
            // cmbDesignation
            // 
            cmbDesignation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDesignation.FormattingEnabled = true;
            cmbDesignation.Location = new Point(131, 265);
            cmbDesignation.Name = "cmbDesignation";
            cmbDesignation.Size = new Size(204, 28);
            cmbDesignation.TabIndex = 20;
            cmbDesignation.SelectedValueChanged += cmbDesignationAP;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(427, 265);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(204, 28);
            cmbStatus.TabIndex = 21;
            cmbStatus.SelectedValueChanged += cmbStatusAP;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(427, 62);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(204, 28);
            cmbGender.TabIndex = 22;
            cmbGender.SelectedValueChanged += cmbGenderAP;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(131, 62);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(204, 27);
            txtDate.TabIndex = 23;
            txtDate.MaxDate = DateTime.Now;
            txtDate.ValueChanged += txtDatePC;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(92, 325);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += Add;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(263, 325);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(440, 325);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClearForm
            // 
            btnClearForm.Location = new Point(619, 325);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(94, 29);
            btnClearForm.TabIndex = 27;
            btnClearForm.Text = "Clear";
            btnClearForm.UseVisualStyleBackColor = true;
            btnClearForm.Click += ClearForm;
            // 
            // EmployeeUi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 760);
            Controls.Add(btnClearForm);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtDate);
            Controls.Add(cmbGender);
            Controls.Add(cmbStatus);
            Controls.Add(cmbDesignation);
            Controls.Add(txtEmail);
            Controls.Add(txtMobile);
            Controls.Add(txtNic);
            Controls.Add(txtName);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbSearchGender);
            Controls.Add(label1);
            Controls.Add(txtSearchName);
            Controls.Add(btnClear);
            Controls.Add(brnSeach);
            Controls.Add(tableLayoutPanel1);
            Name = "EmployeeUi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Real Time Validation";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button brnSeach;
        private Button btnClear;
        private TextBox txtSearchName;
        private Label label1;
        private ComboBox cmbSearchGender;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtName;
        private TextBox txtNic;
        private TextBox txtMobile;
        private TextBox txtEmail;
        private ComboBox cmbDesignation;
        private ComboBox cmbStatus;
        private ComboBox cmbGender;
        private DateTimePicker txtDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClearForm;
    }
}
