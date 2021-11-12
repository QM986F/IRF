using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_week08.Entities
{
    class Present : Toy
    {
        public SolidBrush PresentColor1 { get; set; }
        public SolidBrush PresentColor2 { get; set; }
        public Present(Color color1,Color color2)
        {
            PresentColor1 = new SolidBrush(color1);
            PresentColor2 = new SolidBrush(color2);
        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(PresentColor1, 0, 0, Width, Height);
            g.FillRectangle(PresentColor2, 0, (Height / 5) * 2, Width, Height / 5);
            g.FillRectangle(PresentColor2, (Width / 5) * 2, 0, Width / 5, Height);
        }
    }
}
