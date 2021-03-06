﻿namespace HHsystem.Forms
{
    partial class SettingForm
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.employeecombobox = new System.Windows.Forms.ComboBox();
            this.clientcombobox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.servicecombobox = new System.Windows.Forms.ComboBox();
            this.timehourscombobox = new System.Windows.Forms.ComboBox();
            this.timeminutescombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Red;
            this.btn_cancel.Location = new System.Drawing.Point(129, 349);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(82, 31);
            this.btn_cancel.TabIndex = 48;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_add.Location = new System.Drawing.Point(31, 349);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(82, 31);
            this.btn_add.TabIndex = 47;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Client";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Employee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 49;
            this.label4.Text = "Make Appointment";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(25, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 2);
            this.label3.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Service";
            // 
            // employeecombobox
            // 
            this.employeecombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeecombobox.FormattingEnabled = true;
            this.employeecombobox.Location = new System.Drawing.Point(31, 89);
            this.employeecombobox.Name = "employeecombobox";
            this.employeecombobox.Size = new System.Drawing.Size(180, 21);
            this.employeecombobox.TabIndex = 58;
            // 
            // clientcombobox
            // 
            this.clientcombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientcombobox.FormattingEnabled = true;
            this.clientcombobox.Location = new System.Drawing.Point(31, 139);
            this.clientcombobox.Name = "clientcombobox";
            this.clientcombobox.Size = new System.Drawing.Size(180, 21);
            this.clientcombobox.TabIndex = 59;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "";
            this.dateTimePicker.Location = new System.Drawing.Point(31, 190);
            this.dateTimePicker.MinDate = new System.DateTime(2018, 10, 11, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(180, 20);
            this.dateTimePicker.TabIndex = 60;
            // 
            // servicecombobox
            // 
            this.servicecombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.servicecombobox.FormattingEnabled = true;
            this.servicecombobox.Location = new System.Drawing.Point(31, 292);
            this.servicecombobox.Name = "servicecombobox";
            this.servicecombobox.Size = new System.Drawing.Size(180, 21);
            this.servicecombobox.TabIndex = 61;
            // 
            // timehourscombobox
            // 
            this.timehourscombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timehourscombobox.FormattingEnabled = true;
            this.timehourscombobox.Location = new System.Drawing.Point(31, 241);
            this.timehourscombobox.Name = "timehourscombobox";
            this.timehourscombobox.Size = new System.Drawing.Size(44, 21);
            this.timehourscombobox.TabIndex = 62;
            // 
            // timeminutescombobox
            // 
            this.timeminutescombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeminutescombobox.FormattingEnabled = true;
            this.timeminutescombobox.Location = new System.Drawing.Point(81, 241);
            this.timeminutescombobox.Name = "timeminutescombobox";
            this.timeminutescombobox.Size = new System.Drawing.Size(44, 21);
            this.timeminutescombobox.TabIndex = 63;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(248, 412);
            this.ControlBox = false;
            this.Controls.Add(this.timeminutescombobox);
            this.Controls.Add(this.timehourscombobox);
            this.Controls.Add(this.servicecombobox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.clientcombobox);
            this.Controls.Add(this.employeecombobox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox employeecombobox;
        private System.Windows.Forms.ComboBox clientcombobox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox servicecombobox;
        private System.Windows.Forms.ComboBox timehourscombobox;
        private System.Windows.Forms.ComboBox timeminutescombobox;
    }
}