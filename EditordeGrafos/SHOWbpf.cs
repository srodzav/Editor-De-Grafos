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
    public partial class SHOWbpf : Form
    {
        public SHOWbpf(List<NodeP> L)
        {
            InitializeComponent();
            show(L);
        }

        public void show(List<NodeP> L)
        {
            tT_bpf.Text = tT_bpf.Text + "V = { ";
            foreach (var x in L)
            {
                if(x.Name != "")
                    tT_bpf.Text = tT_bpf.Text + x.Name;
                tT_bpf.Text = tT_bpf.Text + ", ";

            }
            tT_bpf.Text = tT_bpf.Text + "}";
        }

        private void Recorrido_Click(object sender, EventArgs e)
        {

        }
    }
}
