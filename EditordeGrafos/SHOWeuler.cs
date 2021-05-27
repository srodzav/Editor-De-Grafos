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
    public partial class SHOWeuler : Form
    {
        public List<NodeR> relaciones;
        public SHOWeuler()
        {
            InitializeComponent();
            show();
        }

        public void show()
        {
            
        }

        public static bool isEven (int n)
        {
            return (n % 2 == 0);
        }
    }
}
