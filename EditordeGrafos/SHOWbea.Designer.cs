
namespace EditordeGrafos
{
    partial class SHOWbea
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
            this.Recorrido = new System.Windows.Forms.Label();
            this.tT_bea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Recorrido
            // 
            this.Recorrido.AutoSize = true;
            this.Recorrido.Location = new System.Drawing.Point(13, 13);
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.Size = new System.Drawing.Size(80, 13);
            this.Recorrido.TabIndex = 0;
            this.Recorrido.Text = "Recorrido BEA:";
            this.Recorrido.Click += new System.EventHandler(this.Recorrido_Click);
            // 
            // tT_bea
            // 
            this.tT_bea.Location = new System.Drawing.Point(13, 36);
            this.tT_bea.Name = "tT_bea";
            this.tT_bea.Size = new System.Drawing.Size(392, 20);
            this.tT_bea.TabIndex = 2;
            // 
            // SHOWbea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 68);
            this.Controls.Add(this.tT_bea);
            this.Controls.Add(this.Recorrido);
            this.Name = "SHOWbea";
            this.Text = "Recorrido BEA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Recorrido;
        private System.Windows.Forms.TextBox tT_bea;
    }
}