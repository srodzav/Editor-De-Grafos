using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos {
    [Serializable()]

    public class Graph : List<NodeP> {
        private bool edgeNamesVisible;
        private bool edgeWeightVisible;
        private bool edgeIsDirected;
        private int nodeRadio;
        private int nodeBorderWidth;
        private int edgeWidth;
        private Color edgeColor;
        private Color nodeColor;
        private Color nodeBorderColor;
        private bool letter;
        private string name;
        public List<Edge> edgesList;
        // RECORRIDO
        public List<NodeP> Nodos;
        public string Lista;
        // ARBOL
        public List<Edge> AVC;
        public List<Edge> RET;
        public List<Edge> CRU;
        public List<Edge> ARBL;
        public Edge ab;
        public int cont;
        // PRIM
        public int VerticesCount;
        public int EdgesCount;
        public Edge[] edge;

        #region CODIGO
        public List<Edge> EdgesList
        {
            get { return edgesList; }
            set { edgesList = value; }
        }

        public bool Letter {
            get { return letter; }
            set { letter = value; }
        }

        public bool EdgeIsDirected {
            get { return edgeIsDirected; }
            set { edgeIsDirected = value; }
        }

        public int EdgeWidth {
            get { return edgeWidth; }
            set { edgeWidth = value; }
        }

        public Color NodeBorderColor {
            get { return nodeBorderColor; }
            set { nodeBorderColor = value; }
        }

        public int NodeBorderWidth {
            get { return nodeBorderWidth; }
            set { nodeBorderWidth = value; }
        }

        public Color EdgeColor {
            get { return edgeColor; }
            set { edgeColor = value; }
        }

        public Color NodeColor {
            get { return nodeColor; }
            set { nodeColor = value; }
        }

        public int NodeRadio {
            get { return nodeRadio; }
            set { nodeRadio = value; }
        }

        public bool EdgeNamesVisible {
            get { return edgeNamesVisible; }
            set { edgeNamesVisible = value; }
        }

        public bool EdgeWeightVisible {
            get { return edgeWeightVisible; }
            set { edgeWeightVisible = value; }
        }
        

        public Graph() {
            EdgesList = new List<Edge>();
            edgeColor = Color.Black;
            letter = true;
            edgeNamesVisible = false;
            edgeWeightVisible = false;
            nodeColor = Color.White;
            nodeRadio = 30;
            nodeBorderWidth = 1;
            edgeWidth = 1;
            nodeBorderColor = Color.Black;
        }

        public Graph(Graph gr) {

            EdgesList = new List<Edge>();
            edgeColor = gr.EdgeColor;
            nodeColor = gr.nodeColor;
            nodeRadio = gr.NodeRadio;
            Edge k = new Edge();
            NodeP aux1, aux2;

            nodeBorderWidth = 1;
            edgeWidth = 1;
            nodeBorderColor = Color.Black;
            edgeNamesVisible = gr.EdgeNamesVisible;
            edgeWeightVisible = gr.EdgeWeightVisible;
            letter = gr.Letter;

            foreach (NodeP n in gr) {
                this.Add(new NodeP(n));
            }

            foreach (NodeP n in gr) {
                aux1 = Find(delegate (NodeP bu) { if (bu.Name == n.Name) return true; else return false; });
                foreach (NodeR rel in n.relations) {
                    aux2 = Find(delegate (NodeP je) { if (je.Name == rel.Up.Name) return true; else return false; });
                    aux1.InsertRelation(aux2, EdgesList.Count, false);
                }
            }
            //Agregar Aristas 
            foreach (Edge ar in gr.EdgesList) {
                aux1 = Find(delegate (NodeP bu) { if (bu.Name == ar.Source.Name) return true; else return false; });
                aux2 = Find(delegate (NodeP bu) { if (bu.Name == ar.Destiny.Name) return true; else return false; });
                k = new Edge(0, aux1, aux2, ar.Name) {
                    Weight = ar.Weight
                };
                //Manda llamar la funcion para añadir la arista
                AddEdge(k);
            }
        }

        public void AddNode(NodeP n) {
            Add(n);
        }

        public void AddEdge(Edge A) {
            EdgesList.Add(A);
        }

        public void RemoveEdge(Edge ar) {
            NodeR rel;
            rel = ar.Source.relations.Find(delegate (NodeR np) { if (np.Up.Name == ar.Destiny.Name) return true; else return false; });

            if (rel != null) {
                ar.Source.relations.Remove(rel);
                ar.Source.Degree--;
                ar.Destiny.Degree--;
                ar.Source.DegreeEx--;
                ar.Destiny.DegreeIn--;
            }
            if (!edgeIsDirected) {
                rel = ar.Destiny.relations.Find(delegate (NodeR np) { if (np.Up.Name == ar.Source.Name) return true; else return false; });

                if (rel != null) {
                    ar.Destiny.relations.Remove(rel);
                    ar.Destiny.DegreeEx--;
                    ar.Source.DegreeIn--;
                }
            }
            EdgesList.Remove(ar);
        }

        public void RemoveNode(NodeP rem) {
            NodeR rel;
            List<Edge> remove;
            remove = new List<Edge>();

            foreach (NodeP a in this) {
                rel = a.relations.Find(delegate (NodeR np) { if (np.Up.Name == rem.Name) return true; else return false; });
                if (rel != null) {
                    a.relations.Remove(rel);
                    a.Degree--;
                    a.DegreeEx--;
                    if (!edgeIsDirected || edgeIsDirected) {
                        a.DegreeIn--;
                    }
                }
            }
            remove = EdgesList.FindAll(delegate (Edge ar) { if (ar.Source.Name == rem.Name || ar.Destiny.Name == rem.Name) return true; else return false; });
            if (remove != null)
                foreach (Edge re in remove) {
                    EdgesList.Remove(re);
                }
            this.Remove(rem);
        }

        // Regresa si dos nodos está conectados
        public NodeR Connected(NodeP a, NodeP b) {
            for (int i = 0; i < a.relations.Count; i++) {
                if (a.relations[i].Up == b) {
                    return a.relations[i];
                }
            }
            return null;
        }

        // Regresa la arista entre dos nodos que si se sabe que tiene aristas
        public Edge GetEdge(NodeP a, NodeP b) {
            for (int i = 0; i < this.EdgesList.Count; i++) {
                if (this.EdgesList[i].Source.Name == a.Name && this.EdgesList[i].Destiny.Name == b.Name ||
                        this.EdgesList[i].Source.Name == b.Name && this.EdgesList[i].Destiny.Name == a.Name) {
                    return (EdgesList[i]);
                }
            }
            return (null);
        }

        // Deselecciona todos los nodos
        public void UnselectAllNodes() {
            for (int k = 0; k < Count; k++) {
                this[k].Visited = false;
            }
        }

        // Deselecciona todas las aristas
        public void UnselectAllEdges() {
            foreach (Edge ed in EdgesList) {
                ed.Visited = false;
            }
        }

        // Verifica si el grafo es regular
        public bool IsRegular() {
            foreach (NodeP np in this) {
                if (np.Degree < Count - 1) {
                    return false;
                }
            }
            return true;
        }

        // Verifica que el grafo no dirigido este conectado
        public bool IsConnectedU() {
            foreach (NodeP np in this) {
                if (np.Degree == 0) {
                    return false;
                }
            }
            return true;
        }

        // Verifica que todas las aristas estén visitadas
        public bool AllEdgesVisited() {
            foreach (Edge ed in EdgesList) {
                if (ed.Visited == false) {
                    return false;
                }
            }
            return true;
        }

        // Verifica que todos los nodos estén visitados
        public bool AllNodesVisited() {
            foreach (NodeP np in this) {
                if (np.Visited == false) {
                    return false;
                }
            }
            return true;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////
        
        #region RECORRIDOS
        ///////////////////////////////////////////////////////////////////////
        // BPF
        public void bpfrecorrido(int cont)
        { // CAST AL RECORRIDO BPF
            // CREACION DE LISTAS
            AVC = new List<Edge>();
            RET = new List<Edge>();
            CRU = new List<Edge>();
            ARBL = new List<Edge>();
            if (this.Count > 0) // SI NO ESTA VACIO
            {
                Nodos = new List<NodeP>();
                UnselectAllNodes(); 
                int n = 1;
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].Visited == false)
                    {
                        bpf(this[i], 1, n++); // MIENTRAS NO ESTE VISITADO EL NODO SE HACE RECURSIVIDAD
                    }
                }
                if (cont == 1) // CASO FINAL
                {
                    SHOWbpf show = new SHOWbpf(Nodos);
                    show.ShowDialog();
                }
                else 
                {
                    SHOWarbol show = new SHOWarbol(ARBL, AVC, CRU, RET, n);
                    show.ShowDialog();
                }
            }
        }

        public void bpf(NodeP v, int c, int n)
        { // FUNCION RECURSIVA
            int index = -1;
            List<NodeP> visitado = new List<NodeP>();
            for (int i = 0; i < Count; i++)
            {
                if (Converter(this[i].Name) == Converter(v.Name)) // SE COMPARAN LOS NOMBRES
                {
                    v = this[i];
                    this[i].Visited = true;
                    this[i].NumP = c;
                    this[i].N_arr = n;
                    index = i;
                }
            }
            c++;
            Nodos.Add(this[index]); // SE AÑADE EL NODO
            foreach (NodeR w in v.relations) // PSEUDO CODIGO DEL MANUAL
            {
                if (w.Up.Visited == false)
                {
                    ARBL.Add(ab = new Edge(0, v, w.Up, "Arr" + n.ToString()));
                    bpf(w.Up, c, n);
                }
                else if (w.Up.NumP - v.NumP > 0 && w.Up.N_arr == v.N_arr) // CASO 1
                {
                    AVC.Add(ab = new Edge(0, v, w.Up, "Av")); // AVANCE
                }
                else if (w.Up.NumP - v.NumP < 0 && w.Up.N_arr == v.N_arr) // CASO 2
                {
                    RET.Add(ab = new Edge(0, v, w.Up, "Ret")); // RETROCESO
                }
                else if (w.Up.NumP - v.NumP == 0 && w.Up.N_arr != v.N_arr) // CASO 3
                {
                    CRU.Add(ab = new Edge(0, v, w.Up, "Crz")); // CRUZ
                }
            }
        }
        #region CONVERTIDOR
        public int Converter(string letra)
        {
            int r = 0;
            switch (letra)
            {
                case "A":
                    r = 0;
                    break;
                case "B":
                    r = 1;
                    break;
                case "C":
                    r = 2;
                    break;
                case "D":
                    r = 3;
                    break;
                case "E":
                    r = 4;
                    break;
                case "F":
                    r = 5;
                    break;
                case "G":
                    r = 6;
                    break;
                case "H":
                    r = 7;
                    break;
                case "I":
                    r = 8;
                    break;
                case "J":
                    r = 9;
                    break;
                case "K":
                    r = 10;
                    break;
                case "L":
                    r = 11;
                    break;
                case "M":
                    r = 12;
                    break;
                case "N":
                    r = 13;
                    break;
                case "O":
                    r = 14;
                    break;
                case "P":
                    r = 15;
                    break;
                case "Q":
                    r = 16;
                    break;
                case "R":
                    r = 17;
                    break;
                case "S":
                    r = 18;
                    break;
                case "T":
                    r = 19;
                    break;
                case "U":
                    r = 20;
                    break;
                case "V":
                    r = 21;
                    break;
                case "W":
                    r = 22;
                    break;
                case "X":
                    r = 23;
                    break;
                case "Y":
                    r = 24;
                    break;
                case "Z":
                    r = 25;
                    break;
                case "1":
                    r = 0;
                    break;
                case "2":
                    r = 1;
                    break;
                case "3":
                    r = 2;
                    break;
                case "4":
                    r = 3;
                    break;
                case "5":
                    r = 4;
                    break;
                case "6":
                    r = 5;
                    break;
                case "7":
                    r = 6;
                    break;
                case "8":
                    r = 7;
                    break;
                case "9":
                    r = 8;
                    break;
                case "10":
                    r = 9;
                    break;
                case "11":
                    r = 10;
                    break;
                case "12":
                    r = 11;
                    break;
                case "13":
                    r = 12;
                    break;
                case "14":
                    r = 13;
                    break;
                case "15":
                    r = 14;
                    break;
                case "16":
                    r = 15;
                    break;
                case "17":
                    r = 16;
                    break;
                case "18":
                    r = 17;
                    break;
                case "19":
                    r = 18;
                    break;
                case "20":
                    r = 19;
                    break;
                case "21":
                    r = 20;
                    break;
                case "22":
                    r = 21;
                    break;
                case "23":
                    r = 22;
                    break;
                case "24":
                    r = 23;
                    break;
                case "25":
                    r = 24;
                    break;
                case "26":
                    r = 25;
                    break;
                default:
                    break;
            }
            return r;
        }
        #endregion
        ///////////////////////////////////////////////////////////////////////
        // BEA
        public void bearecorrido()
        { // CAST AL RECORRIDO BEA
            if (this.Count > 0) // SI NO ESTA VACIO
            {
                UnselectAllNodes();
                bea(this[0]);
                SHOWbea s = new SHOWbea(Lista);
                s.ShowDialog();
            }
        }
        private void bea(NodeP v)
        { // FUNCION BEA
            List<NodeP> q = new List<NodeP>();
            List<NodeP> nodos = new List<NodeP>();
            NodeP x;
            Lista = "";
            int indice = -1;
            for (int i = 0; i < Count; i++)
            {
                if (Converter(this[i].Name) == Converter(v.Name)) // COMPARACION DE NOMBRES
                {
                    this[i].Visited = true;
                    indice = i;
                }
            }
            q.Add(v); // SE AÑADE V (NODO) A LA LISTA
            while (q.Count > 0)
            {
                x = q[0];
                q.RemoveAt(0);
                foreach (NodeR y in x.relations) // PSEUDOCODIGO 
                {
                    if (y.Up.Visited == false)
                    {
                        y.Up.Visited = true;
                        q.Add(y.Up);
                        Lista = Lista + "(" + x.Name + "," + y.Up.Name + ") ";
                    }
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////
        public string getMissingOrActualEdgeName()
        {
            string missingname = "";
            string auxstring;
            int lastOne, currentOne;
            if (edgesList.Count > 0)
            {
                Edge aux = edgesList.First();
                auxstring = aux.Name.Replace("e", "");
                lastOne = Convert.ToInt32(auxstring);
                foreach (Edge e in edgesList)
                {
                    if (e.Equals(edgesList.First()))
                    {
                        if (lastOne > 0)
                        {
                            missingname = "e0";
                            return missingname;
                        }
                    }
                    else
                    {
                        auxstring = e.Name.Replace("e", "");
                        currentOne = Convert.ToInt32(auxstring);
                        if (currentOne - lastOne != 1)
                        {
                            currentOne = lastOne + 1;
                            missingname = "e" + currentOne.ToString();
                            return missingname;
                        }
                        lastOne = currentOne;
                    }
                }
            }

            return missingname;
        }

        public void SortEdgeListByName()
        {
            if (edgesList.Count > 1)
            {
                List<string> edgelistnames = new List<string>();
                foreach (Edge e in edgesList)
                {
                    edgelistnames.Add(e.Name);
                }
                edgelistnames.Sort();
                List<Edge> sortedEdgesList = new List<Edge>();
                while (sortedEdgesList.Count != EdgesList.Count)
                {
                    foreach (string s in edgelistnames)
                    {
                        foreach (Edge e in edgesList)
                        {
                            if (s == e.Name)
                            {
                                sortedEdgesList.Add(e);
                                break;
                            }
                        }
                    }
                }
                edgesList = sortedEdgesList;
            }
        }

        #endregion
    }
}
