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
    public partial class SHOWarbol : Form
    {
        public SHOWarbol(List<Edge> Arbol, List<Edge> Avanzado, List<Edge> Cruz, List<Edge> Retro, int c)
        {
            InitializeComponent();
            show(Arbol, Avanzado, Cruz, Retro, c);
        }
        #region MUESTRA
        private void show(List<Edge> Arbol, List<Edge> Avanzado, List<Edge> Cruz, List<Edge> Retro, int c)
        {
            for (int i = 1; i < c; i++)
            {
                Imprimir.Text = Imprimir.Text + " Arbol " + i + " =  ";
                foreach (var dato in Arbol)
                {
                    if (dato.Destiny.N_arr == i)
                    {
                        Imprimir.Text = Imprimir.Text + " (" + dato.Source.Name + "," + dato.Destiny.Name + ") ";
                    }
                }
                Imprimir.Text = Imprimir.Text + "\n";
            }
            if (Avanzado.Count > 0)
            {
                Imprimir.Text = Imprimir.Text + "Arcos de Avance = ";
                foreach (var Avance in Avanzado)
                { 
                    Imprimir.Text = Imprimir.Text + " (" + Avance.Source.Name + "," + Avance.Destiny.Name + ") ";
                }
                Imprimir.Text = Imprimir.Text + "\n";
            }
            if (Cruz.Count > 0)
            {
                Imprimir.Text = Imprimir.Text + "Arcos de Cruce = ";
                foreach (var Cruce in Cruz)
                {
                    Imprimir.Text = Imprimir.Text + " (" + Cruce.Source.Name + "," + Cruce.Destiny.Name + ") ";
                }
                Imprimir.Text = Imprimir.Text + "\n";
            }
            if (Retro.Count > 0)
            {
                Imprimir.Text = Imprimir.Text + "Arcos de Retroceso = ";
                foreach (var Retroceso in Retro)
                {
                    Imprimir.Text = Imprimir.Text + " (" + Retroceso.Source.Name + "," + Retroceso.Destiny.Name + ") ";
                }
                Imprimir.Text = Imprimir.Text + "\n";
            }
        }

        private void Imprimir_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
