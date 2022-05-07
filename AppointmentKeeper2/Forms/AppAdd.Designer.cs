
using System.Windows.Forms;

namespace AppointmentKeeper2.Forms
{
    partial class AppAdd
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pkrCustomer = new System.Windows.Forms.ComboBox();
            this.pkrTime = new System.Windows.Forms.DateTimePicker();
            this.pkrDuration = new System.Windows.Forms.ComboBox();
            this.pkrUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pkrType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(51, 477);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 52);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(334, 477);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 52);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Duration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 143);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Type";
            // 
            // pkrCustomer
            // 
            this.pkrCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pkrCustomer.FormattingEnabled = true;
            this.pkrCustomer.Location = new System.Drawing.Point(188, 137);
            this.pkrCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrCustomer.Name = "pkrCustomer";
            this.pkrCustomer.Size = new System.Drawing.Size(298, 28);
            this.pkrCustomer.TabIndex = 42;
            // 
            // pkrTime
            // 
            this.pkrTime.CustomFormat = "MM/dd/yyyy HH:mm";
            this.pkrTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrTime.Location = new System.Drawing.Point(188, 218);
            this.pkrTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrTime.MinDate = System.DateTime.Now;
            this.pkrTime.Name = "pkrTime";
            this.pkrTime.ShowUpDown = true;
            this.pkrTime.Size = new System.Drawing.Size(298, 26);
            this.pkrTime.TabIndex = 43;
            // 
            // pkrDuration
            // 
            this.pkrDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pkrDuration.FormattingEnabled = true;
            this.pkrDuration.Location = new System.Drawing.Point(188, 286);
            this.pkrDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrDuration.Name = "pkrDuration";
            this.pkrDuration.Size = new System.Drawing.Size(298, 28);
            this.pkrDuration.TabIndex = 44;
            // 
            // pkrUser
            // 
            this.pkrUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pkrUser.FormattingEnabled = true;
            this.pkrUser.Location = new System.Drawing.Point(188, 355);
            this.pkrUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrUser.Name = "pkrUser";
            this.pkrUser.Size = new System.Drawing.Size(298, 28);
            this.pkrUser.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 362);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "Consultant";
            // 
            // pkrType
            // 
            this.pkrType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pkrType.FormattingEnabled = true;
            this.pkrType.Location = new System.Drawing.Point(188, 69);
            this.pkrType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrType.Name = "pkrType";
            this.pkrType.Size = new System.Drawing.Size(298, 28);
            this.pkrType.TabIndex = 41;
            // 
            // AppAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 548);
            this.Controls.Add(this.pkrUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pkrDuration);
            this.Controls.Add(this.pkrTime);
            this.Controls.Add(this.pkrCustomer);
            this.Controls.Add(this.pkrType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AppAdd";
            this.Text = "New Appointment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppAdd_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox pkrCustomer;
        private System.Windows.Forms.DateTimePicker pkrTime;
        private System.Windows.Forms.ComboBox pkrDuration;
        private System.Windows.Forms.ComboBox pkrUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox pkrType;
    }
}