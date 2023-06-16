namespace BarcodeSysCloudSync
{
    partial class MainFrm
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
            this.btnDT = new System.Windows.Forms.Button();
            this.btnSyncDate = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnOs = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVan
            // 
            this.btnVan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnVan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVan.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVan.ForeColor = System.Drawing.Color.White;
            this.btnVan.Location = new System.Drawing.Point(186, 35);
            this.btnVan.Name = "btnVan";
            this.btnVan.Size = new System.Drawing.Size(178, 91);
            this.btnVan.TabIndex = 7;
            this.btnVan.Text = "VAN";
            this.btnVan.UseVisualStyleBackColor = false;
            this.btnVan.Click += new System.EventHandler(this.btnOS_Click);
            // 
            // btnDT
            // 
            this.btnDT.BackColor = System.Drawing.Color.Purple;
            this.btnDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDT.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDT.ForeColor = System.Drawing.Color.White;
            this.btnDT.Location = new System.Drawing.Point(6, 35);
            this.btnDT.Name = "btnDT";
            this.btnDT.Size = new System.Drawing.Size(178, 91);
            this.btnDT.TabIndex = 6;
            this.btnDT.Text = "DT";
            this.btnDT.UseVisualStyleBackColor = false;
            this.btnDT.Click += new System.EventHandler(this.btnDT_Click);
            // 
            // btnSyncDate
            // 
            this.btnSyncDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSyncDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncDate.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSyncDate.ForeColor = System.Drawing.Color.White;
            this.btnSyncDate.Location = new System.Drawing.Point(5, 229);
            this.btnSyncDate.Name = "btnSyncDate";
            this.btnSyncDate.Size = new System.Drawing.Size(358, 69);
            this.btnSyncDate.TabIndex = 9;
            this.btnSyncDate.Text = "Sync with date";
            this.btnSyncDate.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(6, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(133, 20);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "connection status";
            // 
            // btnOs
            // 
            this.btnOs.BackColor = System.Drawing.Color.Green;
            this.btnOs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOs.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOs.ForeColor = System.Drawing.Color.White;
            this.btnOs.Location = new System.Drawing.Point(5, 132);
            this.btnOs.Name = "btnOs";
            this.btnOs.Size = new System.Drawing.Size(178, 91);
            this.btnOs.TabIndex = 11;
            this.btnOs.Text = "OS";
            this.btnOs.UseVisualStyleBackColor = false;
            this.btnOs.Click += new System.EventHandler(this.btnOs_Click_1);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.Color.Red;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.Location = new System.Drawing.Point(186, 132);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(178, 91);
            this.btnIssue.TabIndex = 12;
            this.btnIssue.Text = "ISSUING";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 304);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnOs);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSyncDate);
            this.Controls.Add(this.btnVan);
            this.Controls.Add(this.btnDT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode System Cloud Sync";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnVan;
        private Button btnDT;
        private Button btnSyncDate;
        private Label lblStatus;
        private Button btnOs;
        private Button btnIssue;
    }
}