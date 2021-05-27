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
    public partial class SHOWdijkstra : Form
    {
        Graph graph;
        private string[,] costos;
        NodeP origen, destino;

        public SHOWdijkstra(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
            showA();

        }

        public void showA()
        {
            comboBox1.Items.Clear();
            foreach (NodeP p in graph)
            {
                comboBox1.Items.Add(p.Name);
            }
        }

        public void showB(NodeP n)
        {
            comboBox2.Items.Clear();
            foreach (NodeP p in graph)
            {
                if (p != n)
                {
                    comboBox2.Items.Add(p.Name);
                }
            }
        }

        private void CastingDijkstra(object sender, EventArgs e)
        {
            Dijkstra(origen, destino);
        }

        public void Dijkstra(NodeP origen, NodeP destino)
        {
            List<NodeP> V = new List<NodeP>();
            List<NodeP> S = new List<NodeP>();
            string[] D = new string[graph.Count];
            NodeP[] R = new NodeP[graph.Count];
            NodeP w = new NodeP();
            int index, nodeIndex;
            nodeIndex = 0;
            string smenor = "x";
            bool foundw = false;
            string path, checkR;

            MatrizCostos();

            S.Add(origen);

            foreach (NodeP p in graph)
            {
                V.Add(p);
                if (p != origen)
                {
                    D[graph.IndexOf(p)] = costos[graph.IndexOf(origen), graph.IndexOf(p)];
                    if (D[graph.IndexOf(p)] != "x")
                    {
                        R[graph.IndexOf(p)] = graph[graph.IndexOf(origen)];
                    }
                }
                else
                {
                    D[graph.IndexOf(p)] = "0";
                    R[graph.IndexOf(p)] = graph[graph.IndexOf(p)];
                }
            }
            foreach (NodeP p in graph)
            {
                index = -1;
                smenor = "x";
                foundw = false;
                foreach (string dw in D)
                {
                    index++;
                    if (!S.Contains(V[index]))
                    {
                        if (dw != "x")
                        {
                            if (smenor != "x")
                            {
                                if (Convert.ToInt32(dw) < Convert.ToInt32(smenor))
                                {
                                    smenor = dw;
                                    nodeIndex = index;
                                    foundw = true;
                                }
                            }
                            else
                            {
                                smenor = dw;
                                nodeIndex = index;
                                foundw = true;
                            }
                        }
                    }
                }
                if (foundw)
                {
                    w = graph[nodeIndex];
                    S.Add(w);
                }
                if (S.Count > 0 && foundw)
                {
                    foreach (NodeP v in V)
                    {
                        if (!S.Contains(v))
                        {
                            if (w.RelacionNODO(v))
                            {
                                checkR = D[graph.IndexOf(v)];
                                D[graph.IndexOf(v)] = comparaCostoMin(D[graph.IndexOf(v)], D[graph.IndexOf(w)], costos[graph.IndexOf(w), graph.IndexOf(v)]);
                                if (checkR != D[graph.IndexOf(v)])
                                {
                                    R[graph.IndexOf(v)] = w;
                                }
                            }
                        }
                    }
                }
            }


            if (R[graph.IndexOf(destino)] != null)
            {
                path = consigueCamino(R, destino, origen, destino, "");
            }
            else
            {
                path = "ERROR: NO HAY CAMINOS DIRIGIDOS";
            }
            ImprimeResultados(D, path, origen.Name);
        }
        private void ImprimeResultados(string[] D, string path, string origenName)
        {
            string vexSol = "D[" + origenName + "] = {";
            string costoTotal;

            NodosRecorridosBox.Text = path;

            for (int i = 0; i < graph.Count; i++)
            {
                vexSol += D[i];
                if (i != graph.Count - 1)
                {
                    vexSol += ", ";
                }
            }
            vexSol += "}";
            VectorSolucionBox.Text = vexSol;

            costoTotal = "$[" + origenName + "->" + destino.Name + "]: " + D[graph.IndexOf(destino)];
            CostoCaminoBox.Text = costoTotal;
        }

        private string consigueCamino(NodeP[] R, NodeP actual, NodeP origen, NodeP destino, string road)
        {
            NodeP next;
            if (actual == origen)
            {
                road += actual.Name + " -> ";
            }
            else
            {
                next = R[graph.IndexOf(actual)];
                road = consigueCamino(R, next, origen, destino, road);
                road += actual.Name;
                if (actual != destino)
                {
                    road += " -> ";
                }
            }

            return road;
        }

        public string comparaCostoMin(string dv, string dw, string cv)
        {
            string menor = dv;
            int x, y, z, yz, low;
            y = Convert.ToInt32(dw);
            z = Convert.ToInt32(cv);
            yz = y + z;

            if (dv != "x")
            {
                x = Convert.ToInt32(dv);
                low = (x < yz) ? x : yz;
                menor = low.ToString();
            }
            else
            {
                menor = yz.ToString();
            }

            return menor;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (NodeP p in graph)
            {
                if (p.Name == comboBox2.SelectedItem.ToString())
                {
                    destino = p;
                    DijkstraIniciate.Enabled = true;
                    break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            NodeP exclusion = graph[comboBox1.SelectedIndex];
            origen = exclusion;
            showB(origen);
            DijkstraIniciate.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void MatrizCostos()
        {
            int nodes;
            nodes = graph.Count;
            costos = new string[nodes, nodes];

            int i = 0, j = 0;

            for (int k = 0; k < nodes; k++)
            {
                for (int z = 0; z < nodes; z++)
                {
                    if (k == z)
                    {
                        costos[k, z] = "0";
                    }
                    else
                    {
                        costos[k, z] = "x";
                    }
                }
            }
            foreach (Edge e in graph.edgesList)
            {
                i = graph.IndexOf(e.Source);
                j = graph.IndexOf(e.Destiny);
                if (i != j)
                {
                    costos[i, j] = e.Weight.ToString();
                }
            }

        }

    }
}
