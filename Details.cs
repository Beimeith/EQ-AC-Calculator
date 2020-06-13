using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ_AC_Calculator
{
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }

        private MainScreen mainForm = null;
        public Details(Form callingForm)
        {
            mainForm = callingForm as MainScreen;
            InitializeComponent();
        }
    }
}
