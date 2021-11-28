
namespace TermProj
{
    partial class History
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
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstHistory
            // 
            this.lstHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 20;
            this.lstHistory.Location = new System.Drawing.Point(31, 29);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(851, 464);
            this.lstHistory.Sorted = true;
            this.lstHistory.TabIndex = 0;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 523);
            this.Controls.Add(this.lstHistory);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(926, 562);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(926, 562);
            this.Name = "History";
            this.Text = "History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstHistory;
    }
}