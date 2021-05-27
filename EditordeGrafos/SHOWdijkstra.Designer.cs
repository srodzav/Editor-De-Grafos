
namespace EditordeGrafos
{
    partial class SHOWdijkstra
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.DijkstraIniciate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NodosRecorridosBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VectorSolucionBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CostoCaminoBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vertice Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vertice Final";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(90, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(90, 41);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // DijkstraIniciate
            // 
            this.DijkstraIniciate.Location = new System.Drawing.Point(217, 13);
            this.DijkstraIniciate.Name = "DijkstraIniciate";
            this.DijkstraIniciate.Size = new System.Drawing.Size(75, 49);
            this.DijkstraIniciate.TabIndex = 4;
            this.DijkstraIniciate.Text = "Dijkstra";
            this.DijkstraIniciate.UseVisualStyleBackColor = true;
            this.DijkstraIniciate.Click += new System.EventHandler(this.CastingDijkstra);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Recorrido de Nodos:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // NodosRecorridosBox
            // 
            this.NodosRecorridosBox.Location = new System.Drawing.Point(16, 91);
            this.NodosRecorridosBox.Name = "NodosRecorridosBox";
            this.NodosRecorridosBox.Size = new System.Drawing.Size(274, 20);
            this.NodosRecorridosBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vector D";
            // 
            // VectorSolucionBox
            // 
            this.VectorSolucionBox.Location = new System.Drawing.Point(16, 135);
            this.VectorSolucionBox.Name = "VectorSolucionBox";
            this.VectorSolucionBox.Size = new System.Drawing.Size(274, 20);
            this.VectorSolucionBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Costo";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // CostoCaminoBox
            // 
            this.CostoCaminoBox.Location = new System.Drawing.Point(16, 179);
            this.CostoCaminoBox.Name = "CostoCaminoBox";
            this.CostoCaminoBox.Size = new System.Drawing.Size(274, 20);
            this.CostoCaminoBox.TabIndex = 10;
            // 
            // SHOWdijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 215);
            this.Controls.Add(this.CostoCaminoBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VectorSolucionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NodosRecorridosBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DijkstraIniciate);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SHOWdijkstra";
            this.Text = "SHOWdijkstra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button DijkstraIniciate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NodosRecorridosBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VectorSolucionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CostoCaminoBox;
    }
}