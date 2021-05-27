
namespace EditordeGrafos
{
    partial class SHOWbpf
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
            this.tT_bpf = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Recorrido
            // 
            this.Recorrido.AutoSize = true;
            this.Recorrido.Location = new System.Drawing.Point(13, 13);
            this.Recorrido.Name = "Recorrido";
            this.Recorrido.Size = new System.Drawing.Size(79, 13);
            this.Recorrido.TabIndex = 0;
            this.Recorrido.Text = "Recorrido BPF:";
            this.Recorrido.Click += new System.EventHandler(this.Recorrido_Click);
            // 
            // tT_bpf
            // 
            this.tT_bpf.Location = new System.Drawing.Point(16, 35);
            this.tT_bpf.Name = "tT_bpf";
            this.tT_bpf.Size = new System.Drawing.Size(285, 20);
            this.tT_bpf.TabIndex = 1;
            // 
            // SHOWbpf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 67);
            this.Controls.Add(this.tT_bpf);
            this.Controls.Add(this.Recorrido);
            this.Name = "SHOWbpf";
            this.Text = "Recorrido BPF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Recorrido;
        private System.Windows.Forms.TextBox tT_bpf;
    }
}