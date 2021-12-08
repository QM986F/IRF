using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace Project_week10
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga = new GameArea();
        public Form1()
        {
            InitializeComponent();
            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);

            gc.AddPlayer();
            gc.Start(true);
        }
    }
}
