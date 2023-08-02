
namespace Scheduler
{
    partial class MainForm
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
            this.AppoitmentsDGV = new System.Windows.Forms.DataGridView();
            this.CustomersDGV = new System.Windows.Forms.DataGridView();
            this.WeekViewRadio = new System.Windows.Forms.RadioButton();
            this.MonthViewRadio = new System.Windows.Forms.RadioButton();
            this.AllViewRadio = new System.Windows.Forms.RadioButton();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ReportsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AppoitmentsAddButton = new System.Windows.Forms.Button();
            this.AppoitmentsUpdateButton = new System.Windows.Forms.Button();
            this.AppoitmentsDeleteButton = new System.Windows.Forms.Button();
            this.CustomersAddButton = new System.Windows.Forms.Button();
            this.CustomersUpdateButton = new System.Windows.Forms.Button();
            this.CustomersDeleteButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppoitmentsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // AppoitmentsDGV
            // 
            this.AppoitmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppoitmentsDGV.Location = new System.Drawing.Point(17, 37);
            this.AppoitmentsDGV.Name = "AppoitmentsDGV";
            this.AppoitmentsDGV.Size = new System.Drawing.Size(718, 102);
            this.AppoitmentsDGV.TabIndex = 0;
            // 
            // CustomersDGV
            // 
            this.CustomersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersDGV.Location = new System.Drawing.Point(17, 226);
            this.CustomersDGV.Name = "CustomersDGV";
            this.CustomersDGV.Size = new System.Drawing.Size(723, 107);
            this.CustomersDGV.TabIndex = 1;
            // 
            // WeekViewRadio
            // 
            this.WeekViewRadio.AutoSize = true;
            this.WeekViewRadio.Location = new System.Drawing.Point(533, 12);
            this.WeekViewRadio.Name = "WeekViewRadio";
            this.WeekViewRadio.Size = new System.Drawing.Size(54, 17);
            this.WeekViewRadio.TabIndex = 2;
            this.WeekViewRadio.Text = "Week";
            this.WeekViewRadio.UseVisualStyleBackColor = true;
            this.WeekViewRadio.CheckedChanged += new System.EventHandler(this.WeekViewRadio_CheckedChanged);
            // 
            // MonthViewRadio
            // 
            this.MonthViewRadio.AutoSize = true;
            this.MonthViewRadio.Location = new System.Drawing.Point(616, 12);
            this.MonthViewRadio.Name = "MonthViewRadio";
            this.MonthViewRadio.Size = new System.Drawing.Size(55, 17);
            this.MonthViewRadio.TabIndex = 3;
            this.MonthViewRadio.Text = "Month";
            this.MonthViewRadio.UseVisualStyleBackColor = true;
            this.MonthViewRadio.CheckedChanged += new System.EventHandler(this.MonthViewRadio_CheckedChanged);
            // 
            // AllViewRadio
            // 
            this.AllViewRadio.AutoSize = true;
            this.AllViewRadio.Checked = true;
            this.AllViewRadio.Location = new System.Drawing.Point(699, 12);
            this.AllViewRadio.Name = "AllViewRadio";
            this.AllViewRadio.Size = new System.Drawing.Size(36, 17);
            this.AllViewRadio.TabIndex = 4;
            this.AllViewRadio.TabStop = true;
            this.AllViewRadio.Text = "All";
            this.AllViewRadio.UseVisualStyleBackColor = true;
            this.AllViewRadio.CheckedChanged += new System.EventHandler(this.AllViewRadio_CheckedChanged);
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.DarkRed;
            this.LogoutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogoutButton.Location = new System.Drawing.Point(712, 369);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(75, 23);
            this.LogoutButton.TabIndex = 5;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ReportsButton
            // 
            this.ReportsButton.Location = new System.Drawing.Point(582, 369);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(75, 23);
            this.ReportsButton.TabIndex = 6;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Appointments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Customers";
            // 
            // AppoitmentsAddButton
            // 
            this.AppoitmentsAddButton.Location = new System.Drawing.Point(17, 145);
            this.AppoitmentsAddButton.Name = "AppoitmentsAddButton";
            this.AppoitmentsAddButton.Size = new System.Drawing.Size(75, 23);
            this.AppoitmentsAddButton.TabIndex = 10;
            this.AppoitmentsAddButton.Text = "Add";
            this.AppoitmentsAddButton.UseVisualStyleBackColor = true;
            this.AppoitmentsAddButton.Click += new System.EventHandler(this.AppoitmentsAddButton_Click);
            // 
            // AppoitmentsUpdateButton
            // 
            this.AppoitmentsUpdateButton.Location = new System.Drawing.Point(122, 145);
            this.AppoitmentsUpdateButton.Name = "AppoitmentsUpdateButton";
            this.AppoitmentsUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.AppoitmentsUpdateButton.TabIndex = 11;
            this.AppoitmentsUpdateButton.Text = "Update";
            this.AppoitmentsUpdateButton.UseVisualStyleBackColor = true;
            this.AppoitmentsUpdateButton.Click += new System.EventHandler(this.AppoitmentsUpdateButton_Click);
            // 
            // AppoitmentsDeleteButton
            // 
            this.AppoitmentsDeleteButton.Location = new System.Drawing.Point(238, 145);
            this.AppoitmentsDeleteButton.Name = "AppoitmentsDeleteButton";
            this.AppoitmentsDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.AppoitmentsDeleteButton.TabIndex = 12;
            this.AppoitmentsDeleteButton.Text = "Delete";
            this.AppoitmentsDeleteButton.UseVisualStyleBackColor = true;
            this.AppoitmentsDeleteButton.Click += new System.EventHandler(this.AppoitmentsDeleteButton_Click);
            // 
            // CustomersAddButton
            // 
            this.CustomersAddButton.Location = new System.Drawing.Point(17, 338);
            this.CustomersAddButton.Name = "CustomersAddButton";
            this.CustomersAddButton.Size = new System.Drawing.Size(75, 23);
            this.CustomersAddButton.TabIndex = 13;
            this.CustomersAddButton.Text = "Add";
            this.CustomersAddButton.UseVisualStyleBackColor = true;
            this.CustomersAddButton.Click += new System.EventHandler(this.CustomersAddButton_Click);
            // 
            // CustomersUpdateButton
            // 
            this.CustomersUpdateButton.Location = new System.Drawing.Point(122, 339);
            this.CustomersUpdateButton.Name = "CustomersUpdateButton";
            this.CustomersUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.CustomersUpdateButton.TabIndex = 14;
            this.CustomersUpdateButton.Text = "Update";
            this.CustomersUpdateButton.UseVisualStyleBackColor = true;
            this.CustomersUpdateButton.Click += new System.EventHandler(this.CustomersUpdateButton_Click);
            // 
            // CustomersDeleteButton
            // 
            this.CustomersDeleteButton.Location = new System.Drawing.Point(238, 339);
            this.CustomersDeleteButton.Name = "CustomersDeleteButton";
            this.CustomersDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.CustomersDeleteButton.TabIndex = 15;
            this.CustomersDeleteButton.Text = "Delete";
            this.CustomersDeleteButton.UseVisualStyleBackColor = true;
            this.CustomersDeleteButton.Click += new System.EventHandler(this.CustomersDeleteButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(470, 369);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 404);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CustomersDeleteButton);
            this.Controls.Add(this.CustomersUpdateButton);
            this.Controls.Add(this.CustomersAddButton);
            this.Controls.Add(this.AppoitmentsDeleteButton);
            this.Controls.Add(this.AppoitmentsUpdateButton);
            this.Controls.Add(this.AppoitmentsAddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReportsButton);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.AllViewRadio);
            this.Controls.Add(this.MonthViewRadio);
            this.Controls.Add(this.WeekViewRadio);
            this.Controls.Add(this.CustomersDGV);
            this.Controls.Add(this.AppoitmentsDGV);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.AppoitmentsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AppoitmentsDGV;
        private System.Windows.Forms.DataGridView CustomersDGV;
        private System.Windows.Forms.RadioButton WeekViewRadio;
        private System.Windows.Forms.RadioButton MonthViewRadio;
        private System.Windows.Forms.RadioButton AllViewRadio;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button ReportsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AppoitmentsAddButton;
        private System.Windows.Forms.Button AppoitmentsUpdateButton;
        private System.Windows.Forms.Button AppoitmentsDeleteButton;
        private System.Windows.Forms.Button CustomersAddButton;
        private System.Windows.Forms.Button CustomersUpdateButton;
        private System.Windows.Forms.Button CustomersDeleteButton;
        private System.Windows.Forms.Button ExitButton;
    }
}