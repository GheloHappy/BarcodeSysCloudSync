namespace BarcodeSysCloudSync
{
    partial class VanFrm
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
            this.btnVan = new System.Windows.Forms.Button();
            this.dtpDTDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnVan
            // 
            this.btnVan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnVan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVan.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVan.ForeColor = System.Drawing.Color.White;
            this.btnVan.Location = new System.Drawing.Point(12, 57);
            this.btnVan.Name = "btnVan";
            this.btnVan.Size = new System.Drawing.Size(309, 51);
            this.btnVan.TabIndex = 9;
            this.btnVan.Text = "Sync Van";
            this.btnVan.UseVisualStyleBackColor = false;
            this.btnVan.Click += new System.EventHandler(this.btnVan_Click);
            // 
            // dtpDTDate
            // 
            this.dtpDTDate.CalendarFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDTDate.Location = new System.Drawing.Point(12, 8);
            this.dtpDTDate.Name = "dtpDTDate";
            this.dtpDTDate.Size = new System.Drawing.Size(308, 33);
            this.dtpDTDate.TabIndex = 8;
            // 
            // VanFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 124);
            this.Controls.Add(this.btnVan);
            this.Controls.Add(this.dtpDTDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VanFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VanFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnVan;
        private DateTimePicker dtpDTDate;
    }
}