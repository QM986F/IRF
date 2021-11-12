using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_week08.Entities
{
    class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image image = Image.FromFile("Images/car.png");
            g.DrawImage(image, new Rectangle(0, 0, Width, Height));
        }
    }
}
