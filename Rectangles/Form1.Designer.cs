namespace Rectangles
{
    partial class Rectangles
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
            this.cbNumRectangles = new System.Windows.Forms.ComboBox();
            this.lblNumberRect = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnDrawFromFile = new System.Windows.Forms.Button();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cbNumRectangles
            // 
            this.cbNumRectangles.AllowDrop = true;
            this.cbNumRectangles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumRectangles.FormattingEnabled = true;
            this.cbNumRectangles.Location = new System.Drawing.Point(256, 39);
            this.cbNumRectangles.Name = "cbNumRectangles";
            this.cbNumRectangles.Size = new System.Drawing.Size(60, 21);
            this.cbNumRectangles.TabIndex = 0;
            // 
            // lblNumberRect
            // 
            this.lblNumberRect.AutoSize = true;
            this.lblNumberRect.Location = new System.Drawing.Point(23, 47);
            this.lblNumberRect.Name = "lblNumberRect";
            this.lblNumberRect.Size = new System.Drawing.Size(217, 13);
            this.lblNumberRect.TabIndex = 1;
            this.lblNumberRect.Text = "Please choose number of rectangles to draw";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.AutoSize = true;
            this.btnSaveToFile.Location = new System.Drawing.Point(344, 37);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(110, 23);
            this.btnSaveToFile.TabIndex = 2;
            this.btnSaveToFile.Text = "Generate to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnDrawFromFile
            // 
            this.btnDrawFromFile.AutoSize = true;
            this.btnDrawFromFile.Location = new System.Drawing.Point(470, 37);
            this.btnDrawFromFile.Name = "btnDrawFromFile";
            this.btnDrawFromFile.Size = new System.Drawing.Size(157, 23);
            this.btnDrawFromFile.TabIndex = 3;
            this.btnDrawFromFile.Text = "Draw rectangles from file";
            this.btnDrawFromFile.UseVisualStyleBackColor = true;
            this.btnDrawFromFile.Click += new System.EventHandler(this.btnDrawFromFile_Click);
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDisplay.AutoScroll = true;
            this.pnlDisplay.AutoSize = true;
            this.pnlDisplay.Location = new System.Drawing.Point(21, 84);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(1027, 233);
            this.pnlDisplay.TabIndex = 4;
            this.pnlDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDisplay_Paint);
            // 
            // Rectangles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 365);
            this.Controls.Add(this.pnlDisplay);
            this.Controls.Add(this.btnDrawFromFile);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.lblNumberRect);
            this.Controls.Add(this.cbNumRectangles);
            this.Name = "Rectangles";
            this.Text = "Rectangles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNumRectangles;
        private System.Windows.Forms.Label lblNumberRect;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnDrawFromFile;
        private System.Windows.Forms.Panel pnlDisplay;
    }
}

