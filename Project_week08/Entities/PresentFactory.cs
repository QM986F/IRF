using Project_week08.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_week08.Entities
{
    class PresentFactory : IToyFactory
    {
        public Color color1 { get; set; }
        public Color color2 { get; set; }

        public Toy CreateNew()
        {
            return new Present(color1, color2);
        }

    }
}
