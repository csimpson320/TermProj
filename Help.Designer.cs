
namespace TermProj
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labGame1 = new System.Windows.Forms.Label();
            this.labGame2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.game2Pic = new System.Windows.Forms.PictureBox();
            this.game1Pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.game2Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game1Pic)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(346, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(720, 237);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // labGame1
            // 
            this.labGame1.AutoSize = true;
            this.labGame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGame1.Location = new System.Drawing.Point(22, 31);
            this.labGame1.Name = "labGame1";
            this.labGame1.Size = new System.Drawing.Size(235, 26);
            this.labGame1.TabIndex = 2;
            this.labGame1.Text = "How to play: Game 1";
            // 
            // labGame2
            // 
            this.labGame2.AutoSize = true;
            this.labGame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGame2.Location = new System.Drawing.Point(22, 388);
            this.labGame2.Name = "labGame2";
            this.labGame2.Size = new System.Drawing.Size(235, 26);
            this.labGame2.TabIndex = 4;
            this.labGame2.Text = "How to play: Game 2";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(346, 429);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(720, 237);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // game2Pic
            // 
            this.game2Pic.Image = global::TermProj.Properties.Resources.game2;
            this.game2Pic.Location = new System.Drawing.Point(27, 429);
            this.game2Pic.Name = "game2Pic";
            this.game2Pic.Size = new System.Drawing.Size(245, 251);
            this.game2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.game2Pic.TabIndex = 3;
            this.game2Pic.TabStop = false;
            // 
            // game1Pic
            // 
            this.game1Pic.Image = global::TermProj.Properties.Resources.game1;
            this.game1Pic.Location = new System.Drawing.Point(66, 100);
            this.game1Pic.Name = "game1Pic";
            this.game1Pic.Size = new System.Drawing.Size(169, 172);
            this.game1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.game1Pic.TabIndex = 0;
            this.game1Pic.TabStop = false;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 720);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.labGame2);
            this.Controls.Add(this.game2Pic);
            this.Controls.Add(this.labGame1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.game1Pic);
            this.Name = "Help";
            this.Text = "Help";
            ((System.ComponentModel.ISupportInitialize)(this.game2Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game1Pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox game1Pic;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labGame1;
        private System.Windows.Forms.PictureBox game2Pic;
        private System.Windows.Forms.Label labGame2;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}