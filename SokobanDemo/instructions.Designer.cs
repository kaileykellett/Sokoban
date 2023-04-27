namespace SokobanDemo
{
    partial class instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(instructions));
            this.lblInstructionHead = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.pbGraphicInstruct = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphicInstruct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstructionHead
            // 
            this.lblInstructionHead.AutoSize = true;
            this.lblInstructionHead.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructionHead.Location = new System.Drawing.Point(148, 9);
            this.lblInstructionHead.Name = "lblInstructionHead";
            this.lblInstructionHead.Size = new System.Drawing.Size(164, 37);
            this.lblInstructionHead.TabIndex = 0;
            this.lblInstructionHead.Text = "Instructions";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(21, 109);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(414, 273);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // pbGraphicInstruct
            // 
            this.pbGraphicInstruct.Location = new System.Drawing.Point(116, 49);
            this.pbGraphicInstruct.Name = "pbGraphicInstruct";
            this.pbGraphicInstruct.Size = new System.Drawing.Size(216, 44);
            this.pbGraphicInstruct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGraphicInstruct.TabIndex = 2;
            this.pbGraphicInstruct.TabStop = false;
            // 
            // instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(456, 400);
            this.Controls.Add(this.pbGraphicInstruct);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblInstructionHead);
            this.MaximizeBox = false;
            this.Name = "instructions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructions";
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphicInstruct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructionHead;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.PictureBox pbGraphicInstruct;
    }
}