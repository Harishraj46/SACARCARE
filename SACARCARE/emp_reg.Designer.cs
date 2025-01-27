namespace SACARCARE
{
    partial class emp_reg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(emp_reg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtdob = new System.Windows.Forms.DateTimePicker();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.rdmale = new System.Windows.Forms.RadioButton();
            this.rdfemale = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbrole = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ph = new System.Windows.Forms.TextBox();
            this.txt_salary = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.lbledit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 27);
            this.panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.MediumPurple;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.Location = new System.Drawing.Point(669, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(27, 21);
            this.btn_close.TabIndex = 7;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(277, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = " Employee registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name :";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(153, 73);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(507, 23);
            this.txt_name.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date of Birth :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(396, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gender :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Address :";
            // 
            // dtdob
            // 
            this.dtdob.CustomFormat = "dd/MM/yyy";
            this.dtdob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdob.Location = new System.Drawing.Point(153, 132);
            this.dtdob.Name = "dtdob";
            this.dtdob.Size = new System.Drawing.Size(206, 23);
            this.dtdob.TabIndex = 3;
            this.dtdob.Value = new System.DateTime(2024, 5, 24, 13, 20, 0, 0);
            this.dtdob.ValueChanged += new System.EventHandler(this.dtdob_ValueChanged);
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(153, 178);
            this.txt_address.Multiline = true;
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(507, 80);
            this.txt_address.TabIndex = 2;
            // 
            // rdmale
            // 
            this.rdmale.AutoSize = true;
            this.rdmale.Checked = true;
            this.rdmale.Location = new System.Drawing.Point(492, 134);
            this.rdmale.Name = "rdmale";
            this.rdmale.Size = new System.Drawing.Size(57, 21);
            this.rdmale.TabIndex = 4;
            this.rdmale.TabStop = true;
            this.rdmale.Text = "Male";
            this.rdmale.UseVisualStyleBackColor = true;
            this.rdmale.CheckedChanged += new System.EventHandler(this.rdmale_CheckedChanged);
            // 
            // rdfemale
            // 
            this.rdfemale.AutoSize = true;
            this.rdfemale.Location = new System.Drawing.Point(564, 134);
            this.rdfemale.Name = "rdfemale";
            this.rdfemale.Size = new System.Drawing.Size(73, 21);
            this.rdfemale.TabIndex = 4;
            this.rdfemale.Text = "Female";
            this.rdfemale.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Role :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Salary :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(383, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Password :";
            // 
            // cbrole
            // 
            this.cbrole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbrole.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbrole.FormattingEnabled = true;
            this.cbrole.Items.AddRange(new object[] {
            "Worker",
            "supervisor",
            "cashier",
            "manager"});
            this.cbrole.Location = new System.Drawing.Point(153, 273);
            this.cbrole.Name = "cbrole";
            this.cbrole.Size = new System.Drawing.Size(217, 25);
            this.cbrole.TabIndex = 5;
            this.cbrole.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(396, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Phone :";
            // 
            // txt_ph
            // 
            this.txt_ph.Location = new System.Drawing.Point(478, 278);
            this.txt_ph.Name = "txt_ph";
            this.txt_ph.Size = new System.Drawing.Size(182, 23);
            this.txt_ph.TabIndex = 2;
            this.txt_ph.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txt_salary
            // 
            this.txt_salary.Location = new System.Drawing.Point(153, 319);
            this.txt_salary.Name = "txt_salary";
            this.txt_salary.Size = new System.Drawing.Size(217, 23);
            this.txt_salary.TabIndex = 2;
            this.txt_salary.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(478, 322);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(182, 23);
            this.txt_pwd.TabIndex = 2;
            this.txt_pwd.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_save.Location = new System.Drawing.Point(168, 385);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(111, 46);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.IndianRed;
            this.btn_cancel.Location = new System.Drawing.Point(526, 385);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(111, 46);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_update.Location = new System.Drawing.Point(349, 385);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(111, 46);
            this.btn_update.TabIndex = 6;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lbledit
            // 
            this.lbledit.AutoSize = true;
            this.lbledit.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbledit.ForeColor = System.Drawing.Color.Black;
            this.lbledit.Location = new System.Drawing.Point(13, 397);
            this.lbledit.Name = "lbledit";
            this.lbledit.Size = new System.Drawing.Size(37, 20);
            this.lbledit.TabIndex = 1;
            this.lbledit.Text = "edit";
            this.lbledit.Visible = false;
            // 
            // employee_reg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(708, 453);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cbrole);
            this.Controls.Add(this.rdfemale);
            this.Controls.Add(this.rdmale);
            this.Controls.Add(this.dtdob);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_salary);
            this.Controls.Add(this.txt_ph);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbledit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "employee_reg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "employee_reg";
            this.Load += new System.EventHandler(this.employee_reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txt_name;
        public System.Windows.Forms.DateTimePicker dtdob;
        public System.Windows.Forms.TextBox txt_address;
        public System.Windows.Forms.RadioButton rdmale;
        public System.Windows.Forms.RadioButton rdfemale;
        public System.Windows.Forms.ComboBox cbrole;
        public System.Windows.Forms.TextBox txt_ph;
        public System.Windows.Forms.TextBox txt_salary;
        public System.Windows.Forms.TextBox txt_pwd;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_close;
        public System.Windows.Forms.Label lbledit;
    }
}