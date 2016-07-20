namespace USBFormatter
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.bgFormatter = new System.ComponentModel.BackgroundWorker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnFormat
            // 
            this.btnFormat.Enabled = false;
            this.btnFormat.Location = new System.Drawing.Point(12, 129);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.TabIndex = 0;
            this.btnFormat.Text = "Format Drive";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbDrives
            // 
            this.cbDrives.FormattingEnabled = true;
            this.cbDrives.Location = new System.Drawing.Point(12, 29);
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.Size = new System.Drawing.Size(259, 21);
            this.cbDrives.TabIndex = 2;
            this.cbDrives.DropDown += new System.EventHandler(this.cbDrives_DropDown);
            this.cbDrives.SelectedIndexChanged += new System.EventHandler(this.cbDrives_SelectedIndexChanged);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(12, 13);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(68, 13);
            this.lblSelect.TabIndex = 3;
            this.lblSelect.Text = "Select Drive:";
            // 
            // bgFormatter
            // 
            this.bgFormatter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFormatter_DoWork);
            this.bgFormatter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFormatter_RunWorkerCompleted);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(15, 71);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(61, 22);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "label1";
            this.lblProgress.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.cbDrives);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFormat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "Form1";
            this.Text = "USB Formatter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.Label lblSelect;
        private System.ComponentModel.BackgroundWorker bgFormatter;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Timer timer1;
    }
}

