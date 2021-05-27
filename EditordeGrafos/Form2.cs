using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class Form2 : Form
    {
        public Form2(Graph g)
        {
            InitializeComponent();
            foreach (NodeP nodo2 in g) { nodo2.Visited = false; }
            foreach (NodeP nodo in g) // Buscar cada nodoP en el grafo G
            {
                if (nodo.Visited == false)
                {
                    bea(nodo, g);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bea(NodeP v, Graph c)
        {
            v.Visited = true;
            pone_en_cola(v, c);
            foreach (NodeR r in v.relations)
            {
                foreach (NodeP x in c) { x.Visited = false; }
                quita_de_cola(c);
                foreach (NodeR y in x.relations)
                {
                    if (v.Visited == false)
                    {
                        v.Visited = true;
                        pone_en_cola(y.Up, c);
                        Recorrido.Text = "( " + x.Name + "|" + y.Name + ")" + ", T" ;
                    }
                }
            }
        }

        private void pone_en_cola(NodeP v, Graph c)
        {
            // 
        }

        private void quita_de_cola(Graph c)
        {
            //
        }
    }
}
