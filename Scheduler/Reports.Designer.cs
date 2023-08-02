
namespace Scheduler
{
    partial class Reports
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.AppointmentConsultantDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentTypeDGV = new System.Windows.Forms.DataGridView();
            this.AppointmentCustomerDGV = new System.Windows.Forms.DataGridView();
            this.ConsultantCombo = new System.Windows.Forms.ComboBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CustomerCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentConsultantDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentTypeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentCustomerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reports";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Appointment By Consultant";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Appointment By Type/Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Appointment By Customer";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(616, 473);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AppointmentConsultantDGV
            // 
            this.AppointmentConsultantDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentConsultantDGV.Location = new System.Drawing.Point(15, 57);
            this.AppointmentConsultantDGV.Name = "AppointmentConsultantDGV";
            this.AppointmentConsultantDGV.Size = new System.Drawing.Size(645, 140);
            this.AppointmentConsultantDGV.TabIndex = 5;
            // 
            // AppointmentTypeDGV
            // 
            this.AppointmentTypeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentTypeDGV.Location = new System.Drawing.Point(15, 250);
            this.AppointmentTypeDGV.Name = "AppointmentTypeDGV";
            this.AppointmentTypeDGV.Size = new System.Drawing.Size(283, 207);
            this.AppointmentTypeDGV.TabIndex = 6;
            // 
            // AppointmentCustomerDGV
            // 
            this.AppointmentCustomerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentCustomerDGV.Location = new System.Drawing.Point(377, 250);
            this.AppointmentCustomerDGV.Name = "AppointmentCustomerDGV";
            this.AppointmentCustomerDGV.Size = new System.Drawing.Size(283, 207);
            this.AppointmentCustomerDGV.TabIndex = 7;
            // 
            // ConsultantCombo
            // 
            this.ConsultantCombo.BackColor = System.Drawing.SystemColors.Window;
            this.ConsultantCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConsultantCombo.FormattingEnabled = true;
            this.ConsultantCombo.Location = new System.Drawing.Point(528, 30);
            this.ConsultantCombo.Name = "ConsultantCombo";
            this.ConsultantCombo.Size = new System.Drawing.Size(121, 21);
            this.ConsultantCombo.TabIndex = 8;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(110, 473);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CustomerCombo
            // 
            this.CustomerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerCombo.FormattingEnabled = true;
            this.CustomerCombo.Location = new System.Drawing.Point(542, 223);
            this.CustomerCombo.Name = "CustomerCombo";
            this.CustomerCombo.Size = new System.Drawing.Size(121, 21);
            this.CustomerCombo.TabIndex = 10;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 497);
            this.Controls.Add(this.CustomerCombo);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ConsultantCombo);
            this.Controls.Add(this.AppointmentCustomerDGV);
            this.Controls.Add(this.AppointmentTypeDGV);
            this.Controls.Add(this.AppointmentConsultantDGV);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Reports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentConsultantDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentTypeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentCustomerDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView AppointmentConsultantDGV;
        private System.Windows.Forms.DataGridView AppointmentTypeDGV;
        private System.Windows.Forms.DataGridView AppointmentCustomerDGV;
        private System.Windows.Forms.ComboBox ConsultantCombo;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ComboBox CustomerCombo;
    }
}