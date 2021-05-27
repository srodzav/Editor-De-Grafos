
namespace EditordeGrafos
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
            this.Recorrido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Recorrido
            // 
            this.Recorrido.Location = new System.Drawing.Point(12, 12);
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.Size = new System.Drawing.Size(761, 20);
            this.Recorrido.TabIndex = 0;
            this.Recorrido.TextChanged += new System.EventHandler(this.Recorrido_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 39);
            this.Controls.Add(this.Recorrido);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Recorrido;
    }
}