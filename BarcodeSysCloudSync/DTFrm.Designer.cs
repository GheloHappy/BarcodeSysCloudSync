namespace BarcodeSysCloudSync
{
    partial class DTFrm
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
            this.dtpDTDate = new System.Windows.Forms.DateTimePicker();
            this.btnDT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDTDate
            // 
            this.dtpDTDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Location = new System.Drawing.Point(12, 12);
            this.dtpDTDate.Name = "dtpDTDate";
            this.dtpDTDate.Size = new System.Drawing.Size(308, 33);
            this.dtpDTDate.TabIndex = 0;
            // 
            // btnDT
            // 
            this.btnDT.BackColor = System.Drawing.Color.Purple;
            this.btnDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDT.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDT.ForeColor = System.Drawing.Color.White;
            this.btnDT.Location = new System.Drawing.Point(12, 61);
            this.btnDT.Name = "btnDT";
            this.btnDT.Size = new System.Drawing.Size(309, 51);
            this.btnDT.TabIndex = 7;
            this.btnDT.Text = "Sync DT";
            this.btnDT.UseVisualStyleBackColor = false;
            this.btnDT.Click += new System.EventHandler(this.btnDT_Click);
            // 
            // DTFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 124);
            this.Controls.Add(this.btnDT);
            this.Controls.Add(this.dtpDTDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DTFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sync DT";
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker dtpDTDate;
        private Button btnDT;
    }
}