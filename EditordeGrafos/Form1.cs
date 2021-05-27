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
    public partial class Form1 : Form
    {
        public Form1(Graph g)
        {
            InitializeComponent();
            foreach (NodeP nodo2 in g) { nodo2.Visited = false; }
            foreach (NodeP nodo in g) // Buscar cada nodoP en el grafo G
            {
                if (nodo.Visited == false)
                {
                    bpf(nodo);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bpf(NodeP n)
        {
            n.Visited = true; // Visita el NODO
            Recorrido.Text = Recorrido.Text + n.Name + ", ";
            foreach (NodeR w in n.relations) 
            {
                if (w.Up.Visited == false) // Busca si el nodoR w fue visitado
                {
                    bpf(w.Up); // Regresa el nodoR como nodoP
                }
            } 
        }

        private void Recorrido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
