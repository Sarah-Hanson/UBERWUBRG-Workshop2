namespace Workshop2_TravelExperts {
    partial class FrmTravel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTravel));
            this.cmbPackages = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPackID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCommision = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPackages
            // 
            this.cmbPackages.FormattingEnabled = true;
            this.cmbPackages.Location = new System.Drawing.Point(195, 44);
            this.cmbPackages.Name = "cmbPackages";
            this.cmbPackages.Size = new System.Drawing.Size(318, 32);
            this.cmbPackages.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(528, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(210, 31);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Package Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Package ID";
            // 
            // lblPackID
            // 
            this.lblPackID.Location = new System.Drawing.Point(191, 108);
            this.lblPackID.Name = "lblPackID";
            this.lblPackID.Size = new System.Drawing.Size(322, 24);
            this.lblPackID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Start Date";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(191, 173);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(322, 24);
            this.lblStart.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "End Date";
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(191, 234);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(322, 24);
            this.lblEnd.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "Description";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(191, 294);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(547, 24);
            this.lblDesc.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "Base Price";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(191, 362);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(322, 24);
            this.lblPrice.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 436);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 24);
            this.label12.TabIndex = 13;
            this.label12.Text = "Agency Commision";
            // 
            // lblCommision
            // 
            this.lblCommision.Location = new System.Drawing.Point(191, 436);
            this.lblCommision.Name = "lblCommision";
            this.lblCommision.Size = new System.Drawing.Size(322, 24);
            this.lblCommision.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(16, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add New Package";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(217, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 31);
            this.button2.TabIndex = 16;
            this.button2.Text = "Edit Package";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // FrmTravel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Workshop2_TravelExperts.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 633);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCommision);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPackID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbPackages);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FrmTravel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travel Experts";
            this.Load += new System.EventHandler(this.FrmTravel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPackages;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPackID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCommision;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

