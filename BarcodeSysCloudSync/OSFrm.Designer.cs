namespace BarcodeSysCloudSync
{
    partial class OSFrm
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
            this.btnOS = new System.Windows.Forms.Button();
            this.dtpDTDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnOS
            // 
            this.btnOS.BackColor = System.Drawing.Color.Green;
            this.btnOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOS.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOS.ForeColor = System.Drawing.Color.White;
            this.btnOS.Location = new System.Drawing.Point(12, 61);
            this.btnOS.Name = "btnOS";
            this.btnOS.Size = new System.Drawing.Size(309, 51);
            this.btnOS.TabIndex = 11;
            this.btnOS.Text = "Sync OS";
            this.btnOS.UseVisualStyleBackColor = false;
            this.btnOS.Click += new System.EventHandler(this.btnOS_Click);
            // 
            // dtpDTDate
            // 
            this.dtpDTDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Location = new System.Drawing.Point(12, 12);
            this.dtpDTDate.Name = "dtpDTDate";
            this.dtpDTDate.Size = new System.Drawing.Size(308, 33);
            this.dtpDTDate.TabIndex = 10;
            this.dtpDTDate.ValueChanged += new System.EventHandler(this.dtpDTDate_ValueChanged);
            // 
            // OSFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 124);
            this.Controls.Add(this.btnOS);
            this.Controls.Add(this.dtpDTDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OSFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSFrm";
            this.Load += new System.EventHandler(this.OSFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnOS;
        private DateTimePicker dtpDTDate;
    }
}