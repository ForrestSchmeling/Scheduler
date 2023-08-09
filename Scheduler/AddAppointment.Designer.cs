﻿
namespace Scheduler
{
    partial class AddAppointment
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CustomerTextBox = new System.Windows.Forms.TextBox();
            this.ContactCombo = new System.Windows.Forms.ComboBox();
            this.TypeCombo = new System.Windows.Forms.ComboBox();
            this.LocationCombo = new System.Windows.Forms.ComboBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AppointmentSaveButton = new System.Windows.Forms.Button();
            this.AppointmentCancelButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Location";
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(133, 247);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(198, 20);
            this.StartDateTimePicker.TabIndex = 7;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(133, 294);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDateTimePicker.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Start DateTime";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "End Date Time";
            // 
            // CustomerTextBox
            // 
            this.CustomerTextBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CustomerTextBox.Location = new System.Drawing.Point(133, 37);
            this.CustomerTextBox.Name = "CustomerTextBox";
            this.CustomerTextBox.ReadOnly = true;
            this.CustomerTextBox.Size = new System.Drawing.Size(121, 20);
            this.CustomerTextBox.TabIndex = 11;
            // 
            // ContactCombo
            // 
            this.ContactCombo.BackColor = System.Drawing.SystemColors.Window;
            this.ContactCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContactCombo.FormattingEnabled = true;
            this.ContactCombo.Location = new System.Drawing.Point(133, 63);
            this.ContactCombo.Name = "ContactCombo";
            this.ContactCombo.Size = new System.Drawing.Size(121, 21);
            this.ContactCombo.TabIndex = 12;
            // 
            // TypeCombo
            // 
            this.TypeCombo.BackColor = System.Drawing.SystemColors.Window;
            this.TypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCombo.FormattingEnabled = true;
            this.TypeCombo.Location = new System.Drawing.Point(133, 128);
            this.TypeCombo.Name = "TypeCombo";
            this.TypeCombo.Size = new System.Drawing.Size(121, 21);
            this.TypeCombo.TabIndex = 13;
            // 
            // LocationCombo
            // 
            this.LocationCombo.BackColor = System.Drawing.SystemColors.Window;
            this.LocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationCombo.FormattingEnabled = true;
            this.LocationCombo.Location = new System.Drawing.Point(133, 171);
            this.LocationCombo.Name = "LocationCombo";
            this.LocationCombo.Size = new System.Drawing.Size(121, 21);
            this.LocationCombo.TabIndex = 14;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(133, 93);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(121, 20);
            this.TitleTextBox.TabIndex = 15;
            // 
            // AppointmentSaveButton
            // 
            this.AppointmentSaveButton.Location = new System.Drawing.Point(133, 352);
            this.AppointmentSaveButton.Name = "AppointmentSaveButton";
            this.AppointmentSaveButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentSaveButton.TabIndex = 16;
            this.AppointmentSaveButton.Text = "Save";
            this.AppointmentSaveButton.UseVisualStyleBackColor = true;
            this.AppointmentSaveButton.Click += new System.EventHandler(this.AppointmentSaveButton_Click);
            // 
            // AppointmentCancelButton
            // 
            this.AppointmentCancelButton.Location = new System.Drawing.Point(324, 352);
            this.AppointmentCancelButton.Name = "AppointmentCancelButton";
            this.AppointmentCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AppointmentCancelButton.TabIndex = 17;
            this.AppointmentCancelButton.Text = "Cancel";
            this.AppointmentCancelButton.UseVisualStyleBackColor = true;
            this.AppointmentCancelButton.Click += new System.EventHandler(this.AppointmentCancelButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Description";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 19;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 406);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.AppointmentCancelButton);
            this.Controls.Add(this.AppointmentSaveButton);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.LocationCombo);
            this.Controls.Add(this.TypeCombo);
            this.Controls.Add(this.ContactCombo);
            this.Controls.Add(this.CustomerTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AddAppointment";
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CustomerTextBox;
        private System.Windows.Forms.ComboBox ContactCombo;
        private System.Windows.Forms.ComboBox TypeCombo;
        private System.Windows.Forms.ComboBox LocationCombo;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Button AppointmentSaveButton;
        private System.Windows.Forms.Button AppointmentCancelButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
    }
}