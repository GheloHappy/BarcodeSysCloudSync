namespace BarcodeSysCloudSync
{
    partial class IssuingFrm
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
            this.btnIssue = new System.Windows.Forms.Button();
            this.dtpDTDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.Red;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(12, 61);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(309, 51);
            this.btnIssue.TabIndex = 13;
            this.btnIssue.Text = "Sync ISSUING";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // dtpDTDate
            // 
            this.dtpDTDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Location = new System.Drawing.Point(12, 12);
            this.dtpDTDate.Name = "dtpDTDate";
            this.dtpDTDate.Size = new System.Drawing.Size(308, 33);
            this.dtpDTDate.TabIndex = 12;
            // 
            // IssuingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 124);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.dtpDTDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IssuingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IssuingFrm";
            this.Load += new System.EventHandler(this.IssuingFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnIssue;
        private DateTimePicker dtpDTDate;
    }
}