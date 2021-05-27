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
    public partial class SHOWbea : Form
    {
        public SHOWbea(string L)
        {
            InitializeComponent();
            show(L);
        }
        #region MUESTRA
        private void show(string L)
        {
            tT_bea.Text = L;
        }

        private void Recorrido_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
