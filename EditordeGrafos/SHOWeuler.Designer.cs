
namespace EditordeGrafos
{
    partial class SHOWeuler
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
            this.Texto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Texto
            // 
            this.Texto.AutoSize = true;
            this.Texto.Location = new System.Drawing.Point(13, 13);
            this.Texto.Name = "Texto";
            this.Texto.Size = new System.Drawing.Size(92, 13);
            this.Texto.TabIndex = 0;
            this.Texto.Text = "Camino Euleriano:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 233);
            this.textBox1.TabIndex = 1;
            // 
            // SHOWeuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 275);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Texto);
            this.Name = "SHOWeuler";
            this.Text = "SHOWeuler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Texto;
        private System.Windows.Forms.TextBox textBox1;
    }
}