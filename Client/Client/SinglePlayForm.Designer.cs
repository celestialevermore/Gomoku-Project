namespace Client
{
    partial class SinglePlayForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlayButton = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Location = new System.Drawing.Point(32, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 786);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(1022, 42);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(100, 40);
            this.PlayButton.TabIndex = 2;
            this.PlayButton.Text = "GameStart";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(935, 123);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(272, 15);
            this.Status.TabIndex = 3;
            this.Status.Text = "Push the GameStart button";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Status.Click += new System.EventHandler(this.label1_Click);
            // 
            // SinglePlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 1053);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SinglePlayForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SinglePlayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label Status;
    }
}