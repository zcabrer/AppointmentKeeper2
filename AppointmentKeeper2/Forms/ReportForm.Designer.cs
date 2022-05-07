
namespace AppointmentKeeper2.Forms
{
    partial class ReportForm
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
            this.pkrType = new System.Windows.Forms.ComboBox();
            this.pkrMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pkrUser = new System.Windows.Forms.ComboBox();
            this.dgvUserReport = new System.Windows.Forms.DataGridView();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelResult2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Appointment Types by Month";
            // 
            // pkrType
            // 
            this.pkrType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pkrType.FormattingEnabled = true;
            this.pkrType.Location = new System.Drawing.Point(210, 106);
            this.pkrType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrType.Name = "pkrType";
            this.pkrType.Size = new System.Drawing.Size(180, 28);
            this.pkrType.TabIndex = 10;
            this.pkrType.DropDownClosed += new System.EventHandler(this.pkrType_DropDownClosed);
            // 
            // pkrMonth
            // 
            this.pkrMonth.FormattingEnabled = true;
            this.pkrMonth.Location = new System.Drawing.Point(520, 106);
            this.pkrMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrMonth.Name = "pkrMonth";
            this.pkrMonth.Size = new System.Drawing.Size(180, 28);
            this.pkrMonth.TabIndex = 11;
            this.pkrMonth.DropDownClosed += new System.EventHandler(this.pkrMonth_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Month";
            // 
            // lblResult1
            // 
            this.lblResult1.AutoSize = true;
            this.lblResult1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult1.Location = new System.Drawing.Point(357, 168);
            this.lblResult1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(324, 39);
            this.lblResult1.TabIndex = 14;
            this.lblResult1.Text = "Result Shows Here";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Consultant Schedules";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 306);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Consultant";
            // 
            // pkrUser
            // 
            this.pkrUser.FormattingEnabled = true;
            this.pkrUser.Location = new System.Drawing.Point(210, 305);
            this.pkrUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pkrUser.Name = "pkrUser";
            this.pkrUser.Size = new System.Drawing.Size(180, 28);
            this.pkrUser.TabIndex = 17;
            this.pkrUser.DropDownClosed += new System.EventHandler(this.pkrUser_DropDownClosed);
            // 
            // dgvUserReport
            // 
            this.dgvUserReport.AllowUserToResizeRows = false;
            this.dgvUserReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserReport.Location = new System.Drawing.Point(93, 360);
            this.dgvUserReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvUserReport.MultiSelect = false;
            this.dgvUserReport.Name = "dgvUserReport";
            this.dgvUserReport.ReadOnly = true;
            this.dgvUserReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvUserReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserReport.Size = new System.Drawing.Size(1222, 462);
            this.dgvUserReport.TabIndex = 18;
            // 
            // lblResult2
            // 
            this.lblResult2.AutoSize = true;
            this.lblResult2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult2.Location = new System.Drawing.Point(38, 905);
            this.lblResult2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(502, 32);
            this.lblResult2.TabIndex = 19;
            this.lblResult2.Text = "Total appointments for all consultants: ";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(1162, 989);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(153, 52);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(215, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 44);
            this.label6.TabIndex = 21;
            this.label6.Text = "Count:";
            // 
            // labelResult2
            // 
            this.labelResult2.AutoSize = true;
            this.labelResult2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult2.Location = new System.Drawing.Point(548, 910);
            this.labelResult2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult2.Name = "labelResult2";
            this.labelResult2.Size = new System.Drawing.Size(216, 26);
            this.labelResult2.TabIndex = 22;
            this.labelResult2.Text = "Result Shows Here";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 1060);
            this.Controls.Add(this.labelResult2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.dgvUserReport);
            this.Controls.Add(this.pkrUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblResult1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pkrMonth);
            this.Controls.Add(this.pkrType);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportForm";
            this.Text = "Reports";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pkrType;
        private System.Windows.Forms.ComboBox pkrMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox pkrUser;
        private System.Windows.Forms.DataGridView dgvUserReport;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelResult2;
    }
}