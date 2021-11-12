using Project_week08.Abstractions;
using Project_week08.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_week08
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int right = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left>right)
                {
                    right = toy.Left;
                }
            }

            if (right>1000)
            {
                var oldestToy = _toys[0];
                _toys.Remove(oldestToy);
                mainPanel.Controls.Remove(oldestToy);
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add((Car)toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
        }
    }
}
