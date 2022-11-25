
namespace quarto
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.p1Lbl = new System.Windows.Forms.Label();
            this.p2Lbl = new System.Windows.Forms.Label();
            this.kijonLbl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // p1Lbl
            // 
            this.p1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.p1Lbl.Location = new System.Drawing.Point(12, 9);
            this.p1Lbl.Name = "p1Lbl";
            this.p1Lbl.Size = new System.Drawing.Size(183, 25);
            this.p1Lbl.TabIndex = 0;
            this.p1Lbl.Text = "text";
            this.p1Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // p2Lbl
            // 
            this.p2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.p2Lbl.Location = new System.Drawing.Point(12, 34);
            this.p2Lbl.Name = "p2Lbl";
            this.p2Lbl.Size = new System.Drawing.Size(183, 25);
            this.p2Lbl.TabIndex = 1;
            this.p2Lbl.Text = "text";
            this.p2Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kijonLbl
            // 
            this.kijonLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kijonLbl.Location = new System.Drawing.Point(12, 92);
            this.kijonLbl.Name = "kijonLbl";
            this.kijonLbl.Size = new System.Drawing.Size(183, 25);
            this.kijonLbl.TabIndex = 2;
            this.kijonLbl.Text = "text";
            this.kijonLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Valami okos szöveg amit később kell kitalálni";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(468, 252);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.kijonLbl);
            this.Controls.Add(this.p2Lbl);
            this.Controls.Add(this.p1Lbl);
            this.DoubleBuffered = true;
            this.Name = "Game";
            this.Text = "Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label p1Lbl;
        private System.Windows.Forms.Label p2Lbl;
        private System.Windows.Forms.Label kijonLbl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}