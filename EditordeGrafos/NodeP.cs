using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    [Serializable()]

    public class NodeP{
        private bool visited;
        private bool selected;
        private int degree;
        private int degreeIn;
        private int degreeEx;
        private int level;
        private int numP;
        private int n_arr;
        private string name; /// tomar este 
        private Point position;
        private Color color;
        public List<NodeR> relations;

        #region SET&GET
        public Point Position { 
            get { return position; } 
            set { position = value; } 
        }

        public string Name {
            get { return name; } 
            set { name = value; } 
        }
        public int Degree {
            get { return degree; } 
            set { degree = value; } 
        }
        public int NumP
        {
            get { return numP; }
            set { numP = value; }
        }
        public int N_arr
        {
            get { return n_arr; }
            set { n_arr = value; }
        }
        public Color Color{
            get { return color; } 
            set { color=value; }
        }

        public int DegreeIn {
            get { return degreeIn; } 
            set { degreeIn = value; } 
        }
        public int DegreeEx {
            get { return degreeEx; } 
            set { degreeEx = value; } 
        }
        public bool Selected{
            get { return selected; }
            set { selected=value; }
        }
        public bool Visited { 
            get { return visited; } 
            set { visited = value; } 
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        #endregion
        #region constructores

        public NodeP(){

        }

        public NodeP(NodeP co){
            position = co.Position;
            name = co.Name;
            relations = new List<NodeR>();
            degree = co.Degree;
            degreeEx = co.DegreeEx;
            degreeIn = co.DegreeIn;
            color = co.Color;
            selected = false;
        }

        public NodeP(Point p, char n){
            position = p;
            name = n.ToString();
            relations = new List<NodeR>();
            degree = 0;
            color = Color.White;
            selected = false;
        }

        #endregion
        #region operaciones

        public void InsertRelation(NodeP newRel, int num, bool isDirected){
            Degree++;
            if(isDirected){
                DegreeEx++;
                newRel.DegreeIn++;
            }

            relations.Add(new NodeR(newRel, "e" + num.ToString()));
            Ordenar();
        }

        public void RemoveRelation(NodeR delRel, bool isDirected) {
            Degree--;
            if (isDirected) {
                delRel.Up.DegreeIn--;
                this.degreeEx--;
            }
            relations.Remove(delRel);
        }

        #endregion
        #region CODIGO
        public void Ordenar()
        {
            if (relations.Count > 1)
            {
                List<string> edgelistnames = new List<string>();
                foreach (NodeR e in relations)
                {
                    edgelistnames.Add(e.Up.Name);
                }
                edgelistnames.Sort();
                List<NodeR> sortedEdgesList = new List<NodeR>();
                while (sortedEdgesList.Count != relations.Count)
                {
                    foreach (string s in edgelistnames)
                    {
                        foreach (NodeR e in relations)
                        {
                            if (s == e.Up.Name)
                            {
                                sortedEdgesList.Add(e);
                                break;
                            }
                        }
                    }
                }
                relations = sortedEdgesList;
            }
        }

        public bool RelacionNODO(NodeP q)
        {
            bool related = false;
            foreach (NodeR r in relations)
            {
                if (r.Up == q)
                {
                    related = true;
                    break;
                }
            }
            return related;
        }
        #endregion
    }
}
