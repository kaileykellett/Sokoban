namespace SokobanDemo
{
    partial class startForm
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
            this.pbCreepyFarm = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSubHeading = new System.Windows.Forms.Label();
            this.btnInstruct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreepyFarm)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCreepyFarm
            // 
            this.pbCreepyFarm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCreepyFarm.Location = new System.Drawing.Point(140, 67);
            this.pbCreepyFarm.Name = "pbCreepyFarm";
            this.pbCreepyFarm.Size = new System.Drawing.Size(199, 137);
            this.pbCreepyFarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCreepyFarm.TabIndex = 0;
            this.pbCreepyFarm.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Red;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(113, 210);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 66);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start the Groove!";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(79, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(332, 40);
            this.lblHeading.TabIndex = 2;
            this.lblHeading.Text = "Welcome to Sokoban!";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubHeading
            // 
            this.lblSubHeading.AutoSize = true;
            this.lblSubHeading.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubHeading.Location = new System.Drawing.Point(175, 38);
            this.lblSubHeading.Name = "lblSubHeading";
            this.lblSubHeading.Size = new System.Drawing.Size(139, 26);
            this.lblSubHeading.TabIndex = 3;
            this.lblSubHeading.Text = "Farm  Version";
            // 
            // btnInstruct
            // 
            this.btnInstruct.BackColor = System.Drawing.Color.Red;
            this.btnInstruct.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstruct.Location = new System.Drawing.Point(232, 210);
            this.btnInstruct.Name = "btnInstruct";
            this.btnInstruct.Size = new System.Drawing.Size(125, 66);
            this.btnInstruct.TabIndex = 1;
            this.btnInstruct.Text = "Instructions";
            this.btnInstruct.UseVisualStyleBackColor = false;
            this.btnInstruct.Click += new System.EventHandler(this.btnInstruct_Click);
            // 
            // startForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(477, 315);
            this.Controls.Add(this.lblSubHeading);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnInstruct);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbCreepyFarm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "startForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome!";
            ((System.ComponentModel.ISupportInitialize)(this.pbCreepyFarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCreepyFarm;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblSubHeading;
        private System.Windows.Forms.Button btnInstruct;
    }
}